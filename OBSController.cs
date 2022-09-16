using OBSWebsocketDotNet.Types;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace KH_Video_Switcher
{
    public class OBSController : ApiController
    {
        public static bool IsCurrentlyZoom;
        public static string LastSelectedCamera;

        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        // GET api/zoom/5 
        [HttpGet]
        public async Task<GetSceneListInfo> GetAsync(int id)
        {
            try
            {
                var obsWS = new OBSWebsocketDotNet.OBSWebsocket();
                obsWS.Connect(ConfigurationManager.AppSettings["OBSURL"], ConfigurationManager.AppSettings["OBSPassword"]);

                var waitCount = 0;
                while (!obsWS.IsConnected)
                {
                    await Task.Delay(500);
                    waitCount++;
                    if (waitCount > 10)
                        return null;
                }

                var result = obsWS.GetSceneList();

                obsWS.Disconnect();

                return result;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }

        // PUT api/zoom/5 
        [HttpPut]
        public async Task<GetSceneListInfo> Put(int id, GetSceneListInfo scenes)
        {
            try
            {
                if (log.IsInfoEnabled) log.Info("Client requesting server to set camera");
                var obsWS = new OBSWebsocketDotNet.OBSWebsocket();
                if (log.IsInfoEnabled) log.Info("Connecting to OBS");
                obsWS.Connect(ConfigurationManager.AppSettings["OBSURL"], ConfigurationManager.AppSettings["OBSPassword"]);

                var waitCount = 0;
                while (!obsWS.IsConnected)
                {
                    await Task.Delay(500);
                    waitCount++;
                    if (waitCount > 10)
                    {
                        if (log.IsInfoEnabled) log.Info("OBS connection timeout");
                        return null;
                    }
                }

                if (log.IsInfoEnabled) log.Info($"Get scene items for: {scenes.CurrentProgramSceneName}");
                var sceneItemList = obsWS.GetSceneItemList(scenes.CurrentProgramSceneName);

                if (!IsCurrentlyZoom || !sceneItemList.Any(m => m.SourceKind == "monitor_capture"))  //if not currently showing Zoom, or not transitioning to screen capture
                {
                    if (log.IsInfoEnabled) log.Info($"Set OBS scene to: {scenes.CurrentProgramSceneName}");
                    obsWS.SetCurrentProgramScene(scenes.CurrentProgramSceneName);
                }

                if (sceneItemList.Any(m => m.SourceKind == "dshow_input")) //if a camera scene remember the history
                {
                    if (log.IsInfoEnabled) log.Info("Save last selected camera.");
                    LastSelectedCamera = scenes.CurrentProgramSceneName;
                }

                var result = obsWS.GetSceneList();

                obsWS.Disconnect();

                return result;
            }
            catch (Exception exc)
            {
                log.Error(exc.Message, exc);
                throw;
            }
        }
    }
}
