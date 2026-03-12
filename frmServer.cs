using AutoUpdaterDotNET;
using JW_Library_Focuser;
using log4net;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KH_Video_Switcher
{
    public partial class frmServer : Form
    {
        private OBSWebsocketDotNet.OBSWebsocket obsWS;
        private IDisposable server;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private bool _lastOBSStatus = false;

        public static OBSWebsocketDotNet.OBSWebsocket OBSConnection { get; private set; }

        // FOR TESTING - Comment out when not testing
        // private frmClient client;
        // END FOR TESTING

        public frmServer()
        {
            InitializeComponent();

            try
            {
                if (log.IsInfoEnabled) log.Info("Starting server on port 7004");
                server = WebApp.Start<ServerStartup>("http://+:7004");

                obsWS = new OBSWebsocketDotNet.OBSWebsocket();
                OBSConnection = obsWS;
                obsWS.Connected += ObsWS_Connected;

                obsWS.Disconnected += (sender, e) =>
                {
                    if (log.IsInfoEnabled) log.Info("OBS WS Disconnected");
                    UpdateOBSStatus(false);
                };

                // Auto reconnect timer
                var reconnectTimer = new System.Windows.Forms.Timer();
                reconnectTimer.Interval = 5000;
                reconnectTimer.Tick += (s, e) =>
                {
                    if (!obsWS.IsConnected)
                    {
                        if (log.IsInfoEnabled) log.Info("OBS not connected, attempting reconnect...");
                        obsWS.ConnectAsync(Properties.Settings.Default.OBSURL, Properties.Settings.Default.OBSPassword);
                    }
                };
                reconnectTimer.Start();

                var top = Screen.PrimaryScreen.Bounds.Top;
                var left = (int)(Screen.PrimaryScreen.Bounds.X + ((Screen.PrimaryScreen.Bounds.Width - this.Size.Width) / 2));
                this.Location = new Point(left, top);
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        private void ObsWS_Connected(object sender, EventArgs e)
        {
            UpdateOBSStatus(true);
            if (log.IsInfoEnabled) log.Info("OBS WS Connected");

            BeginInvoke((MethodInvoker)(async () =>
            {
                await Task.Delay(500);
                try
                {
                    var status = obsWS.GetVirtualCamStatus();
                    if (!status.IsActive)
                    {
                        if (log.IsInfoEnabled) log.Info("OBS VirtualCam not started. Starting.");
                        obsWS.StartVirtualCam();
                    }
                    else
                    {
                        if (log.IsInfoEnabled) log.Info("OBS VirtualCam already started.");
                    }
                }
                catch (Exception exc)
                {
                    log.Error(exc.Message, exc);
                }
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!Properties.Settings.Default.onlyMView)
            {
                btnOnlyM.Visible = false;
                tableLayoutPanel1.ColumnStyles[1].Width = 0;
                this.MinimumSize = new Size(334, 179);
                this.Width = 334;
            }

            try
            {
                if (log.IsInfoEnabled) log.Info($"Connecting to OBS: {Properties.Settings.Default.OBSURL}");
                obsWS.ConnectAsync(Properties.Settings.Default.OBSURL, Properties.Settings.Default.OBSPassword);
                ZoomLibHelper.SetTargetMonitor(Properties.Settings.Default.SecondDisplay);

                JwLibHelper.BringToFront();

                // FOR TESTING - Comment out when not testing
                //client = new frmClient(); 
                //client.Top = this.Bottom;
                //client.Show();
                // END FOR TESTING

                this.TopMost = Properties.Settings.Default.TopMost;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        private void btnJWLibrary_Click(object sender, EventArgs e)
        {
            try
            {
                if (log.IsInfoEnabled) log.Info("JW library button clicked.");
                JwLibHelper.BringToFront();
                ZoomLibHelper.Minimize();
                OBSHub.IsCurrentlyZoom = false;
                btnJWLibrary.BackColor = Color.Firebrick;
                btnZoom.BackColor = Color.RoyalBlue;

                if (Properties.Settings.Default.onlyMView)
                {
                    OnlyMLibHelper.Minimize();
                    btnOnlyM.BackColor = Color.RoyalBlue;
                }

            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        private void btnOnlyM_Click(object sender, EventArgs e)
        {
            try
            {
                if (log.IsInfoEnabled) log.Info("OnlyM button clicked.");
                OnlyMLibHelper.BringToFront();
                ZoomLibHelper.Minimize();
                OBSHub.IsCurrentlyZoom = false;
                btnJWLibrary.BackColor = Color.RoyalBlue;
                btnOnlyM.BackColor = Color.Firebrick;
                btnZoom.BackColor = Color.RoyalBlue;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            try
            {
                if (log.IsInfoEnabled) log.Info("Zoom button clicked.");

                if (obsWS.IsConnected)
                {
                    if (log.IsInfoEnabled) log.Info("Getting current OBS scene.");
                    var currentScene = obsWS.GetCurrentProgramScene();
                    if (log.IsInfoEnabled) log.Info($"Current OBS scene: {currentScene}");

                    var sceneItems = obsWS.GetSceneItemList(currentScene);

                    if (sceneItems.Any(m => m.SourceKind == "monitor_capture"))
                    {
                        if (log.IsInfoEnabled) log.Info($"Current OBS scene has monitor_capture source");
                        if (!string.IsNullOrWhiteSpace(OBSHub.LastSelectedCamera))
                        {
                            if (log.IsInfoEnabled) log.Info($"Selecting last OBS camera scene: {OBSHub.LastSelectedCamera}");
                            obsWS.SetCurrentProgramScene(OBSHub.LastSelectedCamera);
                        }
                        else
                        {
                            if (log.IsInfoEnabled) log.Info($"Selecting first scene in OBS.");
                            obsWS.SetCurrentProgramScene(obsWS.GetSceneList().Scenes[0].Name);
                        }

                        var result = OBSHub.BuildEnrichedSceneList(obsWS);

                        var hub = GlobalHost.ConnectionManager.GetHubContext("OBSHub");
                        hub.Clients.All.ReceiveScenes(result);
                    }
                }
                if (Properties.Settings.Default.onlyMView)
                {

                    OnlyMLibHelper.Minimize();
                    btnOnlyM.BackColor = Color.RoyalBlue;
                }

                OBSHub.IsCurrentlyZoom = true;
                ZoomLibHelper.BringToFront();
                btnJWLibrary.BackColor = Color.RoyalBlue;
                btnZoom.BackColor = Color.Firebrick;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        private void menuItemSettings_Click(object sender, EventArgs e)
        {
            frmSettingsServer settings = new frmSettingsServer();
            settings.Load += (s, e2) => settings.UpdateOBSStatusDisplay(_lastOBSStatus);
            settings.ShowDialog();
        }

        private void menuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void menuItemLog_Click(object sender, EventArgs e)
        {
            string tempFolder = Path.GetTempPath();
            string logFilePath = Path.Combine(tempFolder, "KHSwitcher.log");

            if (File.Exists(logFilePath))
            {
                Process.Start(new ProcessStartInfo
                {
                    FileName = logFilePath,
                    UseShellExecute = true
                });
            }
            else
            {
                MessageBox.Show("Log file not found at: " + logFilePath);
            }
        }

        private void UpdateOBSStatus(bool connected)
        {
            if (connected == _lastOBSStatus) return;
            _lastOBSStatus = connected;

            BeginInvoke((MethodInvoker)(() =>
            {
                if (connected)
                {
                    serverStatusMenu.Image = Properties.Resources.ok_status_8px;
                    serverStatusMenu.ToolTipText = "OBS Connected";
                    serverStatusMenu.ForeColor = Color.Green;
                    serverStatusMenu.Text = "OBS Connected";
                    serverStatusMenu.BackColor = Color.Honeydew;
                }
                else
                {
                    serverStatusMenu.Image = Properties.Resources.off_status_8px;
                    serverStatusMenu.ToolTipText = "OBS Disconnected\nEnsure OBS is running.\nSee Wiki for more help.";
                    serverStatusMenu.ForeColor = Color.Firebrick;
                    serverStatusMenu.Text = "OBS Disconnected";
                    serverStatusMenu.BackColor = Color.MistyRose;
                }

                // Update settings form if open
                var settingsForm = Application.OpenForms["frmSettingsServer"] as frmSettingsServer;
                settingsForm?.UpdateOBSStatusDisplay(connected);
            }));

            OBSHub.BroadcastOBSStatus(connected);
        }

        private void menuItemUpdate_Click(object sender, EventArgs e)
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

        private void menuItemAbout_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        public void ApplySettings()
        {
            this.TopMost = Properties.Settings.Default.TopMost;

            ZoomLibHelper.SetTargetMonitor(Properties.Settings.Default.SecondDisplay);

            if (!Properties.Settings.Default.onlyMView)
            {
                btnOnlyM.Visible = false;
                tableLayoutPanel1.ColumnStyles[1].Width = 0;
                this.MinimumSize = new Size(334, 179);
                this.Width = 334;
            }
            else
            {
                btnOnlyM.Visible = true;
                tableLayoutPanel1.ColumnStyles[1].Width = 33;
                this.MinimumSize = new Size(484, 179);
                this.Width = 484;
            }

            // Reconnect to OBS with new settings
            if (obsWS.IsConnected)
                obsWS.Disconnect();

            obsWS.ConnectAsync(Properties.Settings.Default.OBSURL, Properties.Settings.Default.OBSPassword);
        }
    }
}