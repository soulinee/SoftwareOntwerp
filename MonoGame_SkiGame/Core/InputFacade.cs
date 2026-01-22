using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Core
{
    public static class InputFacade
    {
        private static KeyboardState _prev;
        private static KeyboardState _cur;

        public static void Update()
        {
            _prev = _cur;
            _cur = Keyboard.GetState();
        }

        public static bool IsKeyDown(Keys key) => _cur.IsKeyDown(key);

        public static bool WasKeyJustPressed(Keys key) =>
            _cur.IsKeyDown(key) && !_prev.IsKeyDown(key);
    }
}
