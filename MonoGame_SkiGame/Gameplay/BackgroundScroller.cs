using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Gameplay
{
    public class BackgroundScroller
    {
        private readonly Texture2D _piste;
        private float _offsetY;

        public BackgroundScroller(Texture2D pisteTexture)
        {
            _piste = pisteTexture;
            _offsetY = 0;
        }

        public void Update(float scrollSpeed)
        {
            _offsetY += scrollSpeed;
            _offsetY %= _piste.Height;
        }

        public void Draw(SpriteBatch sb)
        {
            // 2 tiles tekenen zodat je continu kan scrollen
            var y1 = -_offsetY;
            var y2 = y1 + _piste.Height;

            sb.Draw(_piste, new Vector2(0, y1), Color.White);
            sb.Draw(_piste, new Vector2(0, y2), Color.White);
        }
    }
}
