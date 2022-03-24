using System;
using CitizenFX.Core;
using CitizenFX.Core.Native;

namespace DiamondCrew.FiveM.Utils.Server
{
    public abstract class DiamondScript : BaseScript
    {
        protected DiamondScript()
        {
            SetupListeners();
        }

        protected abstract void OnStart();

        protected abstract void OnStop();
        private void SetupListeners()
        {
            EventHandlers["onResourceStart"] += new Action<string>(resourceName =>
            {
                if (resourceName == API.GetCurrentResourceName())
                {
                    OnStart();
                }
            });
            EventHandlers["onResourceStop"] += new Action<string>(resourceName =>
            {
                if (resourceName == API.GetCurrentResourceName())
                {
                    OnStop();
                }
            });
        }
    }
}