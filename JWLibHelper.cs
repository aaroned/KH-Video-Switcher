using Microsoft.WindowsAPICodePack.Shell;
using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JW_Library_Focuser
{
    internal static class JwLibHelper
    {
        private const string JwLibProcessName = "JWLibrary";
        private const string JwLibSignLanguageProcessName = "JWLibrary.Forms.UWP";
        private const string MainWindowClassName = "ApplicationFrameWindow";
        private const string JwLibCaptionPrefix = "JW Library";

        public static void BringToFront()
        {
            if (!BringToFront(JwLibProcessName))
            {
                if (!BringToFront(JwLibSignLanguageProcessName))
                {
                    //Launch JW Library
                    //Process.Start(string.Format("https://www.jw.org/finder?srcid=jwlshare&wtlocale=E&prefer=lang&alias=meetings&date={0}", DateTime.Now.ToString("yyyyMMdd")));
                    
                    // GUID taken from https://docs.microsoft.com/en-us/windows/win32/shell/knownfolderid
                    var FODLERID_AppsFolder = new Guid("{1e87508d-89c2-42f0-8a7e-645a0f50ca58}");
                    ShellObject appsFolder = (ShellObject)KnownFolderHelper.FromKnownFolderId(FODLERID_AppsFolder);
                    var JWLibraryApp = ((IKnownFolder)appsFolder).Where(app => app.Name =="JW Library").FirstOrDefault();

                    if(JWLibraryApp != null)
                        System.Diagnostics.Process.Start("explorer.exe", @" shell:appsFolder\" + JWLibraryApp.ParsingName);

                    //foreach (var app in (IKnownFolder)appsFolder)
                    //{
                    //    // The friendly app name
                    //    string name = app.Name;
                    //    // The ParsingName property is the AppUserModelID
                    //    string appUserModelID = app.ParsingName; // or app.Properties.System.AppUserModel.ID
                    //                                             // You can even get the Jumbo icon in one shot
                    //    ImageSource icon = app.Thumbnail.ExtraLargeBitmapSource;
                    //}
                }
            }
        }

        private static bool BringToFront(string processName)
        {
            var p = Process.GetProcessesByName(processName).FirstOrDefault();
            if (p == null)
            {
                return false;
            }

            var desktopWindow = LibHelperNativeMethods.GetDesktopWindow();
            if (desktopWindow == IntPtr.Zero)
            {
                return false;
            }

            bool found = false;
            var prevWindow = IntPtr.Zero;

            while (!found)
            {
                var mainWindow = LibHelperNativeMethods.FindWindowEx(desktopWindow, prevWindow, MainWindowClassName, null);
                if (mainWindow == IntPtr.Zero)
                {
                    break;
                }

                var sb = new StringBuilder(256);
                LibHelperNativeMethods.GetWindowText(mainWindow, sb, 256);
                if (sb.ToString().StartsWith(JwLibCaptionPrefix))
                {
                    LibHelperNativeMethods.SetForegroundWindow(mainWindow);
                    found = true;
                }

                prevWindow = mainWindow;
            }

            return found;
        }
    }
}