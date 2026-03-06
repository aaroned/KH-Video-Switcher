using AutoUpdaterDotNET;
using JW_Library_Focuser;
using KH_Video_Switcher.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KH_Video_Switcher

{
    public partial class frmSettingsServer : Form

    {
        private bool _saved = false;
        private string _originalOBSURL;
        private string _originalOBSPassword;

        public frmSettingsServer()
        {
            InitializeComponent();
        }
        private void frmSettingsServer_Load(object sender, EventArgs e)
        {
            string version = Application.ProductVersion;

            labelVersion.Text = $"Installed version: {version}";

            checkBoxUpdateStart.Checked = Properties.Settings.Default.CheckForUpdatesOnStartup;
            checkBoxOnlyMView.Checked = Properties.Settings.Default.onlyMView;

            _originalOBSURL = Properties.Settings.Default.OBSURL;
            _originalOBSPassword = Properties.Settings.Default.OBSPassword;

            textBoxOBSURL.Text = _originalOBSURL;
            textBoxOBSPASS.Text = _originalOBSPassword;

            checkBoxTopMost.Checked = Properties.Settings.Default.TopMost;

            PopulateMonitorDropdown();
        }

        public void UpdateOBSStatusDisplay(bool connected)
        {
            picOBSStatus.Image = connected
                ? Properties.Resources.ok_status_8px
                : Properties.Resources.off_status_8px;
            labelOBSStatus.Text = connected ? "Connected" : "Disconnected";
            labelOBSStatus.ForeColor = connected ? Color.Green : Color.Red;
        }

        private void btnShowOBSPASS_Click(object sender, EventArgs e)
        {
            // Toggle the UseSystemPasswordChar property
            if (textBoxOBSPASS.UseSystemPasswordChar)
            {
                textBoxOBSPASS.UseSystemPasswordChar = false;
                btnShowOBSPASS.Text = "Hide";
            }
            else
            {
                textBoxOBSPASS.UseSystemPasswordChar = true;
                btnShowOBSPASS.Text = "Show";
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

        private void btnUpdates_Click(object sender, EventArgs e)
        {
            AutoUpdaterDotNET.AutoUpdater.Start("https://raw.githubusercontent.com/aaroned/KH-Video-Switcher/master/update.xml");
        }

        private void checkBoxUpdateStart_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.CheckForUpdatesOnStartup = checkBoxUpdateStart.Checked;
        }

        private void checkBoxOnlyMView_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.onlyMView = checkBoxOnlyMView.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Validate OBS URL format
            if (!textBoxOBSURL.Text.StartsWith("ws://"))
            {
                MessageBox.Show("OBS URL must start with ws://", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxOBSURL.Focus();
                return;
            }
            // Validate that the URL includes a port number
            string urlWithoutScheme = textBoxOBSURL.Text.Substring(5); // removes "ws://"
            if (!urlWithoutScheme.Contains(":"))
            {
                MessageBox.Show("OBS URL must include a port number e.g. ws://127.0.0.1:4455", "Invalid URL", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxOBSURL.Focus();
                return;
            }

            _saved = true;
            Properties.Settings.Default.OBSURL = textBoxOBSURL.Text;
            Properties.Settings.Default.OBSPassword = textBoxOBSPASS.Text;
            if (comboBoxSecondDisplay.SelectedItem is MonitorItem selectedMonitor)
                Properties.Settings.Default.SecondDisplay = selectedMonitor.DeviceName;
            Properties.Settings.Default.Save();
            var serverForm = Application.OpenForms["frmServer"] as frmServer;
            serverForm?.ApplySettings();
            this.Close();
        }
        private void frmSettingsServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_saved)
            {
                Properties.Settings.Default.Reload(); // Revert unsaved changes
            }
        }

        private void btnExportSettings_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Settings files (*.xml)|*.xml";
            dialog.FileName = $"KHSwitcher_Media_Settings_{DateTime.Now:yyyy-MM-dd}.xml";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var settings = new AppSettings
                    {
                        OBSURL = Properties.Settings.Default.OBSURL,
                        OBSPassword = Properties.Settings.Default.OBSPassword,
                        CheckForUpdatesOnStartup = Properties.Settings.Default.CheckForUpdatesOnStartup,
                        onlyMView = Properties.Settings.Default.onlyMView,
                        TopMost = Properties.Settings.Default.TopMost,
                        SecondDisplay = Properties.Settings.Default.SecondDisplay
                    };

                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
                    using (var writer = new System.IO.StreamWriter(dialog.FileName))
                        serializer.Serialize(writer, settings);

                    MessageBox.Show("Settings exported successfully!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
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
                    var serializer = new System.Xml.Serialization.XmlSerializer(typeof(AppSettings));
                    using (var reader = new System.IO.StreamReader(dialog.FileName))
                    {
                        var values = (AppSettings)serializer.Deserialize(reader);
                        Properties.Settings.Default.OBSURL = values.OBSURL;
                        Properties.Settings.Default.OBSPassword = values.OBSPassword;
                        Properties.Settings.Default.CheckForUpdatesOnStartup = values.CheckForUpdatesOnStartup;
                        Properties.Settings.Default.onlyMView = values.onlyMView;
                        Properties.Settings.Default.TopMost = values.TopMost;
                        Properties.Settings.Default.SecondDisplay = values.SecondDisplay;
                        Properties.Settings.Default.Save();
                    }

                    checkBoxUpdateStart.Checked = Properties.Settings.Default.CheckForUpdatesOnStartup;
                    checkBoxOnlyMView.Checked = Properties.Settings.Default.onlyMView;
                    textBoxOBSURL.Text = Properties.Settings.Default.OBSURL;
                    textBoxOBSPASS.Text = Properties.Settings.Default.OBSPassword;
                    checkBoxTopMost.Checked = Properties.Settings.Default.TopMost;
                    PopulateMonitorDropdown();  


                    MessageBox.Show("Settings imported successfully! Click Save to apply.", "Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {
                    MessageBox.Show("Failed to import settings. Please make sure the file is a valid settings backup.", "Import Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnTestOBS_Click(object sender, EventArgs e)
        {
            btnTestOBS.Enabled = false;
            btnTestOBS.Text = "Testing...";

            try
            {
                var obsWS = new OBSWebsocketDotNet.OBSWebsocket();
                obsWS.ConnectAsync(textBoxOBSURL.Text, textBoxOBSPASS.Text);

                var waited = 0;
                while (!obsWS.IsConnected && waited < 5000)
                {
                    await Task.Delay(500);
                    waited += 500;
                }

                if (obsWS.IsConnected)
                {
                    obsWS.Disconnect();
                    UpdateOBSStatusDisplay(true);
                    MessageBox.Show("Successfully connected to OBS!", "Connection Test", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    UpdateOBSStatusDisplay(false);
                    MessageBox.Show("Could not connect to OBS. Please check the URL and password are correct and OBS is running.",
                        "Connection Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                UpdateOBSStatusDisplay(false);
                MessageBox.Show($"Connection test failed: {ex.Message}",
                    "Connection Test Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnTestOBS.Enabled = true;
                btnTestOBS.Text = "Test Connection";
            }
        }

        private void checkBoxTopMost_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TopMost = checkBoxTopMost.Checked;
        }
        private void PopulateMonitorDropdown()
        {
            var monitors = ZoomLibHelper.GetAllMonitors();
            comboBoxSecondDisplay.Items.Clear();

            foreach (var monitor in monitors)
            {
                comboBoxSecondDisplay.Items.Add(new MonitorItem(monitor.DeviceName, monitor.FriendlyName));
            }

            comboBoxSecondDisplay.DisplayMember = "FriendlyName";

            // Select the currently saved display
            var saved = Properties.Settings.Default.SecondDisplay;
            foreach (MonitorItem item in comboBoxSecondDisplay.Items)
            {
                if (item.DeviceName.Equals(saved, StringComparison.OrdinalIgnoreCase))
                {
                    comboBoxSecondDisplay.SelectedItem = item;
                    break;
                }
            }

            // Fall back to first item if nothing matched
            if (comboBoxSecondDisplay.SelectedIndex == -1 && comboBoxSecondDisplay.Items.Count > 0)
                comboBoxSecondDisplay.SelectedIndex = 0;
        }
    }
    public class MonitorItem
    {
        public string DeviceName { get; set; }
        public string FriendlyName { get; set; }
        public MonitorItem(string deviceName, string friendlyName)
        {
            DeviceName = deviceName;
            FriendlyName = friendlyName;
        }
    }
    public class AppSettings
    {
        public string OBSURL { get; set; }
        public string OBSPassword { get; set; }
        public bool CheckForUpdatesOnStartup { get; set; }
        public bool onlyMView { get; set; }
        public bool TopMost { get; set; }
        public string SecondDisplay { get; set; }
    }
}
