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

        public static void BringToFront()
        {
            BringToFront(ZoomLibProcessName);
        }

        public static void Minimize()
        {
            Minimize(ZoomLibProcessName);
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
                if (sb.ToString().Equals(ZoomLibCaptionPrefix))
                {
                    LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MAXIMIZE);
                    LibHelperNativeMethods.SetForegroundWindow(mainWindow);
                    found = true;
                }

                prevWindow = mainWindow;
            }

            return found;
        }

        private static bool Minimize(string processName)
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
                if (sb.ToString().Equals(ZoomLibCaptionPrefix))
                {                    
                    LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MINIMIZE);
                    found = true;
                }

                prevWindow = mainWindow;
            }

            return found;
        }
    }
}