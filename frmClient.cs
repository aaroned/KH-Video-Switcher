using AutoUpdaterDotNET;
using log4net;
using Microsoft.AspNet.SignalR.Client;
using OBSWebsocketDotNet.Types;
using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KH_Video_Switcher
{
    public partial class frmClient : Form
    {
        private IHubProxy hub;
        private HubConnection connection;
        private EnrichedSceneList scenes;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmClient()
        {
            InitializeComponent();
            var top = Screen.PrimaryScreen.Bounds.Top;
            var left = (int)(Screen.PrimaryScreen.Bounds.X + ((Screen.PrimaryScreen.Bounds.Width - this.Size.Width) / 2));
            this.Location = new Point(left, top);
        }

        private async Task GetScenes()
        {
            await hub.Invoke("GetScenes");
        }

        private async Task SetScene(string name)
        {
            await hub.Invoke("SetScene",name);
        }

        private async void frmClient_Load(object sender, EventArgs e)
        {
            // One-time migration from app.config to user settings - can be removed in a future release after most users have migrated
            if (!Properties.Settings.Default.MigratedClientAppConfig)
            {
                log.Info("Starting client migration from app.config to user settings");

                var oldServerURL = ConfigurationManager.AppSettings["ServerURL"];

                if (!string.IsNullOrEmpty(oldServerURL))
                {
                    Properties.Settings.Default.ServerURL = oldServerURL;
                    log.Info($"Migrated ServerURL: {oldServerURL}");
                }
                else
                {
                    log.Info("ServerURL not migrated - not found in app.config");
                }

                Properties.Settings.Default.MigratedClientAppConfig = true;
                Properties.Settings.Default.Save();
                log.Info("Client migration complete");
            }
            // End of migration code - can be removed in a future release after most users have migrated

            clientStatusMenu.Image = Properties.Resources.off_status_8px;
            clientStatusMenu.ToolTipText = "Server Disconnected";
            this.TopMost = Properties.Settings.Default.TopMost;
            await Connect();
        }

        private async Task Connect()
        {
            try
            {
                if (log.IsInfoEnabled) log.Info("Connecting to server");
                connection = new HubConnection(Properties.Settings.Default.ServerURL);
                hub = connection.CreateHubProxy("OBSHub");
                hub.On<EnrichedSceneList>("ReceiveScenes", s => ReceiveScenes(s));
                hub.On<bool>("ReceiveOBSStatus", connected =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        clientStatusMenu.Image = connected
                            ? Properties.Resources.ok_status_8px
                            : Properties.Resources.connecting_status_8px;
                        clientStatusMenu.ToolTipText = connected ? "OBS Connected" : "Server Connected - Waiting for OBS";
                        this.Text = connected ? "KH Switcher (Zoom)" : "KH Switcher (Zoom) - Waiting for OBS";

                        if (connected)
                        {
                            scenes = null;
                            _ = Task.Run(async () => await GetScenes());
                        }
                    }));
                });
                connection.StateChanged += Connection_StateChanged;
                await connection.Start();
                if (log.IsInfoEnabled) log.Info("Connected to server successfully");
                await GetScenes();
            }
            catch (Exception ex)
            {
                hub = null;
                log.Warn($"Connection failed: {ex.Message}");
                this.Text = "KH Switcher (Zoom) - Connection Failed";
                MessageBox.Show("Could not connect to server. Please check the server is running and click Refresh to try again.",
                    "Connection Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Connection_StateChanged(StateChange stateChange)
        {
            bool connected = stateChange.NewState == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected;
            BeginInvoke((MethodInvoker)(() =>
            {
                if (!connected)
                {
                    clientStatusMenu.Image = Properties.Resources.off_status_8px;
                    clientStatusMenu.ToolTipText = "Server Disconnected";
                    this.Text = "KH Switcher (Zoom) - Server Disconnected";
                }
                else
                {
                    clientStatusMenu.Image = Properties.Resources.connecting_status_8px;
                    clientStatusMenu.ToolTipText = "Server Connected - Waiting for OBS";
                    this.Text = "KH Switcher (Zoom) - Waiting for OBS";
                }
            }));
        }
        public void ApplySettings()
        {
            this.TopMost = Properties.Settings.Default.TopMost;

            // Reconnect if server URL changed
            if (connection?.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
                connection.Stop();

            hub = null;
            _ = Connect();
        }
        private void UpdateSceneButtonColors()
        {
            foreach (Button sceneButton in tableLayoutPanel1.Controls)
            {
                sceneButton.BackColor = (sceneButton.Text == scenes.CurrentProgramSceneName ? Color.DarkRed : Color.RoyalBlue);
            }
        }

        private async void sceneButtonClick(object sender, EventArgs e)
        {
            this.TopLevel = true;
            // this.TopMost = true; Now handled in ApplySettings to avoid issues with the settings form

            var scene = ((Button)sender).Text;
            scenes.CurrentProgramSceneName = scene;
            await SetScene(scene);
        }

        private void ReceiveScenes(EnrichedSceneList data)
        {
            //Invoke on the UI Thread
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (scenes == null)
                {
                    scenes = data;

                    tableLayoutPanel1.Controls.Clear();
                    tableLayoutPanel1.ColumnCount = scenes.Scenes.Count;
                    tableLayoutPanel1.ColumnStyles.Clear();
                    var columnPercent = 100F / scenes.Scenes.Count;

                    for (int i = 0; i < scenes.Scenes.Count; i++)
                    {
                        // var sceneName = scenes.Scenes[i].Name;

                        tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, columnPercent));
                        var sceneButton = new Button();
                        sceneButton.Dock = DockStyle.Fill;
                        sceneButton.Text = scenes.Scenes[i].Name;
                        sceneButton.TextAlign = ContentAlignment.BottomCenter;
                        sceneButton.Click += sceneButtonClick;
                        sceneButton.BackColor = (scenes.CurrentProgramSceneName == scenes.Scenes[i].Name ? Color.DarkRed : Color.RoyalBlue);
                        sceneButton.ForeColor = Color.White;
                        sceneButton.FlatStyle = FlatStyle.Flat;
                        sceneButton.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        sceneButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                        sceneButton.Image = scenes.Scenes[i].IsMonitorCapture
                             ? global::KH_Video_Switcher.Properties.Resources.iconMedia
                             : global::KH_Video_Switcher.Properties.Resources.iconCam;
                        tableLayoutPanel1.Controls.Add(sceneButton, i, 0);
                    }

                }
                else
                {
                    scenes = data;
                    UpdateSceneButtonColors();
                }
            }));
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void refreshMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                scenes = null;
                if (hub == null)
                {
                    await Connect();
                }
                else
                {
                    await GetScenes();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }

        private void checkForUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AutoUpdaterDotNET.AutoUpdater.Start("https://raw.githubusercontent.com/aaroned/KH-Video-Switcher/add-autoupdater/update.xml");
        }

        private void menuItemWiki_Click(object sender, EventArgs e)
        {
            string url = "https://github.com/aaroned/KH-Video-Switcher/wiki";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettingsClient settings = new frmSettingsClient();
            settings.Load += (s, e2) => settings.UpdateServerStatusDisplay(
                connection?.State == Microsoft.AspNet.SignalR.Client.ConnectionState.Connected);
            settings.ShowDialog();
        }

        private void viewLogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {// 1. Get the path to the system Temp folder
                string tempFolder = Path.GetTempPath();

                // 2. Combine it with your specific log file name
                string logFilePath = Path.Combine(tempFolder, "KHSwitcher.log");

                // 3. Safety check: Does the file exist?
                if (File.Exists(logFilePath))
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = logFilePath,
                        UseShellExecute = true // Uses default app (Notepad, VS Code, etc.)
                    });
                }
                else
                {
                    MessageBox.Show("Log file not found at: " + logFilePath);
                }
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }
    }
}
