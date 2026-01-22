using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame_SkiGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Input
{
    public class ArrowKeysInputService : IPlayerMovementInputService
    {
        public Vector2 GetMovementDirection()
        {
            var dir = Vector2.Zero;

            if (InputFacade.IsKeyDown(Keys.Left)) dir.X -= 1;
            if (InputFacade.IsKeyDown(Keys.Right)) dir.X += 1;
            if (InputFacade.IsKeyDown(Keys.Up)) dir.Y -= 1;
            if (InputFacade.IsKeyDown(Keys.Down)) dir.Y += 1;

            return dir;
        }
    }
}
