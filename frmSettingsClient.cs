using AutoUpdaterDotNET;
using KH_Video_Switcher.Properties;
using Microsoft.AspNet.SignalR.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace KH_Video_Switcher
{
    public partial class frmSettingsClient : Form
    {
        private bool _saved = false;
        private string _originalServerURL;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmSettingsClient()
        {
            InitializeComponent();
        }

        private void frmSettingsClient_Load(object sender, EventArgs e)
        {
            string version = Application.ProductVersion;
            labelVersion.Text = $"Installed version: {version}";

            checkBoxTopMost.Checked = Properties.Settings.Default.TopMost;
            checkBoxUpdateStart.Checked = Properties.Settings.Default.CheckForUpdatesOnStartup;

            _originalServerURL = Properties.Settings.Default.ServerURL;
            textBoxServerURL.Text = _originalServerURL;

            UpdateServerStatusDisplay(false);
        }

        public void UpdateServerStatusDisplay(bool connected)
        {
            picServerStatus.Image = connected
                ? Properties.Resources.ok_status_8px
                : Properties.Resources.off_status_8px;
            labelServerStatus.Text = connected ? "Connected" : "Disconnected";
            labelServerStatus.ForeColor = connected ? Color.Green : Color.Red;
        }

        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TopMost = checkBoxTopMost.Checked;
        }

        private void checkBoxUpdateStart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdatesOnStartup = checkBoxUpdateStart.Checked;
        }

        private void btnUpdates_Click(object sender, EventArgs e)
        {
            AutoUpdaterDotNET.AutoUpdater.ReportErrors = false;
            AutoUpdaterDotNET.AutoUpdater.CheckForUpdateEvent -= OnManualUpdateCheck;
            AutoUpdaterDotNET.AutoUpdater.CheckForUpdateEvent += OnManualUpdateCheck;

#if DEBUG
            AutoUpdaterDotNET.AutoUpdater.InstalledVersion = new Version("1.0.0.0");
            MessageBox.Show("DEBUG MODE: Update check will always show update available.\n\n" +
                "Installed Version is set to 1.0.0.0.\n\n" +
                "Click OK to continue.",
                "Debug Mode", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif

            AutoUpdaterDotNET.AutoUpdater.Start("https://raw.githubusercontent.com/aaroned/KH-Video-Switcher/master/update.xml");
        }

        private void OnManualUpdateCheck(AutoUpdaterDotNET.UpdateInfoEventArgs args)
        {
            AutoUpdaterDotNET.AutoUpdater.CheckForUpdateEvent -= OnManualUpdateCheck;

            if (args.Error != null)
            {
                MessageBox.Show(
                    "Unable to check for updates. Please check your internet connection and try again.",
                    "Update Check Failed",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!args.IsUpdateAvailable)
            {
                MessageBox.Show(
                    "You're running the latest version!",
                    "No Update Available",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                AutoUpdaterDotNET.AutoUpdater.ShowUpdateForm(args);
            }
        }

        private void btnGithub_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/aaroned/KH-Video-Switcher/releases";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private async void btnTestServer_Click(object sender, EventArgs e)
        {
            btnTestServer.Enabled = false;
            btnTestServer.Text = "Testing...";

            try
            {
                var connection = new HubConnection(textBoxServerURL.Text);
                var hub = connection.CreateHubProxy("OBSHub");
                await connection.Start();

                if (connection.State == ConnectionState.Connected)
                {
                    connection.Stop();
                    UpdateServerStatusDisplay(true);
                    MessageBox.Show("Successfully connected to server!", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateServerStatusDisplay(false);
                    MessageBox.Show("Could not connect to server. Please check the URL is correct and the server is running.",
                        "Connection Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                UpdateServerStatusDisplay(false);
                MessageBox.Show($"Connection test failed: {ex.Message}",
                    "Connection Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTestServer.Enabled = true;
                btnTestServer.Text = "Test Connection";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate Server URL
            if (!textBoxServerURL.Text.StartsWith("http://") && !textBoxServerURL.Text.StartsWith("https://"))
            {
                MessageBox.Show("Server URL must start with http:// or https://", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxServerURL.Focus();
                return;
            }

            _saved = true;
            Properties.Settings.Default.ServerURL = textBoxServerURL.Text;
            Properties.Settings.Default.Save();
            log.Info("Client settings saved");
            var clientForm = Application.OpenForms["frmClient"] as frmClient;
            clientForm?.ApplySettings();
            this.Close();
        }

        private void frmSettingsClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_saved)
            {
                Properties.Settings.Default.Reload();
            }
        }

        private void btnExportSettings_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Settings files (*.xml)|*.xml";
            dialog.FileName = $"KHSwitcher_Zoom_Settings_{DateTime.Now:yyyy-MM-dd}.xml";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var settings = new ClientAppSettings
                    {
                        ServerURL = Properties.Settings.Default.ServerURL,
                        TopMost = Properties.Settings.Default.TopMost,
                        CheckForUpdatesOnStartup = Properties.Settings.Default.CheckForUpdatesOnStartup
                    };

                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ClientAppSettings));
                    using (var writer = new System.IO.StreamWriter(dialog.FileName))
                        serializer.Serialize(writer, settings);

                    MessageBox.Show("Settings exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                    MessageBox.Show("Failed to export settings.", "Export Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnImportSettings_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Settings files (*.xml)|*.xml";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(ClientAppSettings));
                    using (var reader = new System.IO.StreamReader(dialog.FileName))
                    {
                        var values = (ClientAppSettings)serializer.Deserialize(reader);
                        Properties.Settings.Default.ServerURL = values.ServerURL;
                        Properties.Settings.Default.TopMost = values.TopMost;
                        Properties.Settings.Default.CheckForUpdatesOnStartup = values.CheckForUpdatesOnStartup;
                        Properties.Settings.Default.Save();
                    }

                    checkBoxTopMost.Checked = Properties.Settings.Default.TopMost;
                    checkBoxUpdateStart.Checked = Properties.Settings.Default.CheckForUpdatesOnStartup;
                    textBoxServerURL.Text = Properties.Settings.Default.ServerURL;

                    MessageBox.Show("Settings imported successfully! Click Save to apply.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                    MessageBox.Show("Failed to import settings. Please make sure the file is a valid settings backup.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    public class ClientAppSettings
    {
        public string ServerURL { get; set; }
        public bool TopMost { get; set; }
        public bool CheckForUpdatesOnStartup { get; set; }
    }
}