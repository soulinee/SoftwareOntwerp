using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Input
{
    public interface IPlayerMovementInputService
    {
        Vector2 GetMovementDirection();
    }
}
