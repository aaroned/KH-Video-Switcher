using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace KH_Video_Switcher
{
    public class OBSHub : Hub
    {
        public static volatile bool IsCurrentlyZoom;
        public static volatile bool LastOBSStatus;
        public static volatile string LastSelectedCamera;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public static EnrichedSceneList BuildEnrichedSceneList(OBSWebsocketDotNet.OBSWebsocket obsWS)
        {
            var result = obsWS.GetSceneList();
            return new EnrichedSceneList
            {
                CurrentProgramSceneName = result.CurrentProgramSceneName,
                Scenes = result.Scenes.AsEnumerable().Reverse().Select(scene =>
                {
                    var items = obsWS.GetSceneItemList(scene.Name);
                    bool hasCamera = items.Any(m => m.SourceKind == "dshow_input");
                    bool hasMonitor = items.Any(m => m.SourceKind == "monitor_capture");
                    return new EnrichedScene
                    {
                        Name = scene.Name,
                        IsMonitorCapture = hasMonitor && !hasCamera,
                        IsPictureInPicture = hasCamera && hasMonitor
                    };
                }).ToList()
            };
        }
        public static void BroadcastOBSStatus(bool connected)
        {
            LastOBSStatus = connected;
            var hub = GlobalHost.ConnectionManager.GetHubContext("OBSHub");
            hub.Clients.All.ReceiveOBSStatus(connected);
        }
        public void GetOBSStatus()
        {
            Clients.Caller.ReceiveOBSStatus(LastOBSStatus);
        }
        public Task GetScenes()
        {
            try
            {
                var obsWS = frmServer.OBSConnection;
                if (obsWS == null || !obsWS.IsConnected)
                { 
                    log.Warn("Request to get scenes failed because OBS is not connected.");
                    return Task.CompletedTask;
                }

                var result = BuildEnrichedSceneList(obsWS);
                Clients.Caller.ReceiveScenes(result);
                return Task.CompletedTask;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                return Task.CompletedTask;
            }
        }

        public Task SetScene(string name)
        {
            try
            {
                if (log.IsInfoEnabled) log.Info("Client requesting server to set camera");

                var obsWS = frmServer.OBSConnection;
                if (obsWS == null || !obsWS.IsConnected)
                {
                    log.Warn("Request to set scene failed because OBS is not connected.");
                    return Task.CompletedTask;
                }

                if (log.IsInfoEnabled) log.Info($"Get scene items for: {name}");
                var sceneItemList = obsWS.GetSceneItemList(name);

                if (!IsCurrentlyZoom || !sceneItemList.Any(m => m.SourceKind == "monitor_capture"))  //if not currently showing Zoom, or not transitioning to screen capture
                {
                    if (log.IsInfoEnabled) log.Info($"Set OBS scene to: {name}");
                    obsWS.SetCurrentProgramScene(name);
                }

                if (sceneItemList.Any(m => m.SourceKind == "dshow_input") && !sceneItemList.Any(m => m.SourceKind == "monitor_capture")) //if a pure camera scene (no monitor capture), remember the history
                {
                    if (log.IsInfoEnabled) log.Info("Save last selected camera.");
                    LastSelectedCamera = name;
                }

                var result = BuildEnrichedSceneList(obsWS);
                Clients.All.ReceiveScenes(result);
                return Task.CompletedTask;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                return Task.CompletedTask;
            }
        }
        public static void BroadcastZoomStatus(bool isZoom)
        {
            IsCurrentlyZoom = isZoom;
            var hub = GlobalHost.ConnectionManager.GetHubContext("OBSHub");
            hub.Clients.All.ReceiveZoomStatus(isZoom);
        }

        public void GetZoomStatus()
        {
            Clients.Caller.ReceiveZoomStatus(IsCurrentlyZoom);
        }
    }
    public class EnrichedScene
    {
        public string Name { get; set; }
        public bool IsMonitorCapture { get; set; }
        public bool IsPictureInPicture { get; set; }
    }

    public class EnrichedSceneList
    {
        public string CurrentProgramSceneName { get; set; }
        public List<EnrichedScene> Scenes { get; set; }
    }
}