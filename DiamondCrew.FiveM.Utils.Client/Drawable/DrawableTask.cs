using System;
using System.Threading;
using System.Threading.Tasks;
using CitizenFX.Core.Native;

namespace DiamondCrew.FiveM.Utils.Client.Draw
{
    public abstract class DrawableTask : Drawable
    {
        public DrawableTask(int duration, int delay = 1)
        {
            Duration = duration;
            _delay = delay;
        }

        private protected readonly int Duration;
        private readonly int _delay;

        private long startTime = -1;

        public async Task StartDrawing()
        {
            var currentTime = DateTime.Now.Millisecond;
            if (startTime == -1) startTime = currentTime;
            if (currentTime - startTime >= startTime) return;
            
            Draw();

            API.SendNuiMessage("{hello = \"world\", action = \"showMessage\"}");
            await Task.FromResult(_delay);
        }

        public abstract void Draw();
    }
}