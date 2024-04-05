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

namespace KH_Video_Switcher
{
    public partial class frmClient : Form
    {
        private IHubProxy hub;
        private GetSceneListInfo scenes;
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

        private void frmClient_Load(object sender, EventArgs e)
        {
            var connection = new HubConnection(ConfigurationManager.AppSettings["ServerURL"]);
            hub = connection.CreateHubProxy("OBSHub");
            hub.On<GetSceneListInfo>("ReceiveScenes", s => ReceiveScenes(s));
            connection.Start().Wait();
            
            GetScenes();
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

        private void ReceiveScenes(GetSceneListInfo data)
        {
            //Invoke on the UI Thread
            this.Invoke(new MethodInvoker(delegate ()
            {
                if (scenes == null)
                {
                    scenes = data;


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

                }
                else
                {
                    scenes = data;
                    UpdateSceneButtonColors();
                }
            }));
        }
    }
}
