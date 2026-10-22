This folder is the SOURCE for the tools embedded into the compiled exe.

These files get embedded as resources inside PS4PkgAutoExtractor.exe at
build time (see the EmbeddedResource items in PS4PkgAutoExtractor.csproj)
and extracted to a per-user AppData folder the first time the app runs —
nothing but PS4PkgAutoExtractor.exe itself appears next to the exe in the
output folder.

Files expected here:
  PkgTool.Core.exe
  PkgTool.Core.dll
  LibOrbisPkg.Core.dll
  PkgTool.Core.deps.json
  PkgTool.Core.runtimeconfig.json
  orbis-pub-cmd.exe
  orbis-pub-prx.dll
  ext/di.exe
  ext/sc.exe
  ext/libatrac9.dll

orbis-pub-cmd.exe (PS4-Fake-PKG-Tools) is the one actually used for
building — it honors each file's pfs_compression setting, giving a
correctly-sized package. PkgTool.Core.exe (OpenOrbis/LibOrbisPkg) is kept
as a silent fallback in case orbis-pub-cmd.exe is ever missing.

If any of these files are absent when the project is built, the
EmbeddedResource entry for that file is simply skipped — the app still
builds, it just won't find that tool at runtime.
