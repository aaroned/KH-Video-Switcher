using AutoUpdaterDotNET;
using KH_Video_Switcher.Properties;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace KH_Video_Switcher
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // AutoUpdater configuration 
            /// Customize the update notification
            AutoUpdater.ShowSkipButton = true;
            AutoUpdater.ShowRemindLaterButton = true;
            AutoUpdater.Mandatory = false; 
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();  /// Set icon
            AutoUpdater.TopMost = true;

            // Check for updates on startup
            if (Settings.Default.CheckForUpdatesOnStartup)
            {
                Task.Delay(5000).ContinueWith(t =>   // Delay the update check by 5 seconds to allow the main form to load first
                {
                    Application.OpenForms[0].Invoke((Action)(() =>  // Invoke on the main UI thread to show the update dialog as topmost
                        AutoUpdater.Start("https://raw.githubusercontent.com/aaroned/KH-Video-Switcher/add-autoupdater/update.xml")
                    ));
                });
            }
                
            var clientModeSetting = ConfigurationManager.AppSettings["ClientMode"];
            var isClientMode = (clientModeSetting != null && clientModeSetting.ToLower() == "true");

            Application.Run(isClientMode ? (Form)new frmClient() : (Form)new frmServer());
        }
    }
}
