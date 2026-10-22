namespace PS4PkgAutoExtractor;

partial class MainForm
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
        pnlHeader = new Panel();
        lblPlatform = new Label();
        flowBrand = new FlowLayoutPanel();
        lblBrandPkg = new Label();
        lblBrandSlash = new Label();
        lblBrandForge = new Label();
        lblLogo = new Label();
        tblZones = new TableLayoutPanel();
        pnlExtractBorder = new Panel();
        pnlExtractZone = new Panel();
        pnlExtractBusy = new Panel();
        flowExtractNumbers = new FlowLayoutPanel();
        lblExtractPercent = new Label();
        lblExtractCount = new Label();
        lblExtractFile = new Label();
        pnlExtractTrack = new Panel();
        pnlExtractFill = new Panel();
        pnlExtractIdle = new Panel();
        lblExtractIcon = new Label();
        lblExtractStatus = new Label();
        lblExtractHint = new Label();
        lblExtractTag = new Label();
        lblExtractTitle = new Label();
        pnlRepackBorder = new Panel();
        pnlRepackZone = new Panel();
        pnlRepackBusy = new Panel();
        flowRepackNumbers = new FlowLayoutPanel();
        lblRepackElapsed = new Label();
        lblRepackStage = new Label();
        lblRepackFile = new Label();
        pnlRepackTrack = new Panel();
        pnlRepackFill = new Panel();
        pnlRepackIdle = new Panel();
        lblRepackIcon = new Label();
        lblRepackStatus = new Label();
        lblRepackHint = new Label();
        lblRepackTag = new Label();
        lblRepackTitle = new Label();
        pnlConsole = new Panel();
        txtLog = new RichTextBox();
        pnlConsoleHeader = new Panel();
        flowConsoleLinks = new FlowLayoutPanel();
        lnkOpenFolder = new LinkLabel();
        lnkClear = new LinkLabel();
        lblConsoleTitle = new Label();
        pnlConsoleLine = new Panel();
        pnlFooter = new Panel();
        lblFooterHint = new Label();
        flowFooterStats = new FlowLayoutPanel();
        lblQueueCaption = new Label();
        lblQueueValue = new Label();
        lblDoneCaption = new Label();
        lblDoneValue = new Label();
        lblErrorsCaption = new Label();
        lblErrorsValue = new Label();
        pnlFooterLine = new Panel();
        repackTimer = new System.Windows.Forms.Timer(components);
        pnlHeader.SuspendLayout();
        flowBrand.SuspendLayout();
        tblZones.SuspendLayout();
        pnlExtractBorder.SuspendLayout();
        pnlExtractZone.SuspendLayout();
        pnlExtractBusy.SuspendLayout();
        flowExtractNumbers.SuspendLayout();
        pnlExtractTrack.SuspendLayout();
        pnlExtractIdle.SuspendLayout();
        pnlRepackBorder.SuspendLayout();
        pnlRepackZone.SuspendLayout();
        pnlRepackBusy.SuspendLayout();
        flowRepackNumbers.SuspendLayout();
        pnlRepackTrack.SuspendLayout();
        pnlRepackIdle.SuspendLayout();
        pnlConsole.SuspendLayout();
        pnlConsoleHeader.SuspendLayout();
        flowConsoleLinks.SuspendLayout();
        pnlFooter.SuspendLayout();
        flowFooterStats.SuspendLayout();
        SuspendLayout();
        // 
        // pnlHeader
        // 
        pnlHeader.Controls.Add(lblPlatform);
        pnlHeader.Controls.Add(flowBrand);
        pnlHeader.Controls.Add(lblLogo);
        pnlHeader.Dock = DockStyle.Top;
        pnlHeader.Location = new Point(0, 0);
        pnlHeader.Name = "pnlHeader";
        pnlHeader.Size = new Size(580, 60);
        pnlHeader.TabIndex = 0;
        // 
        // lblPlatform
        // 
        lblPlatform.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblPlatform.Font = new Font("Segoe UI Semibold", 8.25F);
        lblPlatform.ForeColor = Color.FromArgb(91, 98, 117);
        lblPlatform.Location = new Point(442, 22);
        lblPlatform.Name = "lblPlatform";
        lblPlatform.Size = new Size(120, 16);
        lblPlatform.TabIndex = 2;
        lblPlatform.Text = "PS4 · FPKG";
        lblPlatform.TextAlign = ContentAlignment.MiddleRight;
        // 
        // flowBrand
        // 
        flowBrand.AutoSize = true;
        flowBrand.Controls.Add(lblBrandPkg);
        flowBrand.Controls.Add(lblBrandSlash);
        flowBrand.Controls.Add(lblBrandForge);
        flowBrand.Location = new Point(54, 15);
        flowBrand.Name = "flowBrand";
        flowBrand.Size = new Size(190, 30);
        flowBrand.TabIndex = 1;
        flowBrand.WrapContents = false;
        // 
        // lblBrandPkg
        // 
        lblBrandPkg.AutoSize = true;
        lblBrandPkg.Font = new Font("Bahnschrift SemiBold", 15.75F);
        lblBrandPkg.Location = new Point(0, 0);
        lblBrandPkg.Margin = new Padding(0);
        lblBrandPkg.Name = "lblBrandPkg";
        lblBrandPkg.Size = new Size(86, 25);
        lblBrandPkg.TabIndex = 0;
        lblBrandPkg.Text = "TELLUS";
        // 
        // lblBrandSlash
        // 
        lblBrandSlash.AutoSize = true;
        lblBrandSlash.Font = new Font("Bahnschrift SemiBold", 15.75F);
        lblBrandSlash.ForeColor = Color.FromArgb(0, 179, 255);
        lblBrandSlash.Location = new Point(86, 0);
        lblBrandSlash.Margin = new Padding(0);
        lblBrandSlash.Name = "lblBrandSlash";
        lblBrandSlash.Size = new Size(20, 25);
        lblBrandSlash.TabIndex = 1;
        lblBrandSlash.Text = "/";
        // 
        // lblBrandForge
        // 
        lblBrandForge.AutoSize = true;
        lblBrandForge.Font = new Font("Bahnschrift SemiBold", 15.75F);
        lblBrandForge.Location = new Point(106, 0);
        lblBrandForge.Margin = new Padding(0);
        lblBrandForge.Name = "lblBrandForge";
        lblBrandForge.Size = new Size(84, 25);
        lblBrandForge.TabIndex = 2;
        lblBrandForge.Text = "POWER";
        // 
        // lblLogo
        // 
        lblLogo.BackColor = Color.FromArgb(0, 112, 209);
        lblLogo.Font = new Font("Segoe MDL2 Assets", 12F);
        lblLogo.ForeColor = Color.White;
        lblLogo.Location = new Point(18, 16);
        lblLogo.Name = "lblLogo";
        lblLogo.Size = new Size(28, 28);
        lblLogo.TabIndex = 0;
        lblLogo.Text = "";
        lblLogo.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // tblZones
        // 
        tblZones.ColumnCount = 2;
        tblZones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tblZones.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
        tblZones.Controls.Add(pnlExtractBorder, 0, 0);
        tblZones.Controls.Add(pnlRepackBorder, 1, 0);
        tblZones.Dock = DockStyle.Top;
        tblZones.Location = new Point(0, 60);
        tblZones.Name = "tblZones";
        tblZones.Padding = new Padding(12, 0, 12, 0);
        tblZones.RowCount = 1;
        tblZones.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tblZones.Size = new Size(580, 192);
        tblZones.TabIndex = 1;
        // 
        // pnlExtractBorder
        // 
        pnlExtractBorder.BackColor = Color.FromArgb(32, 36, 47);
        pnlExtractBorder.Controls.Add(pnlExtractZone);
        pnlExtractBorder.Dock = DockStyle.Fill;
        pnlExtractBorder.Location = new Point(18, 0);
        pnlExtractBorder.Margin = new Padding(6, 0, 6, 0);
        pnlExtractBorder.Name = "pnlExtractBorder";
        pnlExtractBorder.Padding = new Padding(1);
        pnlExtractBorder.Size = new Size(266, 192);
        pnlExtractBorder.TabIndex = 0;
        // 
        // pnlExtractZone
        // 
        pnlExtractZone.BackColor = Color.FromArgb(17, 19, 25);
        pnlExtractZone.Controls.Add(pnlExtractBusy);
        pnlExtractZone.Controls.Add(pnlExtractIdle);
        pnlExtractZone.Controls.Add(lblExtractHint);
        pnlExtractZone.Controls.Add(lblExtractTag);
        pnlExtractZone.Controls.Add(lblExtractTitle);
        pnlExtractZone.Dock = DockStyle.Fill;
        pnlExtractZone.Location = new Point(1, 1);
        pnlExtractZone.Name = "pnlExtractZone";
        pnlExtractZone.Padding = new Padding(16, 14, 16, 14);
        pnlExtractZone.Size = new Size(264, 190);
        pnlExtractZone.TabIndex = 0;
        // 
        // pnlExtractBusy
        // 
        pnlExtractBusy.Controls.Add(flowExtractNumbers);
        pnlExtractBusy.Controls.Add(lblExtractFile);
        pnlExtractBusy.Controls.Add(pnlExtractTrack);
        pnlExtractBusy.Dock = DockStyle.Bottom;
        pnlExtractBusy.Location = new Point(16, 50);
        pnlExtractBusy.Name = "pnlExtractBusy";
        pnlExtractBusy.Size = new Size(232, 66);
        pnlExtractBusy.TabIndex = 4;
        pnlExtractBusy.Visible = false;
        // 
        // flowExtractNumbers
        // 
        flowExtractNumbers.Controls.Add(lblExtractPercent);
        flowExtractNumbers.Controls.Add(lblExtractCount);
        flowExtractNumbers.Dock = DockStyle.Top;
        flowExtractNumbers.Location = new Point(0, 18);
        flowExtractNumbers.Name = "flowExtractNumbers";
        flowExtractNumbers.Size = new Size(232, 38);
        flowExtractNumbers.TabIndex = 1;
        flowExtractNumbers.WrapContents = false;
        // 
        // lblExtractPercent
        // 
        lblExtractPercent.AutoSize = true;
        lblExtractPercent.Font = new Font("Bahnschrift SemiBold", 20.25F);
        lblExtractPercent.ForeColor = Color.FromArgb(0, 179, 255);
        lblExtractPercent.Location = new Point(0, 0);
        lblExtractPercent.Margin = new Padding(0);
        lblExtractPercent.Name = "lblExtractPercent";
        lblExtractPercent.Size = new Size(49, 33);
        lblExtractPercent.TabIndex = 0;
        lblExtractPercent.Text = "0%";
        // 
        // lblExtractCount
        // 
        lblExtractCount.AutoSize = true;
        lblExtractCount.ForeColor = Color.FromArgb(124, 131, 150);
        lblExtractCount.Location = new Point(55, 14);
        lblExtractCount.Margin = new Padding(6, 14, 0, 0);
        lblExtractCount.Name = "lblExtractCount";
        lblExtractCount.Size = new Size(54, 15);
        lblExtractCount.TabIndex = 1;
        lblExtractCount.Text = "0 / 0 files";
        // 
        // lblExtractFile
        // 
        lblExtractFile.AutoEllipsis = true;
        lblExtractFile.Dock = DockStyle.Top;
        lblExtractFile.ForeColor = Color.FromArgb(124, 131, 150);
        lblExtractFile.Location = new Point(0, 0);
        lblExtractFile.Name = "lblExtractFile";
        lblExtractFile.Size = new Size(232, 18);
        lblExtractFile.TabIndex = 0;
        lblExtractFile.Text = "Game.pkg";
        // 
        // pnlExtractTrack
        // 
        pnlExtractTrack.BackColor = Color.FromArgb(28, 38, 51);
        pnlExtractTrack.Controls.Add(pnlExtractFill);
        pnlExtractTrack.Dock = DockStyle.Bottom;
        pnlExtractTrack.Location = new Point(0, 62);
        pnlExtractTrack.Name = "pnlExtractTrack";
        pnlExtractTrack.Size = new Size(232, 4);
        pnlExtractTrack.TabIndex = 2;
        pnlExtractTrack.Resize += ExtractTrack_Resize;
        // 
        // pnlExtractFill
        // 
        pnlExtractFill.BackColor = Color.FromArgb(0, 179, 255);
        pnlExtractFill.Dock = DockStyle.Left;
        pnlExtractFill.Location = new Point(0, 0);
        pnlExtractFill.Name = "pnlExtractFill";
        pnlExtractFill.Size = new Size(0, 4);
        pnlExtractFill.TabIndex = 0;
        // 
        // pnlExtractIdle
        // 
        pnlExtractIdle.Controls.Add(lblExtractIcon);
        pnlExtractIdle.Controls.Add(lblExtractStatus);
        pnlExtractIdle.Dock = DockStyle.Bottom;
        pnlExtractIdle.Location = new Point(16, 116);
        pnlExtractIdle.Name = "pnlExtractIdle";
        pnlExtractIdle.Size = new Size(232, 60);
        pnlExtractIdle.TabIndex = 3;
        // 
        // lblExtractIcon
        // 
        lblExtractIcon.Font = new Font("Segoe MDL2 Assets", 18F);
        lblExtractIcon.ForeColor = Color.FromArgb(0, 179, 255);
        lblExtractIcon.Location = new Point(0, 0);
        lblExtractIcon.Name = "lblExtractIcon";
        lblExtractIcon.Size = new Size(40, 36);
        lblExtractIcon.TabIndex = 0;
        lblExtractIcon.Text = "";
        lblExtractIcon.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblExtractStatus
        // 
        lblExtractStatus.AutoEllipsis = true;
        lblExtractStatus.Dock = DockStyle.Bottom;
        lblExtractStatus.ForeColor = Color.FromArgb(124, 131, 150);
        lblExtractStatus.Location = new Point(0, 40);
        lblExtractStatus.Name = "lblExtractStatus";
        lblExtractStatus.Size = new Size(232, 20);
        lblExtractStatus.TabIndex = 1;
        lblExtractStatus.Text = "Extraction starts automatically";
        lblExtractStatus.TextAlign = ContentAlignment.BottomLeft;
        // 
        // lblExtractHint
        // 
        lblExtractHint.AutoSize = true;
        lblExtractHint.ForeColor = Color.FromArgb(124, 131, 150);
        lblExtractHint.Location = new Point(16, 36);
        lblExtractHint.Name = "lblExtractHint";
        lblExtractHint.Size = new Size(83, 15);
        lblExtractHint.TabIndex = 2;
        lblExtractHint.Text = "Drop .pkg files";
        // 
        // lblExtractTag
        // 
        lblExtractTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblExtractTag.BackColor = Color.FromArgb(28, 31, 40);
        lblExtractTag.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
        lblExtractTag.ForeColor = Color.FromArgb(124, 131, 150);
        lblExtractTag.Location = new Point(176, 14);
        lblExtractTag.Name = "lblExtractTag";
        lblExtractTag.Size = new Size(72, 20);
        lblExtractTag.TabIndex = 1;
        lblExtractTag.Text = "READY";
        lblExtractTag.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblExtractTitle
        // 
        lblExtractTitle.AutoSize = true;
        lblExtractTitle.Font = new Font("Bahnschrift SemiBold", 11.25F);
        lblExtractTitle.Location = new Point(16, 14);
        lblExtractTitle.Name = "lblExtractTitle";
        lblExtractTitle.Size = new Size(69, 18);
        lblExtractTitle.TabIndex = 0;
        lblExtractTitle.Text = "EXTRACT";
        // 
        // pnlRepackBorder
        // 
        pnlRepackBorder.BackColor = Color.FromArgb(32, 36, 47);
        pnlRepackBorder.Controls.Add(pnlRepackZone);
        pnlRepackBorder.Dock = DockStyle.Fill;
        pnlRepackBorder.Location = new Point(296, 0);
        pnlRepackBorder.Margin = new Padding(6, 0, 6, 0);
        pnlRepackBorder.Name = "pnlRepackBorder";
        pnlRepackBorder.Padding = new Padding(1);
        pnlRepackBorder.Size = new Size(266, 192);
        pnlRepackBorder.TabIndex = 1;
        // 
        // pnlRepackZone
        // 
        pnlRepackZone.BackColor = Color.FromArgb(17, 19, 25);
        pnlRepackZone.Controls.Add(pnlRepackBusy);
        pnlRepackZone.Controls.Add(pnlRepackIdle);
        pnlRepackZone.Controls.Add(lblRepackHint);
        pnlRepackZone.Controls.Add(lblRepackTag);
        pnlRepackZone.Controls.Add(lblRepackTitle);
        pnlRepackZone.Dock = DockStyle.Fill;
        pnlRepackZone.Location = new Point(1, 1);
        pnlRepackZone.Name = "pnlRepackZone";
        pnlRepackZone.Padding = new Padding(16, 14, 16, 14);
        pnlRepackZone.Size = new Size(264, 190);
        pnlRepackZone.TabIndex = 0;
        // 
        // pnlRepackBusy
        // 
        pnlRepackBusy.Controls.Add(flowRepackNumbers);
        pnlRepackBusy.Controls.Add(lblRepackFile);
        pnlRepackBusy.Controls.Add(pnlRepackTrack);
        pnlRepackBusy.Dock = DockStyle.Bottom;
        pnlRepackBusy.Location = new Point(16, 50);
        pnlRepackBusy.Name = "pnlRepackBusy";
        pnlRepackBusy.Size = new Size(232, 66);
        pnlRepackBusy.TabIndex = 4;
        pnlRepackBusy.Visible = false;
        // 
        // flowRepackNumbers
        // 
        flowRepackNumbers.Controls.Add(lblRepackElapsed);
        flowRepackNumbers.Controls.Add(lblRepackStage);
        flowRepackNumbers.Dock = DockStyle.Top;
        flowRepackNumbers.Location = new Point(0, 18);
        flowRepackNumbers.Name = "flowRepackNumbers";
        flowRepackNumbers.Size = new Size(232, 38);
        flowRepackNumbers.TabIndex = 1;
        flowRepackNumbers.WrapContents = false;
        // 
        // lblRepackElapsed
        // 
        lblRepackElapsed.AutoSize = true;
        lblRepackElapsed.Font = new Font("Bahnschrift SemiBold", 20.25F);
        lblRepackElapsed.ForeColor = Color.FromArgb(0, 179, 255);
        lblRepackElapsed.Location = new Point(0, 0);
        lblRepackElapsed.Margin = new Padding(0);
        lblRepackElapsed.Name = "lblRepackElapsed";
        lblRepackElapsed.Size = new Size(63, 33);
        lblRepackElapsed.TabIndex = 0;
        lblRepackElapsed.Text = "0:00";
        // 
        // lblRepackStage
        // 
        lblRepackStage.AutoSize = true;
        lblRepackStage.ForeColor = Color.FromArgb(124, 131, 150);
        lblRepackStage.Location = new Point(69, 14);
        lblRepackStage.Margin = new Padding(6, 14, 0, 0);
        lblRepackStage.Name = "lblRepackStage";
        lblRepackStage.Size = new Size(75, 15);
        lblRepackStage.TabIndex = 1;
        lblRepackStage.Text = "Building PKG";
        // 
        // lblRepackFile
        // 
        lblRepackFile.AutoEllipsis = true;
        lblRepackFile.Dock = DockStyle.Top;
        lblRepackFile.ForeColor = Color.FromArgb(124, 131, 150);
        lblRepackFile.Location = new Point(0, 0);
        lblRepackFile.Name = "lblRepackFile";
        lblRepackFile.Size = new Size(232, 18);
        lblRepackFile.TabIndex = 0;
        lblRepackFile.Text = "Game folder";
        // 
        // pnlRepackTrack
        // 
        pnlRepackTrack.BackColor = Color.FromArgb(28, 38, 51);
        pnlRepackTrack.Controls.Add(pnlRepackFill);
        pnlRepackTrack.Dock = DockStyle.Bottom;
        pnlRepackTrack.Location = new Point(0, 62);
        pnlRepackTrack.Name = "pnlRepackTrack";
        pnlRepackTrack.Size = new Size(232, 4);
        pnlRepackTrack.TabIndex = 2;
        // 
        // pnlRepackFill
        // 
        pnlRepackFill.BackColor = Color.FromArgb(0, 179, 255);
        pnlRepackFill.Location = new Point(0, 0);
        pnlRepackFill.Name = "pnlRepackFill";
        pnlRepackFill.Size = new Size(70, 4);
        pnlRepackFill.TabIndex = 0;
        // 
        // pnlRepackIdle
        // 
        pnlRepackIdle.Controls.Add(lblRepackIcon);
        pnlRepackIdle.Controls.Add(lblRepackStatus);
        pnlRepackIdle.Dock = DockStyle.Bottom;
        pnlRepackIdle.Location = new Point(16, 116);
        pnlRepackIdle.Name = "pnlRepackIdle";
        pnlRepackIdle.Size = new Size(232, 60);
        pnlRepackIdle.TabIndex = 3;
        // 
        // lblRepackIcon
        // 
        lblRepackIcon.Font = new Font("Segoe MDL2 Assets", 18F);
        lblRepackIcon.ForeColor = Color.FromArgb(0, 179, 255);
        lblRepackIcon.Location = new Point(0, 0);
        lblRepackIcon.Name = "lblRepackIcon";
        lblRepackIcon.Size = new Size(40, 36);
        lblRepackIcon.TabIndex = 0;
        lblRepackIcon.Text = "";
        lblRepackIcon.TextAlign = ContentAlignment.MiddleLeft;
        // 
        // lblRepackStatus
        // 
        lblRepackStatus.AutoEllipsis = true;
        lblRepackStatus.Dock = DockStyle.Bottom;
        lblRepackStatus.ForeColor = Color.FromArgb(124, 131, 150);
        lblRepackStatus.Location = new Point(0, 40);
        lblRepackStatus.Name = "lblRepackStatus";
        lblRepackStatus.Size = new Size(232, 20);
        lblRepackStatus.TabIndex = 1;
        lblRepackStatus.Text = "GP4 project is generated automatically";
        lblRepackStatus.TextAlign = ContentAlignment.BottomLeft;
        // 
        // lblRepackHint
        // 
        lblRepackHint.AutoSize = true;
        lblRepackHint.ForeColor = Color.FromArgb(124, 131, 150);
        lblRepackHint.Location = new Point(16, 36);
        lblRepackHint.Name = "lblRepackHint";
        lblRepackHint.Size = new Size(135, 15);
        lblRepackHint.TabIndex = 2;
        lblRepackHint.Text = "Drop an extracted folder";
        // 
        // lblRepackTag
        // 
        lblRepackTag.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblRepackTag.BackColor = Color.FromArgb(28, 31, 40);
        lblRepackTag.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
        lblRepackTag.ForeColor = Color.FromArgb(124, 131, 150);
        lblRepackTag.Location = new Point(176, 14);
        lblRepackTag.Name = "lblRepackTag";
        lblRepackTag.Size = new Size(72, 20);
        lblRepackTag.TabIndex = 1;
        lblRepackTag.Text = "READY";
        lblRepackTag.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // lblRepackTitle
        // 
        lblRepackTitle.AutoSize = true;
        lblRepackTitle.Font = new Font("Bahnschrift SemiBold", 11.25F);
        lblRepackTitle.Location = new Point(16, 14);
        lblRepackTitle.Name = "lblRepackTitle";
        lblRepackTitle.Size = new Size(63, 18);
        lblRepackTitle.TabIndex = 0;
        lblRepackTitle.Text = "REPACK";
        // 
        // pnlConsole
        // 
        pnlConsole.Controls.Add(txtLog);
        pnlConsole.Controls.Add(pnlConsoleHeader);
        pnlConsole.Controls.Add(pnlConsoleLine);
        pnlConsole.Dock = DockStyle.Fill;
        pnlConsole.Location = new Point(0, 252);
        pnlConsole.Name = "pnlConsole";
        pnlConsole.Padding = new Padding(18, 14, 18, 6);
        pnlConsole.Size = new Size(580, 156);
        pnlConsole.TabIndex = 2;
        // 
        // txtLog
        // 
        txtLog.BackColor = Color.FromArgb(10, 11, 15);
        txtLog.BorderStyle = BorderStyle.None;
        txtLog.DetectUrls = false;
        txtLog.Dock = DockStyle.Fill;
        txtLog.Font = new Font("Consolas", 9F);
        txtLog.ForeColor = Color.FromArgb(138, 144, 162);
        txtLog.Location = new Point(18, 45);
        txtLog.Name = "txtLog";
        txtLog.ReadOnly = true;
        txtLog.ScrollBars = RichTextBoxScrollBars.Vertical;
        txtLog.Size = new Size(544, 105);
        txtLog.TabIndex = 2;
        txtLog.Text = "";
        // 
        // pnlConsoleHeader
        // 
        pnlConsoleHeader.Controls.Add(flowConsoleLinks);
        pnlConsoleHeader.Controls.Add(lblConsoleTitle);
        pnlConsoleHeader.Dock = DockStyle.Top;
        pnlConsoleHeader.Location = new Point(18, 15);
        pnlConsoleHeader.Name = "pnlConsoleHeader";
        pnlConsoleHeader.Size = new Size(544, 30);
        pnlConsoleHeader.TabIndex = 1;
        // 
        // flowConsoleLinks
        // 
        flowConsoleLinks.AutoSize = true;
        flowConsoleLinks.Controls.Add(lnkOpenFolder);
        flowConsoleLinks.Controls.Add(lnkClear);
        flowConsoleLinks.Dock = DockStyle.Right;
        flowConsoleLinks.Location = new Point(425, 0);
        flowConsoleLinks.Name = "flowConsoleLinks";
        flowConsoleLinks.Padding = new Padding(0, 8, 0, 0);
        flowConsoleLinks.Size = new Size(119, 30);
        flowConsoleLinks.TabIndex = 1;
        flowConsoleLinks.WrapContents = false;
        // 
        // lnkOpenFolder
        // 
        lnkOpenFolder.ActiveLinkColor = Color.FromArgb(128, 217, 255);
        lnkOpenFolder.AutoSize = true;
        lnkOpenFolder.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
        lnkOpenFolder.LinkBehavior = LinkBehavior.NeverUnderline;
        lnkOpenFolder.LinkColor = Color.FromArgb(0, 179, 255);
        lnkOpenFolder.Location = new Point(0, 8);
        lnkOpenFolder.Margin = new Padding(0);
        lnkOpenFolder.Name = "lnkOpenFolder";
        lnkOpenFolder.Size = new Size(72, 12);
        lnkOpenFolder.TabIndex = 0;
        lnkOpenFolder.TabStop = true;
        lnkOpenFolder.Text = "OPEN FOLDER";
        lnkOpenFolder.VisitedLinkColor = Color.FromArgb(0, 179, 255);
        lnkOpenFolder.LinkClicked += OpenFolder_LinkClicked;
        // 
        // lnkClear
        // 
        lnkClear.ActiveLinkColor = Color.FromArgb(128, 217, 255);
        lnkClear.AutoSize = true;
        lnkClear.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
        lnkClear.LinkBehavior = LinkBehavior.NeverUnderline;
        lnkClear.LinkColor = Color.FromArgb(0, 179, 255);
        lnkClear.Location = new Point(84, 8);
        lnkClear.Margin = new Padding(12, 0, 0, 0);
        lnkClear.Name = "lnkClear";
        lnkClear.Size = new Size(35, 12);
        lnkClear.TabIndex = 1;
        lnkClear.TabStop = true;
        lnkClear.Text = "CLEAR";
        lnkClear.VisitedLinkColor = Color.FromArgb(0, 179, 255);
        lnkClear.LinkClicked += Clear_LinkClicked;
        // 
        // lblConsoleTitle
        // 
        lblConsoleTitle.AutoSize = true;
        lblConsoleTitle.Font = new Font("Segoe UI", 7.5F, FontStyle.Bold);
        lblConsoleTitle.ForeColor = Color.FromArgb(91, 98, 117);
        lblConsoleTitle.Location = new Point(0, 8);
        lblConsoleTitle.Name = "lblConsoleTitle";
        lblConsoleTitle.Size = new Size(51, 12);
        lblConsoleTitle.TabIndex = 0;
        lblConsoleTitle.Text = "CONSOLE";
        // 
        // pnlConsoleLine
        // 
        pnlConsoleLine.BackColor = Color.FromArgb(32, 36, 47);
        pnlConsoleLine.Dock = DockStyle.Top;
        pnlConsoleLine.Location = new Point(18, 14);
        pnlConsoleLine.Name = "pnlConsoleLine";
        pnlConsoleLine.Size = new Size(544, 1);
        pnlConsoleLine.TabIndex = 0;
        // 
        // pnlFooter
        // 
        pnlFooter.Controls.Add(lblFooterHint);
        pnlFooter.Controls.Add(flowFooterStats);
        pnlFooter.Controls.Add(pnlFooterLine);
        pnlFooter.Dock = DockStyle.Bottom;
        pnlFooter.Location = new Point(0, 408);
        pnlFooter.Name = "pnlFooter";
        pnlFooter.Size = new Size(580, 32);
        pnlFooter.TabIndex = 3;
        // 
        // lblFooterHint
        // 
        lblFooterHint.Anchor = AnchorStyles.Top | AnchorStyles.Right;
        lblFooterHint.Font = new Font("Segoe UI", 8.25F);
        lblFooterHint.ForeColor = Color.FromArgb(91, 98, 117);
        lblFooterHint.Location = new Point(262, 8);
        lblFooterHint.Name = "lblFooterHint";
        lblFooterHint.Size = new Size(300, 16);
        lblFooterHint.TabIndex = 2;
        lblFooterHint.Text = "Drop anywhere — files go to the right zone";
        lblFooterHint.TextAlign = ContentAlignment.MiddleRight;
        // 
        // flowFooterStats
        // 
        flowFooterStats.AutoSize = true;
        flowFooterStats.Controls.Add(lblQueueCaption);
        flowFooterStats.Controls.Add(lblQueueValue);
        flowFooterStats.Controls.Add(lblDoneCaption);
        flowFooterStats.Controls.Add(lblDoneValue);
        flowFooterStats.Controls.Add(lblErrorsCaption);
        flowFooterStats.Controls.Add(lblErrorsValue);
        flowFooterStats.Location = new Point(18, 9);
        flowFooterStats.Name = "flowFooterStats";
        flowFooterStats.Size = new Size(200, 15);
        flowFooterStats.TabIndex = 1;
        flowFooterStats.WrapContents = false;
        // 
        // lblQueueCaption
        // 
        lblQueueCaption.AutoSize = true;
        lblQueueCaption.Font = new Font("Segoe UI", 8.25F);
        lblQueueCaption.ForeColor = Color.FromArgb(91, 98, 117);
        lblQueueCaption.Location = new Point(0, 0);
        lblQueueCaption.Margin = new Padding(0);
        lblQueueCaption.Name = "lblQueueCaption";
        lblQueueCaption.Size = new Size(41, 13);
        lblQueueCaption.TabIndex = 0;
        lblQueueCaption.Text = "Queue";
        // 
        // lblQueueValue
        // 
        lblQueueValue.AutoSize = true;
        lblQueueValue.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblQueueValue.Location = new Point(41, 0);
        lblQueueValue.Margin = new Padding(0, 0, 16, 0);
        lblQueueValue.Name = "lblQueueValue";
        lblQueueValue.Size = new Size(13, 13);
        lblQueueValue.TabIndex = 1;
        lblQueueValue.Text = "0";
        // 
        // lblDoneCaption
        // 
        lblDoneCaption.AutoSize = true;
        lblDoneCaption.Font = new Font("Segoe UI", 8.25F);
        lblDoneCaption.ForeColor = Color.FromArgb(91, 98, 117);
        lblDoneCaption.Location = new Point(70, 0);
        lblDoneCaption.Margin = new Padding(0);
        lblDoneCaption.Name = "lblDoneCaption";
        lblDoneCaption.Size = new Size(35, 13);
        lblDoneCaption.TabIndex = 2;
        lblDoneCaption.Text = "Done";
        // 
        // lblDoneValue
        // 
        lblDoneValue.AutoSize = true;
        lblDoneValue.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblDoneValue.ForeColor = Color.FromArgb(61, 220, 151);
        lblDoneValue.Location = new Point(105, 0);
        lblDoneValue.Margin = new Padding(0, 0, 16, 0);
        lblDoneValue.Name = "lblDoneValue";
        lblDoneValue.Size = new Size(13, 13);
        lblDoneValue.TabIndex = 3;
        lblDoneValue.Text = "0";
        // 
        // lblErrorsCaption
        // 
        lblErrorsCaption.AutoSize = true;
        lblErrorsCaption.Font = new Font("Segoe UI", 8.25F);
        lblErrorsCaption.ForeColor = Color.FromArgb(91, 98, 117);
        lblErrorsCaption.Location = new Point(134, 0);
        lblErrorsCaption.Margin = new Padding(0);
        lblErrorsCaption.Name = "lblErrorsCaption";
        lblErrorsCaption.Size = new Size(37, 13);
        lblErrorsCaption.TabIndex = 4;
        lblErrorsCaption.Text = "Errors";
        // 
        // lblErrorsValue
        // 
        lblErrorsValue.AutoSize = true;
        lblErrorsValue.Font = new Font("Segoe UI", 8.25F, FontStyle.Bold);
        lblErrorsValue.ForeColor = Color.FromArgb(255, 90, 110);
        lblErrorsValue.Location = new Point(171, 0);
        lblErrorsValue.Margin = new Padding(0);
        lblErrorsValue.Name = "lblErrorsValue";
        lblErrorsValue.Size = new Size(13, 13);
        lblErrorsValue.TabIndex = 5;
        lblErrorsValue.Text = "0";
        // 
        // pnlFooterLine
        // 
        pnlFooterLine.BackColor = Color.FromArgb(21, 24, 31);
        pnlFooterLine.Dock = DockStyle.Top;
        pnlFooterLine.Location = new Point(0, 0);
        pnlFooterLine.Name = "pnlFooterLine";
        pnlFooterLine.Size = new Size(580, 1);
        pnlFooterLine.TabIndex = 0;
        // 
        // repackTimer
        // 
        repackTimer.Interval = 30;
        repackTimer.Tick += RepackTimer_Tick;
        // 
        // MainForm
        // 
        AllowDrop = true;
        AutoScaleDimensions = new SizeF(96F, 96F);
        AutoScaleMode = AutoScaleMode.Dpi;
        BackColor = Color.FromArgb(10, 11, 15);
        ClientSize = new Size(580, 440);
        Controls.Add(pnlConsole);
        Controls.Add(pnlFooter);
        Controls.Add(tblZones);
        Controls.Add(pnlHeader);
        Font = new Font("Segoe UI", 9F);
        ForeColor = Color.FromArgb(236, 239, 245);
        Icon = (Icon)resources.GetObject("$this.Icon");
        MinimumSize = new Size(560, 420);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "TELLUS - AUTO EXTRACT REPACK";
        FormClosing += MainForm_FormClosing;
        Load += MainForm_Load;
        DragDrop += OnDragDrop;
        DragEnter += OnDragEnter;
        DragLeave += OnDragLeave;
        pnlHeader.ResumeLayout(false);
        pnlHeader.PerformLayout();
        flowBrand.ResumeLayout(false);
        flowBrand.PerformLayout();
        tblZones.ResumeLayout(false);
        pnlExtractBorder.ResumeLayout(false);
        pnlExtractZone.ResumeLayout(false);
        pnlExtractZone.PerformLayout();
        pnlExtractBusy.ResumeLayout(false);
        flowExtractNumbers.ResumeLayout(false);
        flowExtractNumbers.PerformLayout();
        pnlExtractTrack.ResumeLayout(false);
        pnlExtractIdle.ResumeLayout(false);
        pnlRepackBorder.ResumeLayout(false);
        pnlRepackZone.ResumeLayout(false);
        pnlRepackZone.PerformLayout();
        pnlRepackBusy.ResumeLayout(false);
        flowRepackNumbers.ResumeLayout(false);
        flowRepackNumbers.PerformLayout();
        pnlRepackTrack.ResumeLayout(false);
        pnlRepackIdle.ResumeLayout(false);
        pnlConsole.ResumeLayout(false);
        pnlConsoleHeader.ResumeLayout(false);
        pnlConsoleHeader.PerformLayout();
        flowConsoleLinks.ResumeLayout(false);
        flowConsoleLinks.PerformLayout();
        pnlFooter.ResumeLayout(false);
        pnlFooter.PerformLayout();
        flowFooterStats.ResumeLayout(false);
        flowFooterStats.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private System.Windows.Forms.Panel pnlHeader;
    private System.Windows.Forms.Label lblLogo;
    private System.Windows.Forms.FlowLayoutPanel flowBrand;
    private System.Windows.Forms.Label lblBrandPkg;
    private System.Windows.Forms.Label lblBrandSlash;
    private System.Windows.Forms.Label lblBrandForge;
    private System.Windows.Forms.Label lblPlatform;
    private System.Windows.Forms.TableLayoutPanel tblZones;
    private System.Windows.Forms.Panel pnlExtractBorder;
    private System.Windows.Forms.Panel pnlExtractZone;
    private System.Windows.Forms.Label lblExtractTitle;
    private System.Windows.Forms.Label lblExtractTag;
    private System.Windows.Forms.Label lblExtractHint;
    private System.Windows.Forms.Panel pnlExtractBusy;
    private System.Windows.Forms.FlowLayoutPanel flowExtractNumbers;
    private System.Windows.Forms.Label lblExtractPercent;
    private System.Windows.Forms.Label lblExtractCount;
    private System.Windows.Forms.Label lblExtractFile;
    private System.Windows.Forms.Panel pnlExtractTrack;
    private System.Windows.Forms.Panel pnlExtractFill;
    private System.Windows.Forms.Panel pnlExtractIdle;
    private System.Windows.Forms.Label lblExtractIcon;
    private System.Windows.Forms.Label lblExtractStatus;
    private System.Windows.Forms.Panel pnlRepackBorder;
    private System.Windows.Forms.Panel pnlRepackZone;
    private System.Windows.Forms.Label lblRepackTitle;
    private System.Windows.Forms.Label lblRepackTag;
    private System.Windows.Forms.Label lblRepackHint;
    private System.Windows.Forms.Panel pnlRepackBusy;
    private System.Windows.Forms.FlowLayoutPanel flowRepackNumbers;
    private System.Windows.Forms.Label lblRepackElapsed;
    private System.Windows.Forms.Label lblRepackStage;
    private System.Windows.Forms.Label lblRepackFile;
    private System.Windows.Forms.Panel pnlRepackTrack;
    private System.Windows.Forms.Panel pnlRepackFill;
    private System.Windows.Forms.Panel pnlRepackIdle;
    private System.Windows.Forms.Label lblRepackIcon;
    private System.Windows.Forms.Label lblRepackStatus;
    private System.Windows.Forms.Panel pnlConsole;
    private System.Windows.Forms.RichTextBox txtLog;
    private System.Windows.Forms.Panel pnlConsoleHeader;
    private System.Windows.Forms.Label lblConsoleTitle;
    private System.Windows.Forms.FlowLayoutPanel flowConsoleLinks;
    private System.Windows.Forms.LinkLabel lnkOpenFolder;
    private System.Windows.Forms.LinkLabel lnkClear;
    private System.Windows.Forms.Panel pnlConsoleLine;
    private System.Windows.Forms.Panel pnlFooter;
    private System.Windows.Forms.FlowLayoutPanel flowFooterStats;
    private System.Windows.Forms.Label lblQueueCaption;
    private System.Windows.Forms.Label lblQueueValue;
    private System.Windows.Forms.Label lblDoneCaption;
    private System.Windows.Forms.Label lblDoneValue;
    private System.Windows.Forms.Label lblErrorsCaption;
    private System.Windows.Forms.Label lblErrorsValue;
    private System.Windows.Forms.Label lblFooterHint;
    private System.Windows.Forms.Panel pnlFooterLine;
    private System.Windows.Forms.Timer repackTimer;
}
