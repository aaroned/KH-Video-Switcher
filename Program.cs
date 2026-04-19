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

            // Prevent multiple server instances
            System.Threading.Mutex serverMutex = null;
            if (!isClientMode)
            {
                bool createdNew;
                serverMutex = new System.Threading.Mutex(true, "KHVideoSwitcher_ServerInstance", out createdNew);
                if (!createdNew)
                {
                    serverMutex.Dispose();
                    MessageBox.Show(
                        "KH Video Switcher (Media) is already running.\n\nOnly one instance can be open at a time.",
                        "KH Switcher (Media) Already Running",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }
            }

            // AutoUpdater configuration
            AutoUpdater.ShowSkipButton = true;
            AutoUpdater.ShowRemindLaterButton = true;
            AutoUpdater.Mandatory = false;
            AutoUpdater.ReportErrors = false;
            AutoUpdater.Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath).ToBitmap();
            AutoUpdater.TopMost = true;

#if DEBUG
            AutoUpdaterDotNET.AutoUpdater.InstalledVersion = new Version("1.0.0.0");
            MessageBox.Show("DEBUG MODE: Update check will always show update available.\n\n" +
                "Installed Version is set to 1.0.0.0.\n\n" +
                "Click OK to continue.",
                "Debug Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif

            // Check for updates on startup - only if first instance
            bool isFirstInstance = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length == 1;

            if (Properties.Settings.Default.CheckForUpdatesOnStartup && isFirstInstance)
            {
                Task.Delay(5000).ContinueWith(t =>
                {
                    var form = Application.OpenForms.Count > 0 ? Application.OpenForms[0] : null;
                    if (form != null && !form.IsDisposed)
                    {
                        try
                        {
                            form.Invoke((Action)(() =>
                                AutoUpdater.Start("https://raw.githubusercontent.com/aaroned/KH-Video-Switcher/master/update.xml")
                            ));
                        }
                        catch (ObjectDisposedException) { /* Form closed during startup, skip update check */ }
                    }
                });
            }

            MigrateToUnifiedSettings();
            Application.Run(isClientMode ? (Form)new frmClient() : (Form)new frmServer());

            GC.KeepAlive(serverMutex);
        }
        private static void MigrateToUnifiedSettings()
        {
            if (Properties.Settings.Default.MigratedToUnifiedSettings)
                return;

            log.Info("Starting migration to unified settings");

            var serverConfigPath = Path.Combine(Application.StartupPath, "migration_server.config");
            var clientConfigPath = Path.Combine(Application.StartupPath, "migration_client.config");

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