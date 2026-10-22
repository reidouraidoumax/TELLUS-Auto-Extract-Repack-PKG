using System.Diagnostics;
using System.Runtime.InteropServices;
using OrbisPkgTool;
using OrbisPkgTool.Gp4;
using OrbisPkgTool.Pfs;

namespace PS4PkgAutoExtractor;

public sealed partial class MainForm : Form
{
    private readonly Queue<string> extractQueue = new();
    private readonly object extractQueueLock = new();
    private bool extractProcessing;
    private CancellationTokenSource? extractCancellation;

    private readonly Queue<string> repackQueue = new();
    private readonly object repackQueueLock = new();
    private bool repackProcessing;
    private CancellationTokenSource? repackCancellation;

    private const string DefaultPasscode = PkgReader.DefaultPasscode;

    // Fixed to the bundled tools — orbis-pub-cmd.exe is the only one that
    // honors our per-file pfs_compression policy (PkgTool.Core.exe ignores
    // it and always builds uncompressed), so it's the one actually used;
    // PkgTool.Core.exe stays as a silent fallback in case orbis-pub-cmd.exe
    // is ever missing from a build. Neither is user-configurable — both are
    // meant to just be present in Tools/ (see Tools/README.txt).
    private string? pkgToolPath;
    private string? pubCmdPath;

    // ---- UI state (all colors are read from designer-set control properties) ----

    private enum LogKind { Normal, Header, Success, Error }

    private sealed class Zone
    {
        public required Panel Border { get; init; }
        public required Label Tag { get; init; }
        public required Panel Idle { get; init; }
        public required Panel Busy { get; init; }
        public bool IsBusy;
        public bool IsDropTarget;
    }

    private readonly Zone extractZone;
    private readonly Zone repackZone;

    // Idle look, captured from the designer values so editing them in the
    // Properties window is all it takes to restyle the zones.
    private readonly Color zoneIdleBorder;
    private readonly Color tagIdleBack;
    private readonly Color tagIdleFore;

    private int extractPercent;
    private DateTime repackStartedUtc;
    private int doneCount;
    private int errorCount;
    private string? lastOutputPath;

    public MainForm()
    {
        InitializeComponent();

        extractZone = new Zone { Border = pnlExtractBorder, Tag = lblExtractTag, Idle = pnlExtractIdle, Busy = pnlExtractBusy };
        repackZone = new Zone { Border = pnlRepackBorder, Tag = lblRepackTag, Idle = pnlRepackIdle, Busy = pnlRepackBusy };
        zoneIdleBorder = pnlExtractBorder.BackColor;
        tagIdleBack = lblExtractTag.BackColor;
        tagIdleFore = lblExtractTag.ForeColor;
    }

    // Active accent = the big percentage number's color; text on the accent = the window background.
    private Color AccentColor => lblExtractPercent.ForeColor;
    private Color AccentInkColor => BackColor;

    private void MainForm_Load(object? sender, EventArgs e)
    {
        ApplyRuntimeOnlyWindowChrome();

        var toolsDir = ExtractBundledTools();
        var bundledPkgTool = Path.Combine(toolsDir, "PkgTool.Core.exe");
        if (File.Exists(bundledPkgTool))
            pkgToolPath = bundledPkgTool;

        var bundledPubCmd = Path.Combine(toolsDir, "orbis-pub-cmd.exe");
        if (File.Exists(bundledPubCmd))
            pubCmdPath = bundledPubCmd;

        UpdateCounters();
    }

    /// <summary>
    /// Writes the embedded PKG-building tools out to a per-user AppData
    /// folder (not visible next to the exe) and returns that folder. Only
    /// actually writes a file when it's missing or its size doesn't match
    /// the embedded copy — cheap staleness check so an app update refreshes
    /// stale tools without re-extracting ~4 MB on every single launch.
    /// </summary>
    private static string ExtractBundledTools()
    {
        var toolsDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
            "PS4PkgAutoExtractor", "Tools");

