using System;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace JW_Library_Focuser
{
    internal static class OnlyMLibHelper
    {
        private const string OnlyMLibProcessName = "OnlyM";        
        private const string OnlyMLibCaptionPrefix = "OnlyM Media Window";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void BringToFront()
        {
            if (log.IsInfoEnabled) log.Info("Attempting to bring OnlyM to front.");
            BringToFront(OnlyMLibProcessName);
        }

        public static void Minimize()
        {
            if (log.IsInfoEnabled) log.Info("Attempting to minimize OnlyM.");
            Minimize(OnlyMLibProcessName);
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

                var mainWindow = LibHelperNativeMethods.FindWindowEx(desktopWindow, IntPtr.Zero, null, OnlyMLibCaptionPrefix);
                if (mainWindow == IntPtr.Zero)
                {
                    if (log.IsInfoEnabled) log.Info($"Cannot find OnlyM window: {OnlyMLibCaptionPrefix}");
                    return false;
                }

                LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MAXIMIZE);
                LibHelperNativeMethods.SetForegroundWindow(mainWindow);
                if (log.IsInfoEnabled) log.Info($"{processName} window brought to foreground.");
                return true;
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

                var mainWindow = LibHelperNativeMethods.FindWindowEx(desktopWindow, IntPtr.Zero, null, OnlyMLibCaptionPrefix);
                if (mainWindow == IntPtr.Zero)
                {
                    if (log.IsInfoEnabled) log.Info($"Cannot find OnlyM window: {OnlyMLibCaptionPrefix}");
                    return false;
                }

                LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MINIMIZE);
                if (log.IsInfoEnabled) log.Info($"{processName} window minimized.");
                return true;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }
    }
}