using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_SkiGame.Objects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Objects.Obstacles
{
    public abstract class Obstacle : SpriteEntity
    {
        public bool IsExpired { get; protected set; }

        protected Obstacle(Texture2D texture, Vector2 position) : base(texture, position) { }

        public void ScrollDown(float worldScrollSpeed)
        {
            Position = new Vector2(Position.X, Position.Y + worldScrollSpeed);

            // zodra volledig uit beeld => cleanup
            if (Position.Y > Game1.SCREEN_H + Texture.Height)
                IsExpired = true;
        }

        public abstract void OnCollide(SkierSprite skier);
    }
}
