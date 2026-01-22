using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Objects.Obstacles
{
    public class SnowmanObstacle : Obstacle
    {
        private float _vx;

        public SnowmanObstacle(Texture2D tex, Vector2 pos, float vx) : base(tex, pos)
        {
            _vx = vx;
        }

        public override void Update(GameTime gameTime)
        {
            // horizontaal bewegen, bounce op schermranden :contentReference[oaicite:3]{index=3}
            Position = new Vector2(Position.X + _vx, Position.Y);

            if (Position.X <= 0)
            {
                Position = new Vector2(0, Position.Y);
                _vx = -_vx;
            }
            else if (Position.X >= Game1.SCREEN_W - Texture.Width)
            {
                Position = new Vector2(Game1.SCREEN_W - Texture.Width, Position.Y);
                _vx = -_vx;
            }
        }

        public override void OnCollide(SkierSprite skier)
        {
            // Sneeuwman => skier sterft + sneeuwman verdwijnt :contentReference[oaicite:4]{index=4}
            skier.Kill();
            IsExpired = true;
        }
    }
}
