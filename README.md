# TELLUS-Auto Extract Repack PKG
<img width="582" height="469" alt="image" src="https://github.com/user-attachments/assets/58a86f79-435e-4498-af90-1e711c8e324d" />

A drag-and-drop Windows Forms front end for extracting PS4 PKG dumps using the **OrbisPkgTool** C# library directly in-process.

## Behavior
- Drag one or more `.pkg` files onto the window.
- Drag a `.pkg` directly onto the compiled EXE; Windows passes it as a command-line argument and extraction starts automatically.
- No Extract button.
- No output-location prompt.
- Each package is extracted beside the source package:
  - `Game.pkg` -> `Game\`
  - if that exists -> `Game_extracted_1\`, then `_2`, etc.
- Multiple packages are queued and processed sequentially.
- Extraction progress is reported from OrbisPkgTool's per-file progress callback.
- The OrbisPkgTool library is compiled into the application; there is no `PkgTool.exe`/`PkgTool.Core.exe` dependency.

## Passcode
The app uses OrbisPkgTool's documented default all-zero 32-character passcode. This is not a claim that every PS4 PKG uses that passcode. If a particular package requires another passcode, the app would need a passcode-selection mechanism.

## Build
Requires the .NET 10 SDK on Windows.
```powershell
dotnet build -c Release
```
The solution is self-contained as source: `OrbisPkgTool\` is included as a project reference and builds into the WinForms application.

## Credits and Attributions

This project utilizes components from the following open-source software:
* **[OrbisPkg Tool / LibOrbisPkg](https://github.com)** - Developed by [maxton](https://github.com). Licensed under the [GNU Lesser General Public License v3.0 (LGPL-3.0)](https://github.com/blob/master/LICENSE).

### License Compliance
The bundled OrbisPkgTool source is distributed under the license included in `OrbisPkgTool\LICENSE`. 
Review the upstream license before redistributing a compiled application.

In accordance with the LGPL-3.0 license:
* The original, unmodified source code (or binary library) of OrbisPkg Tool was used.
* Any modifications made to the OrbisPkg library source code (if applicable) are made public under the same license terms.
* You can find a copy of the LGPL-3.0 license in our repository's [LICENSE](LINK_TO_YOUR_LICENSE_FILE) file.

