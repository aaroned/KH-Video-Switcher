using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JW_Library_Focuser
{
    internal static class ZoomLibHelper
    {
        private const string ZoomLibProcessName = "Zoom";        
        private const string MainWindowClassName = "ZPContentViewWndClass";
        private const string ZoomLibCaptionPrefix = "Zoom";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void BringToFront()
        {
            if (log.IsInfoEnabled) log.Info("Attempting to bring Zoom to front");
            BringToFront(ZoomLibProcessName);
        }

        public static void Minimize()
        {
            if (log.IsInfoEnabled) log.Info("Attempting to minimize Zoom");
            Minimize(ZoomLibProcessName);
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
                    if (sb.ToString().Equals(ZoomLibCaptionPrefix))
                    {
                        LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MAXIMIZE);
                        LibHelperNativeMethods.SetForegroundWindow(mainWindow);
                        if (log.IsInfoEnabled) log.Info($"{processName} window brought to foreground.");
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

        private static bool Minimize(string processName)
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
                    if (sb.ToString().Equals(ZoomLibCaptionPrefix))
                    {
                        LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MINIMIZE);
                        if (log.IsInfoEnabled) log.Info($"{processName} window minimized.");
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