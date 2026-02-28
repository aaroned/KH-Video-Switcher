using Microsoft.AspNet.SignalR.Client;
using OBSWebsocketDotNet.Types;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using log4net;

namespace KH_Video_Switcher
{
    public partial class frmClient : Form
    {
        private IHubProxy hub;
        private EnrichedSceneList scenes;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmClient()
        {
            InitializeComponent();
            var top = Screen.PrimaryScreen.Bounds.Top;
            var left = (int)(Screen.PrimaryScreen.Bounds.X + ((Screen.PrimaryScreen.Bounds.Width - this.Size.Width) / 2));
            this.Location = new Point(left, top);
        }

        private void GetScenes()
        {
            hub.Invoke("GetScenes").Wait();
        }

        private void SetScene(string name)
        {
            hub.Invoke("SetScene",name).Wait();
        }

        private async void frmClient_Load(object sender, EventArgs e)
        {
            await ConnectWithRetry();
        }

        private async Task ConnectWithRetry()
        {
            int attempt = 0;
            int maxAttempts = 3;
            int delaySeconds = 5;

            while (attempt < maxAttempts)
            {
                try
                {
                    attempt++;
                    if (log.IsInfoEnabled) log.Info($"Connection attempt {attempt} of {maxAttempts}");

                    if (hub == null)
                    {
                        var connection = new HubConnection(ConfigurationManager.AppSettings["ServerURL"]);
                        hub = connection.CreateHubProxy("OBSHub");
                        hub.On<EnrichedSceneList>("ReceiveScenes", s => ReceiveScenes(s));
                        await connection.Start();
                        if (log.IsInfoEnabled) log.Info("Connected to server successfully");
                    }

                    if (log.IsInfoEnabled) log.Info("Requesting scenes from server");
                    GetScenes();

                    // Wait briefly to give ReceiveScenes a chance to fire
                    await Task.Delay(2000);

                    if (scenes != null)
                    {
                        if (log.IsInfoEnabled) log.Info("Scenes received successfully");
                        this.Text = "KH Switcher (Zoom)";
                        return; // success
                    }

                    log.Warn($"No scenes received on attempt {attempt}, OBS may not be ready");
                    this.Text = $"KH Switcher (Zoom) - Waiting for OBS... ({attempt}/{maxAttempts})";
                    await Task.Delay((delaySeconds * 1000) - 2000); // subtract the 2s already waited
                }
                catch (Exception ex)
                {
                    hub = null; // force reconnect on next attempt
                    log.Warn($"Connection attempt {attempt} failed: {ex.Message}");
                    this.Text = $"KH Switcher (Zoom) - Waiting for server... ({attempt}/{maxAttempts})";
                    await Task.Delay(delaySeconds * 1000);
                }

                if (attempt >= maxAttempts)
                {
                    log.Error("Max connection attempts reached");
                    this.Text = "KH Switcher (Zoom) - Connection Failed";

                    var msgBox = new Form() { TopMost = true };
                    MessageBox.Show(msgBox,
                        "Could not connect after several attempts. Please check the server and OBS are running and use Refresh to try again.",
                        "Connection Failed",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
            }
        }

        private void UpdateSceneButtonColors()
        {
            foreach (Button sceneButton in tableLayoutPanel1.Controls)
            {
                sceneButton.BackColor = (sceneButton.Text == scenes.CurrentProgramSceneName ? Color.DarkRed : Color.RoyalBlue);
            }
        }

        private void sceneButtonClick(object sender, EventArgs e)
        {
            this.TopLevel = true;
            this.TopMost = true;

            var scene = ((Button)sender).Text;
            scenes.CurrentProgramSceneName = scene;
            SetScene(scene);
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
                        var sceneName = scenes.Scenes[i].Name;

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
                hub = null; // force a full reconnect
                await ConnectWithRetry();
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
        }
    }
}
