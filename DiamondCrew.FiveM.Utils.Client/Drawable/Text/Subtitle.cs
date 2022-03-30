using CitizenFX.Core.Native;

namespace DiamondCrew.FiveM.Utils.Client.Draw
{
    public class Subtitle : Drawable
    {
        public Subtitle(string text, int duration = 0)
        {
            _text = text;
            _duration = duration;
        }
        
        private readonly string _text;
        private readonly int _duration;

        public void Draw()
        {
            API.ClearPrints();
            API.BeginTextCommandPrint("STRING");
            API.AddTextComponentSubstringPlayerName(_text);
            API.EndTextCommandPrint(_duration, true);
        }
    }
}