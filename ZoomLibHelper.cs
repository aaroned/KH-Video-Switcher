using System;
using System.Collections.Generic;
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
        private static string TargetMonitorDevice { get; set; } = "\\\\.\\DISPLAY2";
        public static void SetTargetMonitor(string deviceName)
        {
            if (!string.IsNullOrEmpty(deviceName))
                TargetMonitorDevice = deviceName;
        }

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void BringToFront()
        {
            if (log.IsInfoEnabled) log.Info("Attempting to bring Zoom to front");

            // Log all available monitors for troubleshooting
            LogAllMonitors();

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

                    if (sb.ToString().Contains(ZoomLibCaptionPrefix))
                    {
                        // Check which monitor this window is on
                        IntPtr windowMonitor = LibHelperNativeMethods.MonitorFromWindow(mainWindow, LibHelperNativeMethods.MONITOR_DEFAULTTONEAREST);

                        if (IsTargetMonitor(windowMonitor))
                        {
                            LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MAXIMIZE);
                            LibHelperNativeMethods.SetForegroundWindow(mainWindow);

                            string monitorName = GetMonitorDeviceName(windowMonitor);
                            if (log.IsInfoEnabled) log.Info($"{processName} window on monitor '{monitorName}' brought to foreground.");
                            found = true;
                        }
                        else
                        {
                            string monitorName = GetMonitorDeviceName(windowMonitor);
                            if (log.IsInfoEnabled) log.Info($"Window found on monitor '{monitorName}', but target is '{TargetMonitorDevice}'. Continuing search...");
                        }
                    }

                    prevWindow = mainWindow;
                }

                if (!found)
                {
                    if (log.IsInfoEnabled) log.Info($"Cannot find window for process: {processName} on target monitor '{TargetMonitorDevice}'");
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

                    if (sb.ToString().Contains(ZoomLibCaptionPrefix))
                    {
                        // Check which monitor this window is on
                        IntPtr windowMonitor = LibHelperNativeMethods.MonitorFromWindow(mainWindow, LibHelperNativeMethods.MONITOR_DEFAULTTONEAREST);

                        if (IsTargetMonitor(windowMonitor))
                        {
                            LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MINIMIZE);

                            string monitorName = GetMonitorDeviceName(windowMonitor);
                            if (log.IsInfoEnabled) log.Info($"{processName} window on monitor '{monitorName}' minimized.");
                            found = true;
                        }
                        else
                        {
                            string monitorName = GetMonitorDeviceName(windowMonitor);
                            if (log.IsInfoEnabled) log.Info($"Window found on monitor '{monitorName}', but target is '{TargetMonitorDevice}'. Continuing search...");
                        }
                    }

                    prevWindow = mainWindow;
                }

                if (!found)
                {
                    if (log.IsInfoEnabled) log.Info($"Cannot find window for process: {processName} on target monitor '{TargetMonitorDevice}'");
                }

                return found;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        // Helper method to check if a monitor is the target monitor
        private static bool IsTargetMonitor(IntPtr hMonitor)
        {
            if (TargetMonitorDevice == "PRIMARY")
            {
                return IsPrimaryMonitor(hMonitor);
            }

            string deviceName = GetMonitorDeviceName(hMonitor);
            return deviceName.Equals(TargetMonitorDevice, StringComparison.OrdinalIgnoreCase);
        }

        // Check if monitor is primary
        private static bool IsPrimaryMonitor(IntPtr hMonitor)
        {
            LibHelperNativeMethods.MONITORINFOEX monitorInfo = new LibHelperNativeMethods.MONITORINFOEX();
            monitorInfo.cbSize = Marshal.SizeOf(monitorInfo);

            if (LibHelperNativeMethods.GetMonitorInfo(hMonitor, ref monitorInfo))
            {
                return (monitorInfo.dwFlags & LibHelperNativeMethods.MONITORINFOF_PRIMARY) != 0;
            }

            return false;
        }

        // Get monitor device name
        private static string GetMonitorDeviceName(IntPtr hMonitor)
        {
            LibHelperNativeMethods.MONITORINFOEX monitorInfo = new LibHelperNativeMethods.MONITORINFOEX();
            monitorInfo.cbSize = Marshal.SizeOf(monitorInfo);

            if (LibHelperNativeMethods.GetMonitorInfo(hMonitor, ref monitorInfo))
            {
                return monitorInfo.szDevice;
            }

            return "Unknown";
        }

        // Log all available monitors for troubleshooting
        private static void LogAllMonitors()
        {
            if (!log.IsInfoEnabled) return;

            log.Info("=== Available Monitors ===");
            int displayNumber = 1;

            LibHelperNativeMethods.EnumDisplayMonitors(IntPtr.Zero, IntPtr.Zero,
                delegate (IntPtr hMonitor, IntPtr hdcMonitor, ref LibHelperNativeMethods.RECT lprcMonitor, IntPtr dwData)
                {
                    LibHelperNativeMethods.MONITORINFOEX monitorInfo = new LibHelperNativeMethods.MONITORINFOEX();
                    monitorInfo.cbSize = Marshal.SizeOf(monitorInfo);

                    if (LibHelperNativeMethods.GetMonitorInfo(hMonitor, ref monitorInfo))
                    {
                        bool isPrimary = (monitorInfo.dwFlags & LibHelperNativeMethods.MONITORINFOF_PRIMARY) != 0;
                        string deviceName = monitorInfo.szDevice;

                        log.Info($"Display {displayNumber}: {deviceName} {(isPrimary ? "(PRIMARY)" : "")}");
                        displayNumber++;
                    }

                    return true;
                }, IntPtr.Zero);

            log.Info($"Target monitor device: {TargetMonitorDevice}");
            log.Info("==========================");
        }
        public static List<(string DeviceName, string FriendlyName)> GetAllMonitors()
        {
            var monitors = new List<(string, string)>();

            uint deviceIndex = 0;
            var displayDevice = new LibHelperNativeMethods.DISPLAY_DEVICE();
            displayDevice.cb = Marshal.SizeOf(displayDevice);

            while (LibHelperNativeMethods.EnumDisplayDevices(null, deviceIndex, ref displayDevice, 0))
            {
                if ((displayDevice.StateFlags & LibHelperNativeMethods.DISPLAY_DEVICE_ACTIVE) != 0)
                {
                    string adapterName = displayDevice.DeviceName;

                    var monitorDevice = new LibHelperNativeMethods.DISPLAY_DEVICE();
                    monitorDevice.cb = Marshal.SizeOf(monitorDevice);

                    if (LibHelperNativeMethods.EnumDisplayDevices(adapterName, 0, ref monitorDevice, 0))
                    {
                        string friendlyName = monitorDevice.DeviceString;

                        string resolution = "";
                        bool isPrimary = false;
                        foreach (System.Windows.Forms.Screen screen in System.Windows.Forms.Screen.AllScreens)
                        {
                            if (screen.DeviceName.Equals(adapterName, StringComparison.OrdinalIgnoreCase))
                            {
                                resolution = $"{screen.Bounds.Width}x{screen.Bounds.Height}";
                                isPrimary = screen.Primary;
                                break;
                            }
                        }

                        string displayText = $"{friendlyName} - {resolution}{(isPrimary ? " (Primary)" : "")}";
                        monitors.Add((adapterName, displayText));
                    }
                }

                deviceIndex++;
                displayDevice = new LibHelperNativeMethods.DISPLAY_DEVICE();
                displayDevice.cb = Marshal.SizeOf(displayDevice);
            }

            return monitors;
        }
    }
}