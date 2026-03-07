using AutoUpdaterDotNET;
using KH_Video_Switcher.Properties;
using System;
using System.Linq;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;
using System.IO;
using System.Diagnostics;

namespace KH_Video_Switcher
{
    static class Program
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Parse --client true/false argument
            bool isClientMode = false;
            var clientArgIndex = Array.IndexOf(args, "--client");
            if (clientArgIndex >= 0 && clientArgIndex + 1 < args.Length)
            {
                isClientMode = args[clientArgIndex + 1].ToLower() == "true";
            }

            log.Info($"Starting in {(isClientMode ? "client" : "server")} mode");

            // AutoUpdater configuration
            AutoUpdater.ShowSkipButton = true;
            AutoUpdater.ShowRemindLaterButton = true;
            AutoUpdater.Mandatory = false;
            AutoUpdater.ReportErrors = true;
            AutoUpdater.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();
            AutoUpdater.TopMost = true;

            // Check for updates on startup - only if first instance
            bool isFirstInstance = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length == 1;

            if (Settings.Default.CheckForUpdatesOnStartup && isFirstInstance)
            {
                Task.Delay(5000).ContinueWith(t => // Delay check to allow form to load
                {
                    Application.OpenForms[0].Invoke((Action)(() =>
                        AutoUpdater.Start("https://raw.githubusercontent.com/aaroned/KH-Video-Switcher/master/update.xml")
                    ));
                });
            }
            MigrateToUnifiedSettings();
            Application.Run(isClientMode ? (Form)new frmClient() : (Form)new frmServer());
        }
        private static void MigrateToUnifiedSettings()
        {
            if (Properties.Settings.Default.MigratedToUnifiedSettings)
                return;

            log.Info("Starting migration to unified settings");

            var serverConfigPath = @"C:\Program Files (x86)\KH Switcher\KH Switcher Media\KH Switcher.exe.config";
            var clientConfigPath = @"C:\Program Files (x86)\KH Switcher\KH Switcher Zoom\KH Switcher.exe.config";

            bool serverFound = File.Exists(serverConfigPath);
            bool clientFound = File.Exists(clientConfigPath);

            if (!serverFound && !clientFound)
            {
                log.Info("No old config files found - fresh install, skipping migration");
                Properties.Settings.Default.MigratedToUnifiedSettings = true;
                Properties.Settings.Default.Save();
                return;
            }

            if (serverFound)
            {
                log.Info($"Found server config at: {serverConfigPath}");
                try
                {
                    var doc = new System.Xml.XmlDocument();
                    doc.Load(serverConfigPath);

                    var obsURL = GetAppSetting(doc, "OBSURL");
                    var obsPassword = GetAppSetting(doc, "OBSPassword");

                    if (!string.IsNullOrEmpty(obsURL))
                    {
                        Properties.Settings.Default.OBSURL = obsURL;
                        log.Info($"Migrated OBSURL: {obsURL}");
                    }

                    if (!string.IsNullOrEmpty(obsPassword) && obsPassword != "MzkwPS18pLvjmbF5" && obsPassword != "")
                    {
                        Properties.Settings.Default.OBSPassword = obsPassword;
                        log.Info("Migrated OBSPassword");
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"Failed to read server config: {ex.Message}", ex);
                }
            }
            else
            {
                log.Info("Server config not found - skipping server settings");
            }

            if (clientFound)
            {
                log.Info($"Found client config at: {clientConfigPath}");
                try
                {
                    var doc = new System.Xml.XmlDocument();
                    doc.Load(clientConfigPath);

                    var serverURL = GetAppSetting(doc, "ServerURL");

                    if (!string.IsNullOrEmpty(serverURL))
                    {
                        Properties.Settings.Default.ServerURL = serverURL;
                        log.Info($"Migrated ServerURL: {serverURL}");
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"Failed to read client config: {ex.Message}", ex);
                }
            }
            else
            {
                log.Info("Client config not found - skipping client settings");
            }

            Properties.Settings.Default.MigratedToUnifiedSettings = true;
            Properties.Settings.Default.Save();
            log.Info("Migration to unified settings complete");
        }

        private static string GetAppSetting(System.Xml.XmlDocument doc, string key)
        {
            var node = doc.SelectSingleNode($"//appSettings/add[@key='{key}']");
            return node?.Attributes["value"]?.Value;
        }
    }
}