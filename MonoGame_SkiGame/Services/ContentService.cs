using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Services
{
    public static class ContentService
    {
        public static ContentManager Content { get; private set; }

        public static void Initialize(Game1 game)
        {
            Content = game.Content;
        }
    }
}
