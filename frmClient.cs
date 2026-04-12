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
        private bool _isCurrentlyZoom;
        private bool _isOBSConnected;
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
            clientStatusMenu.Image = Properties.Resources.off_status_8px;
            clientStatusMenu.ToolTipText = "Server Disconnected";
            this.TopMost = Properties.Settings.Default.TopMost;
            await Connect();

            var reconnectTimer = new System.Windows.Forms.Timer();
            reconnectTimer.Interval = 5000;
            reconnectTimer.Tick += async (s, args) =>
            {
                if (hub == null)
                {
                    if (log.IsInfoEnabled) log.Info("Not connected to server, attempting reconnect...");
                    await Connect();
                }
            };
            reconnectTimer.Start();
        }

        private async Task Connect()
        {
            try
            {
                if (log.IsInfoEnabled) log.Info($"Connecting to server: {Properties.Settings.Default.ServerURL}");
                connection = new HubConnection(Properties.Settings.Default.ServerURL);
                hub = connection.CreateHubProxy("OBSHub");
                hub.On<EnrichedSceneList>("ReceiveScenes", s => ReceiveScenes(s));
                hub.On<bool>("ReceiveOBSStatus", connected =>
                {
                    BeginInvoke((MethodInvoker)(() =>
                    {
                        _isOBSConnected = connected;
                        clientStatusMenu.Image = connected
                            ? Properties.Resources.ok_status_8px
                            : Properties.Resources.connecting_status_8px;
                        clientStatusMenu.ToolTipText = connected ? "OBS Connected" : "Connected to the server\nNot connected to OBS\nEnsure OBS is running.\nSee Wiki for more help.";
                        clientStatusMenu.ForeColor = connected ? Color.Green : Color.Orange;
                        clientStatusMenu.Text = connected ? "OBS Connected" : "Server Connected - Waiting for OBS";
                        clientStatusMenu.BackColor = connected ? Color.Honeydew : Color.Cornsilk;
                        //this.Text = connected ? "KH Switcher (Zoom)" : "KH Switcher (Zoom) - Waiting for OBS";

                        SetSceneButtonsEnabled(connected);

                        if (connected)
                        {
                            scenes = null;
                            _ = Task.Run(async () => await GetScenes());
                        }
                    }));
                });
                hub.On<bool>("ReceiveZoomStatus", isZoom =>
                {
                    BeginInvoke((MethodInvoker)(() => UpdateSceneButtonsForZoom(isZoom)));
                });

                var thisConnection = connection; // Capture the current connection instance for the event handler
                connection.StateChanged += stateChange => Connection_StateChanged(stateChange, thisConnection);

                await connection.Start();
                if (log.IsInfoEnabled) log.Info("Connected to server successfully");

                BeginInvoke((MethodInvoker)(() =>
                {
                    clientStatusMenu.Image = Properties.Resources.connecting_status_8px;
                    clientStatusMenu.ToolTipText = "Connected to the server\nNot connected to OBS\nEnsure OBS is running.\nSee Wiki for more help.";
                    clientStatusMenu.ForeColor = Color.Orange;
                    clientStatusMenu.Text = "Server Connected - Waiting for OBS";
                    clientStatusMenu.BackColor = Color.Cornsilk;
                    //this.Text = "KH Switcher (Zoom) - Waiting for OBS...";
                }));

                await hub.Invoke("GetOBSStatus");
                await hub.Invoke("GetZoomStatus");
                await GetScenes();
            }
            catch (Exception ex)
            {
                hub = null;
                log.Warn($"Connection failed: {ex.Message}");
            }
        }
        private void Connection_StateChanged(StateChange stateChange, HubConnection sourceConnection)
        {
            if (sourceConnection != connection) return;

            BeginInvoke((MethodInvoker)(() =>
            {
                switch (stateChange.NewState)
                {
                    // case Microsoft.AspNet.SignalR.Client.ConnectionState.Connecting:
                    case Microsoft.AspNet.SignalR.Client.ConnectionState.Reconnecting:
                        clientStatusMenu.Image = Properties.Resources.off_status_8px;
                        clientStatusMenu.ToolTipText = "KH Switcher (Zoom) is attempting to connect...";
                        clientStatusMenu.ForeColor = Color.Firebrick;
                        clientStatusMenu.Text = "Connecting to Server...";
                        clientStatusMenu.BackColor = Color.MistyRose;
                        SetSceneButtonsEnabled(false);
                        break;

                    
                    case Microsoft.AspNet.SignalR.Client.ConnectionState.Disconnected:
                        hub = null;
                        clientStatusMenu.Image = Properties.Resources.off_status_8px;
                        clientStatusMenu.ToolTipText = "Server Disconnected\nEnsure KH Switcher (Media) is running.\nSee Wiki for more help.";
                        clientStatusMenu.ForeColor= Color.Firebrick;
                        clientStatusMenu.Text = "Server Disconnected";
                        clientStatusMenu.BackColor = Color.MistyRose;
                        SetSceneButtonsEnabled(false);
                        break;

                        // Connected state intentionally ignored — handled by Connect() and ReceiveOBSStatus
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
                sceneButton.BackColor = (sceneButton.Text == scenes.CurrentProgramSceneName ? Color.Firebrick : Color.RoyalBlue);
            }
        }

        private async void sceneButtonClick(object sender, EventArgs e)
        {
            var btn = (Button)sender;
            var lastClick = (DateTime)btn.Tag;
            var now = DateTime.UtcNow;

            if ((now - lastClick).TotalMilliseconds < 600) return; // Drop rapid/double clicks
            btn.Tag = now;

            if (connection== null || connection.State !=Microsoft.AspNet.SignalR.Client.ConnectionState.Connected)
            {                 
                log.Warn("Scene button pressed but SignalR connection is not ready");
                return;
            }

            this.TopLevel = true;
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
                        sceneButton.Tag = DateTime.MinValue;
                        sceneButton.Click += sceneButtonClick;
                        sceneButton.BackColor = (scenes.CurrentProgramSceneName == scenes.Scenes[i].Name ? Color.Firebrick : Color.RoyalBlue);
                        sceneButton.ForeColor = Color.White;
                        sceneButton.FlatStyle = FlatStyle.Flat;
                        sceneButton.FlatAppearance.BorderSize = 0;
                        sceneButton.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                        sceneButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                        sceneButton.Image = scenes.Scenes[i].IsPictureInPicture
                            ? global::KH_Video_Switcher.Properties.Resources.iconPiP
                            : scenes.Scenes[i].IsMonitorCapture
                                ? global::KH_Video_Switcher.Properties.Resources.iconMedia
                                : global::KH_Video_Switcher.Properties.Resources.iconCam;
                        tableLayoutPanel1.Controls.Add(sceneButton, i, 0);
                    }

                    UpdateSceneButtonsForZoom(_isCurrentlyZoom);
                }
                else
                {
                    scenes = data;
                    UpdateSceneButtonColors();
                }
            }));
        }
        private void SetSceneButtonsEnabled(bool enabled)
        {
            foreach (Button sceneButton in tableLayoutPanel1.Controls)
            {
                sceneButton.Enabled = enabled;
                if (!enabled)
                    sceneButton.BackColor = Color.LightGray;
            }

            if (enabled && scenes != null)
            {
                UpdateSceneButtonColors();
                UpdateSceneButtonsForZoom(_isCurrentlyZoom); // Re-apply zoom restrictions
            }
        }
        private void UpdateSceneButtonsForZoom(bool isZoom)
        {
            _isCurrentlyZoom = isZoom;
            if (scenes == null) return;

            foreach (Button btn in tableLayoutPanel1.Controls)
            {
                var scene = scenes.Scenes.FirstOrDefault(s => s.Name == btn.Text);
                if (scene == null) continue;

                bool isRestricted = scene.IsMonitorCapture || scene.IsPictureInPicture;
                btn.Enabled = _isOBSConnected && (!isZoom || !isRestricted);

                if (!btn.Enabled)
                    btn.BackColor = Color.LightGray; 
            }

            // Only restore colours on enabled buttons
            foreach (Button btn in tableLayoutPanel1.Controls)
            {
                if (btn.Enabled)
                    btn.BackColor = (btn.Text == scenes.CurrentProgramSceneName ? Color.Firebrick : Color.RoyalBlue);
            }
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
                    await hub.Invoke("GetOBSStatus");
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
            AutoUpdaterDotNET.AutoUpdater.Start("https://raw.githubusercontent.com/aaroned/KH-Video-Switcher/master/update.xml");
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
