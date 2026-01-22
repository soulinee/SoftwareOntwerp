using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame_SkiGame.Core;
using MonoGame_SkiGame.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.States
{
    public class GameOverState: State
    {
        public GameOverState(Game1 context) : base(context) { }

        public override void Update(GameTime gameTime)
        {
            // Enter => terug naar menu :contentReference[oaicite:13]{index=13}
            if (InputFacade.WasKeyJustPressed(Keys.Enter))
                Context.ChangeState(new MenuState(Context));
        }

        public override void Draw(GameTime gameTime)
        {
            var sb = Context._spriteBatch;
            sb.DrawCenteredString(Context._font, "Game Over.", new Vector2(Game1.SCREEN_W / 2f, Game1.SCREEN_H / 2f - 10), Color.White);
            sb.DrawCenteredString(Context._font, "Enter om terug naar menu te gaan", new Vector2(Game1.SCREEN_W / 2f, Game1.SCREEN_H / 2f + 35), Color.White);
        }
    }
}
