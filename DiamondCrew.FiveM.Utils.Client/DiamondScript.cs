using System;
using CitizenFX.Core;

namespace DiamondCrew.FiveM.Utils.Client
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
            EventHandlers["onResourceStart"] += new Action(OnStart);
            EventHandlers["onResourceStop"] += new Action(OnStop);
        }
    }
}
