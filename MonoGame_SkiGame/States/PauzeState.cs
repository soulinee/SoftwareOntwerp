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
    public class PauzeState: State
    {
        private readonly PlayingState _playing;

        public PauzeState(Game1 context, PlayingState playing) : base(context)
        {
            _playing = playing;
        }

        public override void Update(GameTime gameTime)
        {
            // P opnieuw => hervat :contentReference[oaicite:10]{index=10}
            if (InputFacade.WasKeyJustPressed(Keys.P))
                Context.ChangeState(_playing);

            // Backspace => stop en terug naar menu (beëindigen) :contentReference[oaicite:11]{index=11}
            if (InputFacade.WasKeyJustPressed(Keys.Back))
                Context.ChangeState(new MenuState(Context));
        }

        public override void Draw(GameTime gameTime)
        {
            // Freeze: we tekenen exact dezelfde frame, maar updaten niets :contentReference[oaicite:12]{index=12}
            _playing.Draw(gameTime);

            var sb = Context._spriteBatch;
            sb.DrawCenteredString(Context._font, "Gepauzeerd", new Vector2(Game1.SCREEN_W / 2f, Game1.SCREEN_H / 2f - 30), Color.White);
            sb.DrawCenteredString(Context._font, "P = verder  |  Backspace = menu", new Vector2(Game1.SCREEN_W / 2f, Game1.SCREEN_H / 2f + 20), Color.White);
        }
    }
}
