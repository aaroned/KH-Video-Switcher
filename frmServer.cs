using JW_Library_Focuser;
using Microsoft.Owin.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
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
        private frmClient client;

        public frmServer()
        {
            InitializeComponent();

            server = WebApp.Start<ServerStartup>("http://+:7004");

            obsWS = new OBSWebsocketDotNet.OBSWebsocket();
            obsWS.Connected += ObsWS_Connected;

            var top = Screen.PrimaryScreen.Bounds.Top;
            var left = (int)(Screen.PrimaryScreen.Bounds.X + ((Screen.PrimaryScreen.Bounds.Width - this.Size.Width) / 2));
            this.Location = new Point(left,top);           
        }

        private void ObsWS_Connected(object sender, EventArgs e)
        {
            BeginInvoke((MethodInvoker)(() =>
            {
                var status = obsWS.GetVirtualCamStatus();
                if (!status.IsActive)
                    obsWS.StartVirtualCam();
            }));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            obsWS.Connect(ConfigurationManager.AppSettings["OBSURL"], ConfigurationManager.AppSettings["OBSPassword"]);                        

            JwLibHelper.BringToFront();

            //client = new frmClient();
            //client.Show();
        }

        //private void sceneButtonClick(object sender, EventArgs e)
        //{
        //    this.TopLevel = true;
        //    this.TopMost = true;

        //    var scene = ((Button)sender).Text;
        //    obsWS.SetCurrentProgramScene(scene);

        //    foreach (Button sceneButton in tableLayoutPanel1.Controls)
        //    {
        //        sceneButton.BackColor = (sceneButton == sender ? Color.DarkRed : Color.RoyalBlue);
        //    }        
        //}

        private void btnJWLibrary_Click(object sender, EventArgs e)
        {
            JwLibHelper.BringToFront();
            ZoomLibHelper.Minimize();
            OnlyMLibHelper.Minimize();
            OBSController.IsCurrentlyZoom = false;
            btnJWLibrary.BackColor = Color.DarkRed;
            btnOnlyM.BackColor = Color.RoyalBlue;
            btnZoom.BackColor = Color.RoyalBlue;
        }

        private void btnOnlyM_Click(object sender, EventArgs e)
        {
            OnlyMLibHelper.BringToFront();
            ZoomLibHelper.Minimize();
            OBSController.IsCurrentlyZoom = false;
            btnJWLibrary.BackColor = Color.RoyalBlue;
            btnOnlyM.BackColor = Color.DarkRed;
            btnZoom.BackColor = Color.RoyalBlue;
        }

        private void btnZoom_Click(object sender, EventArgs e)
        {
            if (obsWS.IsConnected)
            {
                var currentScene = obsWS.GetCurrentProgramScene();
                var sceneItems = obsWS.GetSceneItemList(currentScene);

                if (sceneItems.Any(m => m.SourceKind == "monitor_capture")) //if currently capturing screen, change to last camera, or first camera
                {
                    if (!string.IsNullOrWhiteSpace(OBSController.LastSelectedCamera))
                        obsWS.SetCurrentProgramScene(OBSController.LastSelectedCamera);
                    else
                        obsWS.SetCurrentProgramScene(obsWS.GetSceneList().Scenes[0].Name);
                }
            }

            OBSController.IsCurrentlyZoom = true;
            ZoomLibHelper.BringToFront();
            OnlyMLibHelper.Minimize();
            btnJWLibrary.BackColor = Color.RoyalBlue;
            btnOnlyM.BackColor = Color.RoyalBlue;
            btnZoom.BackColor = Color.DarkRed;
        }
    }
}
