using System.Drawing;
using CitizenFX.Core.Native;

namespace DiamondCrew.FiveM.Utils.Client.Draw
{
    public class DrawableText : DrawableTask
    {
        public DrawableText(string text, int duration = 0, int delay = 1) : base(duration, delay)
        {
            _text = text;
            _textFont = 0;
            _textScale = new TextScale(0, 0.5f);
            _color = Color.White;
            _outline = false;
        }

        private readonly string _text;
        
        private int _textFont;
        private TextScale _textScale;
        private Color _color;
        private bool _outline;

        public DrawableText WithTextFont(int font)
        {
            _textFont = font;
            return this;
        }

        public DrawableText WithTextScale(TextScale textScale)
        {
            _textScale = textScale;
            return this;
        }

        public DrawableText WithColor(Color color)
        {
            _color = color;
            return this;
        }

        public DrawableText WithOutline(bool outline)
        {
            _outline = outline;
            return this;
        }

        public override void Draw()
        {
            API.SetTextFont(_textFont);
            API.SetTextScale(_textScale.Scale, _textScale.Size);
            API.SetTextColour(_color.R, _color.B, _color.G, _color.A);
            if (_outline) API.SetTextOutline();
            API.SetTextCentre(true);

            API.BeginTextCommandDisplayText("STRING");
            API.AddTextComponentSubstringPlayerName(_text);
            API.EndTextCommandDisplayText(0.5f, 0.85f);
        }
    }
}