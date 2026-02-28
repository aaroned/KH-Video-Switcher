using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KH_Video_Switcher
{
    public class OBSHub : Hub
    {
        public static bool IsCurrentlyZoom;
        public static string LastSelectedCamera;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static EnrichedSceneList BuildEnrichedSceneList(OBSWebsocketDotNet.OBSWebsocket obsWS)
        {
            var result = obsWS.GetSceneList();
            return new EnrichedSceneList
            {
                CurrentProgramSceneName = result.CurrentProgramSceneName,
                Scenes = result.Scenes.Select(scene => new EnrichedScene
                {
                    Name = scene.Name,
                    IsMonitorCapture = obsWS.GetSceneItemList(scene.Name)
                                            .Any(m => m.SourceKind == "monitor_capture")
                }).ToList()
            };
        }
        public async void GetScenes() 
        {
            try
            {
                var obsWS = new OBSWebsocketDotNet.OBSWebsocket();
                obsWS.ConnectAsync(ConfigurationManager.AppSettings["OBSURL"], ConfigurationManager.AppSettings["OBSPassword"]);

                var waitCount = 0;
                while (!obsWS.IsConnected)
                {
                    await Task.Delay(500);
                    waitCount++;
                    if (waitCount > 10)
                        return;
                }

                var result = BuildEnrichedSceneList(obsWS);
                obsWS.Disconnect();

                Clients.Caller.ReceiveScenes(result);
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        public async void SetScene(string name)
        {
            try
            {
                if (log.IsInfoEnabled) log.Info("Client requesting server to set camera");
                var obsWS = new OBSWebsocketDotNet.OBSWebsocket();
                if (log.IsInfoEnabled) log.Info("Connecting to OBS");
                obsWS.ConnectAsync(ConfigurationManager.AppSettings["OBSURL"], ConfigurationManager.AppSettings["OBSPassword"]);

                var waitCount = 0;
                while (!obsWS.IsConnected)
                {
                    await Task.Delay(500);
                    waitCount++;
                    if (waitCount > 10)
                    {
                        if (log.IsInfoEnabled) log.Info("OBS connection timeout");
                        return;
                    }
                }

                if (log.IsInfoEnabled) log.Info($"Get scene items for: {name}");
                var sceneItemList = obsWS.GetSceneItemList(name);

                if (!IsCurrentlyZoom || !sceneItemList.Any(m => m.SourceKind == "monitor_capture"))  //if not currently showing Zoom, or not transitioning to screen capture
                {
                    if (log.IsInfoEnabled) log.Info($"Set OBS scene to: {name}");
                    obsWS.SetCurrentProgramScene(name);
                }

                if (sceneItemList.Any(m => m.SourceKind == "dshow_input")) //if a camera scene remember the history
                {
                    if (log.IsInfoEnabled) log.Info("Save last selected camera.");
                    LastSelectedCamera = name;
                }

                var result = BuildEnrichedSceneList(obsWS);
                obsWS.Disconnect();

                Clients.All.ReceiveScenes(result);
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }
    }
    public class EnrichedScene
    {
        public string Name { get; set; }
        public bool IsMonitorCapture { get; set; }
    }

    public class EnrichedSceneList
    {
        public string CurrentProgramSceneName { get; set; }
        public List<EnrichedScene> Scenes { get; set; }
    }
}
