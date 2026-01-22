using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame_SkiGame.Core;
using MonoGame_SkiGame.Services;
using MonoGame_SkiGame.States;
using MonoGame_SkiGame.States.Base;

namespace MonoGame_SkiGame
{
    public class Game1 : Game
    {
        // Tweakables (geen magic numbers overal)
        internal const int SCREEN_W = 640;
        internal const int SCREEN_H = 960;

        internal const float WORLD_SCROLL_SPEED = 3.0f;     // piste scroll
        internal const float PLAYER_SPEED = 6.0f;           // input move
        internal const float IDLE_DRIFT_UP = 1.2f;          // geen input => trager dan world => "naar boven geduwd"

        internal GraphicsDeviceManager _graphics;
        internal SpriteBatch _spriteBatch;

        internal SpriteFont _font;

        private State _currentState;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        internal void ChangeState(State newState)
        {
            _currentState = newState;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = SCREEN_W;
            _graphics.PreferredBackBufferHeight = SCREEN_H;
            _graphics.ApplyChanges();

            ContentService.Initialize(this);

            ChangeState(new MenuState(this));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _font = Content.Load<SpriteFont>("GameFont");
        }

        protected override void Update(GameTime gameTime)
        {
            InputFacade.Update();

            if (InputFacade.WasKeyJustPressed(Keys.Escape))
                Exit();

            _currentState?.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);

            _currentState?.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }


    }
}
