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

        public static void BringToFront()
        {
            BringToFront(OnlyMLibProcessName);
        }

        public static void Minimize()
        {
            Minimize(OnlyMLibProcessName);
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

            var mainWindow = LibHelperNativeMethods.FindWindowEx(desktopWindow, IntPtr.Zero, null, OnlyMLibCaptionPrefix);
            if (mainWindow == IntPtr.Zero)
            {
                return false;
            }

            LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MAXIMIZE);
            LibHelperNativeMethods.SetForegroundWindow(mainWindow);
            return true;            
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

            var mainWindow = LibHelperNativeMethods.FindWindowEx(desktopWindow, IntPtr.Zero, null, OnlyMLibCaptionPrefix);
            if (mainWindow == IntPtr.Zero)
            {
                return false;
            }

            LibHelperNativeMethods.ShowWindow(mainWindow, LibHelperNativeMethods.SW_MINIMIZE);
            return true;
        }
    }
}