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

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void BringToFront()
        {
            try
            {
                if (log.IsInfoEnabled) log.Info("Attempting to bring JW Library to front");

                if (BringToFront(JwLibProcessName))
                {
                    if (log.IsInfoEnabled) log.Info("JW Library brough to front");
                }
                else
                {
                    if (log.IsInfoEnabled) log.Info("Attempting to bring JW Language to front");

                    if (BringToFront(JwLibSignLanguageProcessName))
                    {
                        if (log.IsInfoEnabled) log.Info("JW Language brought to front");
                    }
                    else
                    {
                        if (log.IsInfoEnabled) log.Info("Launching JW Library");
                        //Launch JW Library
                        //Process.Start(string.Format("https://www.jw.org/finder?srcid=jwlshare&wtlocale=E&prefer=lang&alias=meetings&date={0}", DateTime.Now.ToString("yyyyMMdd")));

                        // GUID taken from https://docs.microsoft.com/en-us/windows/win32/shell/knownfolderid
                        var FODLERID_AppsFolder = new Guid("{1e87508d-89c2-42f0-8a7e-645a0f50ca58}");
                        ShellObject appsFolder = (ShellObject)KnownFolderHelper.FromKnownFolderId(FODLERID_AppsFolder);

                        if (appsFolder == null)
                        {
                            if (log.IsInfoEnabled) log.Info("Apps Folder not found");
                            return;
                        }

                        var JWLibraryApp = ((IKnownFolder)appsFolder).Where(app => app.Name == "JW Library").FirstOrDefault();

                        if (JWLibraryApp == null)
                        {
                            if (log.IsInfoEnabled) log.Info("JW Library not found.");                            
                        }
                        else
                        {
                            if (log.IsInfoEnabled) log.Info($"Starting JW Library process: {JWLibraryApp.ParsingName}");
                            System.Diagnostics.Process.Start("explorer.exe", @" shell:appsFolder\" + JWLibraryApp.ParsingName);
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        private static bool BringToFront(string processName)
        {
            try
            {

                var p = Process.GetProcessesByName(processName).FirstOrDefault();
                if (p == null)
                {
                    if (log.IsInfoEnabled) log.Info($"Cannot find process: {processName}");
                    return false;
                }

                var desktopWindow = LibHelperNativeMethods.GetDesktopWindow();
                if (desktopWindow == IntPtr.Zero)
                {
                    if (log.IsInfoEnabled) log.Info("Cannot find desktop window.");
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
                        if (log.IsInfoEnabled) log.Info($"{processName} window brought to foreground.");
                        LibHelperNativeMethods.SetForegroundWindow(mainWindow);
                        found = true;
                    }

                    prevWindow = mainWindow;
                }

                if (!found)
                {
                    if (log.IsInfoEnabled) log.Info($"Cannot find window for process: {processName}");
                }

                return found;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }
    }
}