        // logical resource name -> relative output path under toolsDir
        var files = new (string Resource, string RelativePath)[]
        {
            ("PkgTool.Core.exe", "PkgTool.Core.exe"),
            ("PkgTool.Core.dll", "PkgTool.Core.dll"),
            ("LibOrbisPkg.Core.dll", "LibOrbisPkg.Core.dll"),
            ("PkgTool.Core.deps.json", "PkgTool.Core.deps.json"),
            ("PkgTool.Core.runtimeconfig.json", "PkgTool.Core.runtimeconfig.json"),
            ("orbis-pub-cmd.exe", "orbis-pub-cmd.exe"),
            ("orbis-pub-prx.dll", "orbis-pub-prx.dll"),
            ("ext.di.exe", Path.Combine("ext", "di.exe")),
            ("ext.sc.exe", Path.Combine("ext", "sc.exe")),
            ("ext.libatrac9.dll", Path.Combine("ext", "libatrac9.dll")),
        };

        var asm = typeof(MainForm).Assembly;
        try
        {
            Directory.CreateDirectory(Path.Combine(toolsDir, "ext"));

            foreach (var (resource, relativePath) in files)
            {
                using var stream = asm.GetManifestResourceStream("BundledTools." + resource);
                if (stream is null) continue; // not embedded in this build — fine, just skip it

                var outPath = Path.Combine(toolsDir, relativePath);
                if (File.Exists(outPath) && new FileInfo(outPath).Length == stream.Length)
                    continue; // already extracted and the right size — skip re-writing it

                using var outFile = new FileStream(outPath, FileMode.Create, FileAccess.Write);
                stream.CopyTo(outFile);
            }
        }
        catch
        {
            // Best-effort — if extraction fails (e.g. no write permission),
            // the caller just won't find the tools and reports that clearly.
        }

