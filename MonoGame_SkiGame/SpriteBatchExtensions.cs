using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame
{
    public static class SpriteBatchExtensions
    {
        public static void DrawCenteredString(this SpriteBatch sb, SpriteFont font, string text, Vector2 center, Color color)
        {
            var size = font.MeasureString(text);
            sb.DrawString(font, text, center - size / 2f, color);
        }
    }
}
