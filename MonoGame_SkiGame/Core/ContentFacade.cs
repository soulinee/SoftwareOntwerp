using Microsoft.Xna.Framework.Graphics;
using MonoGame_SkiGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Core
{
    public static class ContentFacade
    {
        public static Texture2D LoadTexture(string assetName)
            => ContentService.Content.Load<Texture2D>(assetName);
    }
}
