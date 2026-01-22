using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_SkiGame.Input;
using MonoGame_SkiGame.Objects.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Objects
{
    public class SkierSprite : SpriteEntity
    {
        private readonly IPlayerMovementInputService _input;
        private readonly int _screenW;
        private readonly int _screenH;

        public bool IsDead { get; private set; }

        public SkierSprite(Texture2D texture, Vector2 startPos, IPlayerMovementInputService input, int screenW, int screenH)
            : base(texture, startPos)
        {
            _input = input;
            _screenW = screenW;
            _screenH = screenH;
        }

        public void Kill() => IsDead = true;

        public void NudgeBack(float pixels)
        {
            // "vallen achteruit" => in screen coords is dat omhoog (kleinere Y)
            Position = new Vector2(Position.X, Position.Y - pixels);
            ClampToScreen();
        }

        public void Move(Vector2 delta)
        {
            if (IsDead) return;

            Position += delta;
            ClampToScreen();
        }

        public bool HasMovementInput()
            => _input.GetMovementDirection() != Vector2.Zero;

        public Vector2 GetMovementDirection()
            => _input.GetMovementDirection();

        private void ClampToScreen()
        {
            var x = MathHelper.Clamp(Position.X, 0, _screenW - Texture.Width);
            var y = MathHelper.Clamp(Position.Y, 0, _screenH - Texture.Height);
            Position = new Vector2(x, y);
        }
    }
}
