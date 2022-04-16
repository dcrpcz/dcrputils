using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;
using Newtonsoft.Json;

namespace DiamondCrew.FiveM.Utils.Shared
{
    public abstract class DiamondScript : BaseScript
    {
        public readonly string resourceName;
        private readonly ScriptType _scriptType;

        protected DiamondScript(ScriptType type)
        {
            resourceName = API.GetCurrentResourceName();
            _scriptType = type;
            SetupListeners();
        }

        protected abstract void OnStart();

        protected abstract void OnStop();

        private void SetupListeners()
        {
            EventHandlers["onResourceStart"] += new Action<string>(startName =>
            {
                if (startName == resourceName)
                {
                    OnStart();
                }
            });
            EventHandlers["onResourceStop"] += new Action<string>(stopName =>
            {
                if (stopName == resourceName)
                {
                    OnStop();
                }
            });
        }

        public string GetRawConfig(string configName)
        {
            return API.LoadResourceFile("configs", $"files/{resourceName}/{_scriptType.ToString().ToLower()}/{configName}");
        }

        public T GetConfig<T>(string configName)
        {
            return JsonConvert.DeserializeObject<T>(GetRawConfig(configName));
        }
    }
}