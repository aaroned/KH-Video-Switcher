using JW_Library_Focuser;
using log4net;
using Microsoft.AspNet.SignalR;
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
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public frmServer()
        {
            InitializeComponent();

            try
            {
                if (log.IsInfoEnabled) log.Info("Starting server on port 7004");
                server = WebApp.Start<ServerStartup>("http://+:7004");

                obsWS = new OBSWebsocketDotNet.OBSWebsocket();
                obsWS.Connected += ObsWS_Connected;

                var top = Screen.PrimaryScreen.Bounds.Top;
                var left = (int)(Screen.PrimaryScreen.Bounds.X + ((Screen.PrimaryScreen.Bounds.Width - this.Size.Width) / 2));
                this.Location = new Point(left, top);
            }
            catch (Exception exc)
            {
                log.Error(exc.Message,exc);
                throw;
            }
        }

        private void ObsWS_Connected(object sender, EventArgs e)
        {
            try
            {

                if (log.IsInfoEnabled) log.Info("OBS WS Connected");
                BeginInvoke((MethodInvoker)(() =>
                {
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
                        throw;
                    }
                }));
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                if (log.IsInfoEnabled) log.Info($"Connectinng to OBS: {ConfigurationManager.AppSettings["OBSURL"]}");
                obsWS.ConnectAsync(ConfigurationManager.AppSettings["OBSURL"], ConfigurationManager.AppSettings["OBSPassword"]);

                JwLibHelper.BringToFront();

                //client = new frmClient();
                //client.Show();

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
                OnlyMLibHelper.Minimize();
                OBSHub.IsCurrentlyZoom = false;                
                btnJWLibrary.BackColor = Color.DarkRed;
                btnOnlyM.BackColor = Color.RoyalBlue;
                btnZoom.BackColor = Color.RoyalBlue;
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
                btnOnlyM.BackColor = Color.DarkRed;
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
                                        
                    if (sceneItems.Any(m => m.SourceKind == "monitor_capture")) //if currently capturing screen, change to last camera, or first camera
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

                        var result = obsWS.GetSceneList();

                        var hub = GlobalHost.ConnectionManager.GetHubContext("OBSHub");
                        hub.Clients.All.ReceiveScenes(result);
                    }
                }

                OBSHub.IsCurrentlyZoom = true;
                ZoomLibHelper.BringToFront();
                OnlyMLibHelper.Minimize();
                btnJWLibrary.BackColor = Color.RoyalBlue;
                btnOnlyM.BackColor = Color.RoyalBlue;
                btnZoom.BackColor = Color.DarkRed;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }
    }
}
