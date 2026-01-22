using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Objects.Obstacles
{
    public class LogObstacle : Obstacle
    {
        public LogObstacle(Texture2D tex, Vector2 pos) : base(tex, pos) { }

        public override void OnCollide(SkierSprite skier)
        {
            // Boomstam => skier sterft, boomstam blijft bestaan :contentReference[oaicite:2]{index=2}
            skier.Kill();
        }
    }
}
