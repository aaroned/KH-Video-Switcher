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
            // One-time migration from app.config to user settings
            if (!Properties.Settings.Default.MigratedFromAppConfig)
            {
                log.Info("Starting migration from app.config to user settings");

                var oldURL = ConfigurationManager.AppSettings["OBSURL"];
                var oldPassword = ConfigurationManager.AppSettings["OBSPassword"];
                var oldServerURL = ConfigurationManager.AppSettings["ServerURL"];

                if (!string.IsNullOrEmpty(oldURL))
                {
                    Properties.Settings.Default.OBSURL = oldURL;
                    log.Info($"Migrated OBSURL: {oldURL}");
                }
                else
                {
                    log.Info("OBSURL not migrated - not found in app.config");
                }

                if (!string.IsNullOrEmpty(oldPassword) && oldPassword != "MzkwPS18pLvjmbF5") // Don't migrate the default password if it was left unchanged
                {
                    Properties.Settings.Default.OBSPassword = oldPassword;
                    log.Info("Migrated OBSPassword");
                }
                else
                {
                    log.Info("OBSPassword not migrated - empty, not found, or default password detected");
                }

                if (!string.IsNullOrEmpty(oldServerURL))
                {
                    Properties.Settings.Default.ServerURL = oldServerURL;
                    log.Info($"Migrated ServerURL: {oldServerURL}");
                }
                else
                {
                    log.Info("ServerURL not migrated - not found in app.config");
                }

                Properties.Settings.Default.MigratedFromAppConfig = true;
                Properties.Settings.Default.Save();
                log.Info("Migration complete");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Customize the update notification
            AutoUpdater.ShowSkipButton = true;  // Let users skip this version
            AutoUpdater.ShowRemindLaterButton = true;  // Remind me later option
            AutoUpdater.Mandatory = false;  // Don't force update
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();  // Set your app icon for the update dialog
            AutoUpdater.TopMost = true;  // Keep update window on top of all others


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
