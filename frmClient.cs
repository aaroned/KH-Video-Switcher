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

namespace KH_Video_Switcher
{
    public partial class frmClient : Form
    {
        private HttpClient client = new HttpClient();
        private GetSceneListInfo scenes;
        public frmClient()
        {
            InitializeComponent();
            var top = Screen.PrimaryScreen.Bounds.Top;
            var left = (int)(Screen.PrimaryScreen.Bounds.X + ((Screen.PrimaryScreen.Bounds.Width - this.Size.Width) / 2));
            this.Location = new Point(left, top);
        }
        private async Task GetScenesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"api/OBS/1");
                if (response.IsSuccessStatusCode)
                {
                    scenes = await response.Content.ReadAsAsync<GetSceneListInfo>();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void GetScenes()
        {
            Task.Run(() => GetScenesAsync()).Wait();
        }

        private async Task PutScenesAsync()
        {
            try
            {
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/OBS/1", scenes);
                response.EnsureSuccessStatusCode();
                scenes = await response.Content.ReadAsAsync<GetSceneListInfo>();
            }
            catch (Exception)
            {

            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            client.BaseAddress = new Uri(ConfigurationManager.AppSettings["ServerURL"]);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = new TimeSpan(0, 0, 30);
            GetScenes();

            if (scenes == null)
            {
                MessageBox.Show("Could not connect to OBS. Please check OBS is running on the server.");
                this.Close();
                return;
            }


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
                sceneButton.Click += sceneButtonClick;
                sceneButton.BackColor = (scenes.CurrentProgramSceneName == scenes.Scenes[i].Name ? Color.DarkRed : Color.RoyalBlue);
                sceneButton.ForeColor = Color.White;
                sceneButton.FlatStyle = FlatStyle.Flat;
                sceneButton.Font = new Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                sceneButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
                sceneButton.Image = global::KH_Video_Switcher.Properties.Resources.Cam;
                tableLayoutPanel1.Controls.Add(sceneButton, i, 0);
            }

            currentSceneCheckTimer.Start();
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
            Task.Run(() => PutScenesAsync()).Wait();

            UpdateSceneButtonColors();
        }

        private void currentSceneCheckTimer_Tick(object sender, EventArgs e)
        {
            currentSceneCheckTimer.Stop();
            GetScenes();
            UpdateSceneButtonColors();
            currentSceneCheckTimer.Start();
        }
    }
}
