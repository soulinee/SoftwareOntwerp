using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Objects.Obstacles
{
    public class RockObstacle : Obstacle
    {
        public RockObstacle(Texture2D tex, Vector2 pos) : base(tex, pos) { }

        public override void OnCollide(SkierSprite skier)
        {
            // Rots => skier struikelt en valt stukje achteruit, rots blijft bestaan :contentReference[oaicite:1]{index=1}
            skier.NudgeBack(70f);
        }
    }
}
