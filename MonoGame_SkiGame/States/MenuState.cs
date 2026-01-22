using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MonoGame_SkiGame.Core;
using MonoGame_SkiGame.Domain;
using MonoGame_SkiGame.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.States
{
    public class MenuState: State
    {
        private int _selectedIndex = 0;
        private readonly (string label, GameMode mode)[] _items =
        {
            ("1 Skien zonder vijanden", GameMode.NoEnemies),
            ("2 Obstakels  een skier", GameMode.ObstaclesSingleSkier),
            ("3 Obstakels drie skiers zelfde input", GameMode.ObstaclesThreeSkiersSameInput),
            ("4 Obstakels 2 spelers arrows vs QZSD", GameMode.ObstaclesTwoPlayersDifferentInput),
        };

        public MenuState(Game1 context) : base(context) { }

        public override void Update(GameTime gameTime)
        {
            if (InputFacade.WasKeyJustPressed(Keys.Down))
                _selectedIndex = (_selectedIndex + 1) % _items.Length;

            if (InputFacade.WasKeyJustPressed(Keys.Up))
                _selectedIndex = (_selectedIndex - 1 + _items.Length) % _items.Length;

            if (InputFacade.WasKeyJustPressed(Keys.Enter))
            {
                var mode = _items[_selectedIndex].mode;
                Context.ChangeState(new PlayingState(Context, mode));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            var sb = Context._spriteBatch;
            var font = Context._font;

            sb.DrawCenteredString(font, "SKI GAME", new Vector2(Game1.SCREEN_W / 2f, 120), Color.White);
            sb.DrawCenteredString(font, "Kies een modus (Up/Down + Enter)", new Vector2(Game1.SCREEN_W / 2f, 170), Color.White);

            var y = 260f;
            for (int i = 0; i < _items.Length; i++)
            {
                var prefix = (i == _selectedIndex) ? "> " : "  ";
                var text = prefix + _items[i].label;

                var color = (i == _selectedIndex) ? Color.Yellow : Color.White;
                sb.DrawString(font, text, new Vector2(60, y), color);
                y += 50;
            }

            sb.DrawString(font, "Esc = Quit", new Vector2(20, Game1.SCREEN_H - 40), Color.White);
        }
    }
}
