; KH Switcher Inno Setup Script
; SEE THE DOCUMENTATION FOR DETAILS ON CREATING INNO SETUP SCRIPT FILES!

#define MyAppName "KH Switcher"
#define MyAppVersion GetVersionNumbersString("..\bin\Release\KH Switcher.exe")
#define MyAppPublisher "KH Switcher"
#define MyAppURL "https://github.com/aaroned/KH-Video-Switcher"

[Setup]
AppId={{D9C82CF4-82FB-4203-90A1-0E7215BBC5C9}
AppName={#MyAppName}
AppVersion={#MyAppVersion}
AppPublisher={#MyAppPublisher}
AppPublisherURL={#MyAppURL}
DefaultDirName={autopf}\{#MyAppName}
DisableProgramGroupPage=yes
OutputBaseFilename={#MyAppName} {#MyAppVersion}
OutputDir=..\bin\Release\{#MyAppVersion}
SetupIconFile=..\src\Icon.ico
UninstallDisplayIcon={app}\KH Switcher.exe
Compression=lzma
SolidCompression=yes
WizardStyle=modern
PrivilegesRequired=admin

[Languages]
Name: "english"; MessagesFile: "compiler:Default.isl"

[Tasks]
Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}";

[Files]
; Install all files directly to the app root directory
Source: "..\bin\Release\*"; DestDir: "{app}"; Flags: ignoreversion 
Source: "..\bin\Release\config.bat"; DestDir: "{app}"; Flags: deleteafterinstall
; NOTE: Don't use "Flags: ignoreversion" on any shared system files

; Remove the old two-directory install layout.
; The [Code] section below copies the config files out first before these directories are deleted,
; so migration can still read the old settings on first launch after upgrade.
[InstallDelete]
Type: filesandordirs; Name: "{commonpf32}\KH Switcher\KH Switcher Media"
Type: filesandordirs; Name: "{commonpf32}\KH Switcher\KH Switcher Zoom"

[Components]
Name: "khMedia"; Description: "KH Switcher Media"; Types: full;
Name: "khZoom"; Description: "KH Switcher Zoom"; Types: full;

[Types]
Name: "full"; Description: "Full installation"
Name: "custom"; Description: "Custom installation"; Flags: iscustom

[Icons]
; Start menu shortcuts
Name: "{autoprograms}\{#MyAppName} Media"; Filename: "{app}\KH Switcher.exe"; Components: khMedia; Parameters: "--client false"; WorkingDir: "{app}";
Name: "{autoprograms}\{#MyAppName} Zoom"; Filename: "{app}\KH Switcher.exe"; Components: khZoom; Parameters: "--client true"; WorkingDir: "{app}";
; Desktop shortcuts
Name: "{autodesktop}\{#MyAppName} Media"; Filename: "{app}\KH Switcher.exe"; Components: khMedia; Parameters: "--client false"; WorkingDir: "{app}"; Tasks: desktopicon;
Name: "{autodesktop}\{#MyAppName} Zoom"; Filename: "{app}\KH Switcher.exe"; Components: khZoom; Parameters: "--client true"; WorkingDir: "{app}"; Tasks: desktopicon;

[Run]
Filename: "{app}\config.bat"; Flags: shellexec runhidden waituntilterminated

[Code]
procedure CurStepChanged(CurStep: TSetupStep);
var
  InstallDir: String;
begin
  if CurStep = ssInstall then
  begin
    InstallDir := ExpandConstant('{commonpf32}\KH Switcher');

    // Copy old server config if it exists, so migration can read it after
    // the KH Switcher Media directory is deleted by [InstallDelete]
    if FileExists(InstallDir + '\KH Switcher Media\KH Switcher.exe.config') then
      CopyFile(InstallDir + '\KH Switcher Media\KH Switcher.exe.config',
         ExpandConstant('{app}') + '\migration_server.config', False);



    // Copy old client config if it exists, so migration can read it after
    // the KH Switcher Zoom directory is deleted by [InstallDelete]
    if FileExists(InstallDir + '\KH Switcher Zoom\KH Switcher.exe.config') then
      CopyFile(InstallDir + '\KH Switcher Zoom\KH Switcher.exe.config',
         ExpandConstant('{app}') + '\migration_client.config', False);
  end;
end;
