using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;   
using System.Text;

namespace JW_Library_Focuser
{
    internal static class ZoomLibHelper
    {
        private const string ZoomLibProcessName = "Zoom";
        private const string MainWindowClassName = "ConfMultiTabContentWndClass";
        private const string ZoomLibCaptionPrefix = "Zoom Meeting";

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // Specify the monitor index to bring Zoom to front. (0 = primary, 1 = secondary, ect.)
        private static int TargetMonitorIndex = 1;
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

                // Get target monitor first
                IntPtr targetMonitor = GetMonitorByIndex(TargetMonitorIndex);
                if (targetMonitor == IntPtr.Zero)
                {
                    if (log.IsInfoEnabled) log.Info($"Cannot find monitor at index {TargetMonitorIndex}");
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
                    log.Info($"Found window: {sb}");

                    if (sb.ToString().Equals(ZoomLibCaptionPrefix))
                    {
                        // Check if this window is on the target monitor
                        IntPtr windowMonitor = LibHelperNativeMethods.MonitorFromWindow(mainWindow, LibHelperNativeMethods.MONITOR_DEFAULTTONEAREST);

                        if (windowMonitor == targetMonitor)
                        {
                            LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MAXIMIZE);
                            LibHelperNativeMethods.SetForegroundWindow(mainWindow);
                            if (log.IsInfoEnabled) log.Info($"{processName} window on monitor {TargetMonitorIndex} brought to foreground.");
                            found = true;
                        }
                        else
                        {
                            if (log.IsInfoEnabled) log.Info($"Window found but on different monitor, continuing search...");
                        }
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

                // Get target monitor first
                IntPtr targetMonitor = GetMonitorByIndex(TargetMonitorIndex);
                if (targetMonitor == IntPtr.Zero)
                {
                    if (log.IsInfoEnabled) log.Info($"Cannot find monitor at index {TargetMonitorIndex}");
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
                        // Check if this window is on the target monitor
                        IntPtr windowMonitor = LibHelperNativeMethods.MonitorFromWindow(mainWindow, LibHelperNativeMethods.MONITOR_DEFAULTTONEAREST);

                        if (windowMonitor == targetMonitor)
                        {
                            LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MINIMIZE);
                            if (log.IsInfoEnabled) log.Info($"{processName} window on monitor {TargetMonitorIndex} minimized.");
                            found = true;
                        }
                        else
                        {
                            if (log.IsInfoEnabled) log.Info($"Window found but on different monitor, continuing search...");
                        }
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
        private static IntPtr GetMonitorByIndex(int index)
        {
            var monitors = new System.Collections.Generic.List<IntPtr>();

            LibHelperNativeMethods.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                delegate (IntPtr hMonitor, IntPtr hdcMonitor, ref LibHelperNativeMethods.RECT lprcMonitor, IntPtr dwData)
                {
                    monitors.Add(hMonitor);
                    return true;
                }, IntPtr.Zero);

            if (index >= 0 && index < monitors.Count)
            {
                return monitors[index];
            }

            return IntPtr.Zero;
        }
    }
}