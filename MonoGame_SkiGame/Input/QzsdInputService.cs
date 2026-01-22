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
    public class QzsdInputService : IPlayerMovementInputService
    {
        public Vector2 GetMovementDirection()
        {
            var dir = Vector2.Zero;

            // AZERTY: Q (left), D (right), Z (up), S (down)
            if (InputFacade.IsKeyDown(Keys.Q)) dir.X -= 1;
            if (InputFacade.IsKeyDown(Keys.D)) dir.X += 1;
            if (InputFacade.IsKeyDown(Keys.Z)) dir.Y -= 1;
            if (InputFacade.IsKeyDown(Keys.S)) dir.Y += 1;

            return dir;
        }
    }
}
