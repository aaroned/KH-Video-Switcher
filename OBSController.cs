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

        // GET api/zoom/5 
        [HttpGet]
        public async Task<GetSceneListInfo> GetAsync(int id)
        {
            var obsWS = new OBSWebsocketDotNet.OBSWebsocket();
            obsWS.Connect(ConfigurationManager.AppSettings["OBSURL"], ConfigurationManager.AppSettings["OBSPassword"]);

            var waitCount = 0;
            while(!obsWS.IsConnected)
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

        // PUT api/zoom/5 
        [HttpPut]
        public async Task<GetSceneListInfo> Put(int id, GetSceneListInfo scenes)
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

            var sceneItemList = obsWS.GetSceneItemList(scenes.CurrentProgramSceneName);

            if (!IsCurrentlyZoom || !sceneItemList.Any(m => m.SourceKind == "monitor_capture")) //if not currently showing Zoom, or not transitioning to screen capture
                obsWS.SetCurrentProgramScene(scenes.CurrentProgramSceneName);

            if (sceneItemList.Any(m => m.SourceKind == "dshow_input")) //if a camera scene rember the history
                LastSelectedCamera = scenes.CurrentProgramSceneName;

            var result = obsWS.GetSceneList();

            obsWS.Disconnect();

            return result;
        }
    }
}