        return toolsDir;
    }

    private void MainForm_FormClosing(object? sender, FormClosingEventArgs e)
    {
        extractCancellation?.Cancel();
        repackCancellation?.Cancel();
    }

    // ---- Drag & drop: one target for the whole window, routed by type ----

    /// <summary>
    /// Routes paths to the right queue: .pkg files go to Extract, folders go
    /// to Repack. Used for drops and for paths passed on the command line
    /// (dragging onto the exe).
    /// </summary>
    public void QueuePaths(IEnumerable<string> paths)
    {
        var list = paths.ToList();
        QueueFiles(list.Where(p => File.Exists(p)));
        QueueFolders(list.Where(p => Directory.Exists(p)));
    }

    private static bool IsPkg(string path) =>
        path.EndsWith(".pkg", StringComparison.OrdinalIgnoreCase) && File.Exists(path);

    private void OnDragEnter(object? sender, DragEventArgs e)
    {
        if (e.Data?.GetData(DataFormats.FileDrop) is not string[] paths)
        {
            e.Effect = DragDropEffects.None;
            return;
        }

        var hasPkg = paths.Any(IsPkg);
        var hasFolder = paths.Any(Directory.Exists);
        e.Effect = hasPkg || hasFolder ? DragDropEffects.Copy : DragDropEffects.None;

        extractZone.IsDropTarget = hasPkg;
        repackZone.IsDropTarget = hasFolder;
        RefreshZone(extractZone);
        RefreshZone(repackZone);
    }

    private void OnDragLeave(object? sender, EventArgs e) => ClearDropTargets();

    private void OnDragDrop(object? sender, DragEventArgs e)
    {
        ClearDropTargets();
        if (e.Data?.GetData(DataFormats.FileDrop) is string[] paths)
            QueuePaths(paths);
    }

    private void ClearDropTargets()
    {
        extractZone.IsDropTarget = false;
        repackZone.IsDropTarget = false;
        RefreshZone(extractZone);
        RefreshZone(repackZone);
    }

    private void RefreshZone(Zone zone)
    {
        var lit = zone.IsBusy || zone.IsDropTarget;
        zone.Border.BackColor = lit ? AccentColor : zoneIdleBorder;
        zone.Tag.BackColor = lit ? AccentColor : tagIdleBack;
        zone.Tag.ForeColor = lit ? AccentInkColor : tagIdleFore;
        zone.Tag.Text = zone.IsDropTarget
            ? (zone.IsBusy ? "+ QUEUE" : "DROP")
            : (zone.IsBusy ? "WORKING" : "READY");

        zone.Busy.Visible = zone.IsBusy;
        zone.Idle.Visible = !zone.IsBusy;
    }

    // ---- Extract ----

    public void QueueFiles(IEnumerable<string> paths)
    {
        var added = 0;
        lock (extractQueueLock)
        {
            foreach (var path in paths)
            {
                if (IsPkg(path))
                {
                    extractQueue.Enqueue(Path.GetFullPath(path));
                    added++;
                }
            }
        }

        if (added > 0)
        {
            AppendLog($"Queued {added} PKG file{(added == 1 ? "" : "s")} for extraction.");
            UpdateCounters();
            if (!extractProcessing)
                _ = ProcessExtractQueueAsync();
        }
    }

    private async Task ProcessExtractQueueAsync()
    {
        if (extractProcessing) return;
        extractProcessing = true;
        extractCancellation = new CancellationTokenSource();
        extractZone.IsBusy = true;
        RefreshZone(extractZone);

        try
        {
            while (true)
            {
                string? pkg;
                lock (extractQueueLock)
                    pkg = extractQueue.Count > 0 ? extractQueue.Dequeue() : null;

                if (pkg is null)
                    break;

                UpdateCounters();
                await ExtractOneAsync(pkg, extractCancellation.Token);
            }
        }
        catch (OperationCanceledException)
        {
            lblExtractStatus.Text = "Extraction cancelled.";
            AppendLog("Extraction cancelled.", LogKind.Error);
        }
        finally
        {
            extractCancellation.Dispose();
            extractCancellation = null;
            extractProcessing = false;
            if (!IsDisposed)
            {
                extractZone.IsBusy = false;
                RefreshZone(extractZone);
                UpdateCounters();
            }

            // A new drop can arrive while the previous job was finishing.
            bool restart;
            lock (extractQueueLock)
                restart = extractQueue.Count > 0;

            if (restart)
                _ = ProcessExtractQueueAsync();
        }
    }

    private async Task ExtractOneAsync(string pkgPath, CancellationToken ct)
    {
        var pkgName = Path.GetFileName(pkgPath);
        var output = CreateOutputDirectory(pkgPath);

        lblExtractFile.Text = pkgName;
        lblExtractCount.Text = "Reading…";
        SetExtractProgress(0);
        AppendLog($"EXTRACT  {pkgName}", LogKind.Header);
        AppendLog($"Output: {output}");

        try
        {
            using var reader = new PkgReader(pkgPath, DefaultPasscode);
            if (!reader.IsValidPkg)
                throw new InvalidDataException("The file is not a valid PS4 PKG.");

            var info = reader.GetInfo();
            if (!string.IsNullOrWhiteSpace(info.Title))
                AppendLog($"Title: {info.Title}");
            if (!string.IsNullOrWhiteSpace(info.TitleId))
                AppendLog($"Title ID: {info.TitleId}");
            if (!string.IsNullOrWhiteSpace(info.ContentId))
                AppendLog($"Content ID: {info.ContentId}");

            var progressReporter = new Progress<(int Current, int Total, string CurrentFile)>(p =>
            {
                if (IsDisposed || Disposing) return;
                var percent = p.Total <= 0 ? 0 : Math.Clamp((int)Math.Round(p.Current * 100.0 / p.Total), 0, 100);
                SetExtractProgress(percent);
                lblExtractCount.Text = $"{p.Current:N0} / {p.Total:N0} files";
            });

            var options = new ExtractAllOptions
            {
                CancellationToken = ct,
                ContinueOnError = true
            };

            var failures = await Task.Run(() => reader.ExtractAll(output, progressReporter, options), ct);
            SetExtractProgress(100);
            lastOutputPath = output;

            if (failures.Count == 0)
            {
                doneCount++;
                lblExtractStatus.Text = $"Finished: {pkgName}";
                AppendLog("Extraction completed successfully.", LogKind.Success);
            }
            else
            {
                errorCount++;
                lblExtractStatus.Text = $"Finished with {failures.Count} error(s): {pkgName}";
                AppendLog($"Extraction completed with {failures.Count} file error(s):", LogKind.Error);
                foreach (var failure in failures.Take(50))
                    AppendLog($"  {failure.Path}: {failure.Exception.Message}", LogKind.Error);
                if (failures.Count > 50)
                    AppendLog($"  ...and {failures.Count - 50} more.", LogKind.Error);
            }

            AppendLog("");
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            errorCount++;
            lblExtractStatus.Text = $"Failed: {pkgName}";
            AppendLog("ERROR: " + ex.Message, LogKind.Error);
            AppendLog("");
        }
        finally
        {
            UpdateCounters();
        }
    }

    private void SetExtractProgress(int percent)
    {
        extractPercent = percent;
        lblExtractPercent.Text = $"{percent}%";
        pnlExtractFill.Width = pnlExtractTrack.ClientSize.Width * percent / 100;
    }

    private void ExtractTrack_Resize(object? sender, EventArgs e)
    {
        pnlExtractFill.Width = pnlExtractTrack.ClientSize.Width * extractPercent / 100;
    }

    private static string CreateOutputDirectory(string pkgPath)
    {
        var parent = Path.GetDirectoryName(pkgPath)!;
        var name = Path.GetFileNameWithoutExtension(pkgPath);
        var candidate = Path.Combine(parent, name);

        if (!Directory.Exists(candidate))
        {
            Directory.CreateDirectory(candidate);
            return candidate;
        }

        for (var i = 1; ; i++)
        {
            candidate = Path.Combine(parent, $"{name}_extracted_{i}");
            if (!Directory.Exists(candidate))
            {
                Directory.CreateDirectory(candidate);
                return candidate;
            }
        }
    }

    // ---- Repack ----

    public void QueueFolders(IEnumerable<string> paths)
    {
        var added = 0;
        lock (repackQueueLock)
        {
            foreach (var path in paths)
            {
                if (Directory.Exists(path))
                {
                    repackQueue.Enqueue(Path.GetFullPath(path.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)));
                    added++;
                }
            }
        }

        if (added > 0)
        {
            AppendLog($"Queued {added} folder{(added == 1 ? "" : "s")} for repacking.");
            UpdateCounters();
            if (!repackProcessing)
                _ = ProcessRepackQueueAsync();
        }
    }

    private async Task ProcessRepackQueueAsync()
    {
        if (repackProcessing) return;
        repackProcessing = true;
        repackCancellation = new CancellationTokenSource();
        repackZone.IsBusy = true;
        RefreshZone(repackZone);
        repackTimer.Start();

        try
        {
            while (true)
            {
                string? folder;
                lock (repackQueueLock)
                    folder = repackQueue.Count > 0 ? repackQueue.Dequeue() : null;

                if (folder is null)
                    break;

                UpdateCounters();
                await RepackOneAsync(folder, repackCancellation.Token);
            }
        }
        catch (OperationCanceledException)
        {
            lblRepackStatus.Text = "Repackaging cancelled.";
            AppendLog("Repackaging cancelled.", LogKind.Error);
        }
        finally
        {
            repackCancellation.Dispose();
            repackCancellation = null;
            repackProcessing = false;
            if (!IsDisposed)
            {
                repackTimer.Stop();
                repackZone.IsBusy = false;
                RefreshZone(repackZone);
                UpdateCounters();
            }

            bool restart;
            lock (repackQueueLock)
                restart = repackQueue.Count > 0;

            if (restart)
                _ = ProcessRepackQueueAsync();
        }
    }

    private async Task RepackOneAsync(string folderPath, CancellationToken ct)
    {
        var folderName = Path.GetFileName(folderPath);
        repackStartedUtc = DateTime.UtcNow;
        lblRepackFile.Text = folderName;
        lblRepackStage.Text = "Reading folder";
        lblRepackElapsed.Text = "0:00";
        AppendLog($"REPACK  {folderName}", LogKind.Header);

        var usePubCmd = !string.IsNullOrWhiteSpace(pubCmdPath) && File.Exists(pubCmdPath);
        var usePkgTool = !usePubCmd && !string.IsNullOrWhiteSpace(pkgToolPath) && File.Exists(pkgToolPath);

        if (!usePubCmd && !usePkgTool)
        {
            errorCount++;
            UpdateCounters();
            lblRepackStatus.Text = "No PKG builder tool set.";
            AppendLog("ERROR: Neither orbis-pub-cmd.exe nor PkgTool.exe was found in this app's Tools folder.", LogKind.Error);
            AppendLog("Get PkgTool.exe from github.com/OpenOrbis/LibOrbisPkg, or place orbis-pub-cmd.exe in this app's Tools folder for correctly-sized output.");
            AppendLog("");
            return;
        }

        string? tempGp4 = null;
        string? tempOutDir = null;
        try
        {
            lblRepackStage.Text = "Generating GP4";
            var pfscProfile = BuildSystemFileRawPolicy(folderPath);
            var project = Gp4Project.FromFolder(folderPath, isPatch: false, pfscProfile: pfscProfile, strictGengp4: true);

            AppendLog($"Title: {project.Title}");
            if (!string.IsNullOrWhiteSpace(project.TitleId))
                AppendLog($"Title ID: {project.TitleId}");
            if (!string.IsNullOrWhiteSpace(project.ContentId))
                AppendLog($"Content ID: {project.ContentId}");
            AppendLog($"{project.Files.Count} entries.");

            tempGp4 = Path.Combine(Path.GetTempPath(), $"{Guid.NewGuid():N}.gp4");
            await File.WriteAllTextAsync(tempGp4, project.Serialize(), ct);

            tempOutDir = Path.Combine(Path.GetTempPath(), $"pkgbuild_{Guid.NewGuid():N}");
            Directory.CreateDirectory(tempOutDir);

            var toolName = usePubCmd ? "orbis-pub-cmd.exe" : "PkgTool.exe";
            lblRepackStage.Text = $"Building via {Path.GetFileNameWithoutExtension(toolName)}";

            var psi = new ProcessStartInfo
            {
                FileName = usePubCmd ? pubCmdPath : pkgToolPath,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                CreateNoWindow = true
            };

            if (usePubCmd)
            {
                // orbis-pub-cmd.exe honors each file's pfs_compression attribute
                // from the GP4 (unlike PkgTool.Core.exe, which ignores it and
                // always builds uncompressed) — this is what gets us a
                // correctly-sized package instead of one roughly double size.
                psi.ArgumentList.Add("img_create");
                psi.ArgumentList.Add("--oformat");
                psi.ArgumentList.Add("pkg");
                psi.ArgumentList.Add("--tmp_path");
                psi.ArgumentList.Add(tempOutDir);
                psi.ArgumentList.Add(tempGp4);
                psi.ArgumentList.Add(tempOutDir);
            }
            else
            {
                psi.ArgumentList.Add("pkg_build");
                psi.ArgumentList.Add(tempGp4);
                psi.ArgumentList.Add(tempOutDir);
            }

            AppendLog($"Running: \"{psi.FileName}\" {string.Join(" ", psi.ArgumentList.Select(a => $"\"{a}\""))}");

            using var process = new Process { StartInfo = psi, EnableRaisingEvents = true };
            process.OutputDataReceived += (_, args) => { if (args.Data != null) AppendLog(args.Data); };
            process.ErrorDataReceived += (_, args) => { if (args.Data != null) AppendLog("  " + args.Data); };

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            using (ct.Register(() =>
            {
                try { if (!process.HasExited) process.Kill(entireProcessTree: true); } catch { }
            }))
            {
                await process.WaitForExitAsync(ct);
            }

            if (process.ExitCode != 0)
                throw new InvalidOperationException($"{toolName} exited with code {process.ExitCode} — see the log above for details.");

            var builtPkg = Directory.EnumerateFiles(tempOutDir, "*.pkg", SearchOption.AllDirectories).FirstOrDefault();
            if (builtPkg is null)
                throw new FileNotFoundException($"{toolName} reported success but produced no .pkg file.");

            var outputPkg = CreateOutputPkgPath(folderPath, project.ContentId);
            File.Move(builtPkg, outputPkg);
            lastOutputPath = outputPkg;

            doneCount++;
            lblRepackStatus.Text = $"Finished: {Path.GetFileName(outputPkg)}";
            AppendLog($"Output: {outputPkg}");
            AppendLog($"Repackaging completed via {toolName}.", LogKind.Success);
            AppendLog("");
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            errorCount++;
            lblRepackStatus.Text = $"Failed: {folderName}";
            AppendLog("ERROR: " + ex.Message, LogKind.Error);
            AppendLog("");
        }
        finally
        {
            UpdateCounters();
            if (tempGp4 != null)
            {
                try { File.Delete(tempGp4); } catch { }
            }
            if (tempOutDir != null)
            {
                try { Directory.Delete(tempOutDir, recursive: true); } catch { }
            }
        }
    }

    /// <summary>
    /// The external PKG builder gives no per-file progress, so the repack
    /// zone shows elapsed time and a sliding bar instead of a percentage.
    /// </summary>
    private void RepackTimer_Tick(object? sender, EventArgs e)
    {
        var elapsed = DateTime.UtcNow - repackStartedUtc;
        lblRepackElapsed.Text = elapsed.TotalHours >= 1
            ? elapsed.ToString(@"h\:mm\:ss")
            : elapsed.ToString(@"m\:ss");

        var trackWidth = pnlRepackTrack.ClientSize.Width;
        var next = pnlRepackFill.Left + Math.Max(2, trackWidth / 90);
        pnlRepackFill.Left = next > trackWidth ? -pnlRepackFill.Width : next;
    }

    /// <summary>
    /// Sony's own packer never PFSC-compresses eboot.bin, the sce_module/*
    /// .prx/.sprx native modules, or the sce_sys/* metadata — the PS4 loader
    /// maps several of these directly and does not expect compressed data
    /// there. Gp4Project.FromFolder has no way to know that on its own (it
    /// just lists whatever's in the folder), so we build the raw/compressed
    /// policy ourselves and hand it in, instead of leaving every file's
    /// compression unset — which would make PkgBuilder compress everything,
    /// including files that must stay raw for the package to actually boot.
    /// </summary>
    private static Dictionary<string, PfscPolicy> BuildSystemFileRawPolicy(string folderPath)
    {
        var profile = new Dictionary<string, PfscPolicy>();
        foreach (var f in Directory.EnumerateFiles(folderPath, "*", SearchOption.AllDirectories))
        {
            var rel = Path.GetRelativePath(folderPath, f).Replace('\\', '/');
            var isSystemFile =
                rel.Equals("eboot.bin", StringComparison.OrdinalIgnoreCase) ||
                rel.StartsWith("sce_module/", StringComparison.OrdinalIgnoreCase) ||
                rel.StartsWith("sce_sys/", StringComparison.OrdinalIgnoreCase);

            profile[PfscProfiler.NormalizeKey(rel)] = isSystemFile ? PfscPolicy.Disable : PfscPolicy.Enable;
        }
        return profile;
    }

    private static string CreateOutputPkgPath(string folderPath, string? contentId)
    {
        var parent = Path.GetDirectoryName(folderPath)!;

        var name = string.IsNullOrWhiteSpace(contentId)
            ? Path.GetFileName(folderPath)
            : contentId;

        foreach (var invalid in Path.GetInvalidFileNameChars())
            name = name.Replace(invalid, '_');

        var candidate = Path.Combine(parent, name + ".pkg");

        if (!File.Exists(candidate))
            return candidate;

        for (var i = 1; ; i++)
        {
            candidate = Path.Combine(parent, $"{name}_repack_{i}.pkg");
            if (!File.Exists(candidate))
                return candidate;
        }
    }

    // ---- Console & footer ----

    private void AppendLog(string message, LogKind kind = LogKind.Normal)
    {
        if (IsDisposed || Disposing) return;
        if (InvokeRequired)
        {
            try { BeginInvoke(new Action<string, LogKind>(AppendLog), message, kind); } catch { }
            return;
        }

        txtLog.SelectionStart = txtLog.TextLength;
        txtLog.SelectionLength = 0;

        if (message.Length > 0)
        {
            txtLog.SelectionColor = AccentColor;
            txtLog.AppendText($"{DateTime.Now:HH:mm:ss}  ");
            txtLog.SelectionColor = kind switch
            {
                LogKind.Header => lblExtractTitle.ForeColor,
                LogKind.Success => lblDoneValue.ForeColor,
                LogKind.Error => lblErrorsValue.ForeColor,
                _ => txtLog.ForeColor,
            };
            txtLog.AppendText(message);
        }

        txtLog.AppendText(Environment.NewLine);
        txtLog.SelectionColor = txtLog.ForeColor;
        txtLog.ScrollToCaret();
    }

    private void UpdateCounters()
    {
        if (IsDisposed) return;
        int waiting;
        lock (extractQueueLock)
            waiting = extractQueue.Count;
        lock (repackQueueLock)
            waiting += repackQueue.Count;

        lblQueueValue.Text = waiting.ToString();
        lblDoneValue.Text = doneCount.ToString();
        lblErrorsValue.Text = errorCount.ToString();
    }

    private void OpenFolder_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e)
    {
        try
        {
            if (lastOutputPath != null && File.Exists(lastOutputPath))
                Process.Start("explorer.exe", $"/select,\"{lastOutputPath}\"");
            else if (lastOutputPath != null && Directory.Exists(lastOutputPath))
                Process.Start("explorer.exe", $"\"{lastOutputPath}\"");
            else
                AppendLog("Nothing to open yet — the output folder appears here after the first job.");
        }
        catch (Exception ex)
        {
            AppendLog("Couldn't open the folder: " + ex.Message, LogKind.Error);
        }
    }

    private void Clear_LinkClicked(object? sender, LinkLabelLinkClickedEventArgs e) => txtLog.Clear();

    // ---- Runtime-only window chrome (not visible in the designer) ----

    /// <summary>
    /// Dark title bar tinted to the window background, and dark scrollbars on
    /// the console. Colors come from the form's own BackColor/ForeColor.
    /// </summary>
    private void ApplyRuntimeOnlyWindowChrome()
    {
        try
        {
            int useDarkMode = 1;
            if (DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE, ref useDarkMode, sizeof(int)) != 0)
                DwmSetWindowAttribute(Handle, DWMWA_USE_IMMERSIVE_DARK_MODE_OLD, ref useDarkMode, sizeof(int));

            // Windows 11 only; older builds ignore these and keep the dark title bar.
            int caption = ColorTranslator.ToWin32(BackColor);
            int text = ColorTranslator.ToWin32(ForeColor);
            DwmSetWindowAttribute(Handle, DWMWA_CAPTION_COLOR, ref caption, sizeof(int));
            DwmSetWindowAttribute(Handle, DWMWA_TEXT_COLOR, ref text, sizeof(int));

            SetWindowTheme(txtLog.Handle, "DarkMode_Explorer", null);
        }
        catch
        {
            // Best-effort styling only; older Windows builds keep the default chrome.
        }
    }

    private const int DWMWA_USE_IMMERSIVE_DARK_MODE = 20;
    private const int DWMWA_USE_IMMERSIVE_DARK_MODE_OLD = 19;
    private const int DWMWA_CAPTION_COLOR = 35;
    private const int DWMWA_TEXT_COLOR = 36;

    [DllImport("uxtheme.dll", CharSet = CharSet.Unicode)]
    private static extern int SetWindowTheme(IntPtr hWnd, string pszSubAppName, string? pszSubIdList);

    [DllImport("dwmapi.dll")]
    private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, ref int attrValue, int attrSize);
}
