using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Objects.Base
{
    public abstract class SpriteEntity
    {
        protected Texture2D Texture { get; }
        public Vector2 Position;

        protected SpriteEntity(Texture2D texture, Vector2 position)
        {
            Texture = texture;
            Position = position;
        }

        public virtual Rectangle Bounds =>
            new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);

        public virtual void Update(GameTime gameTime) { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
