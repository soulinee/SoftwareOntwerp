using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using MonoGame_SkiGame.Core;
using MonoGame_SkiGame.Domain;
using MonoGame_SkiGame.Gameplay;
using MonoGame_SkiGame.Input;
using MonoGame_SkiGame.Objects;
using MonoGame_SkiGame.Services;
using MonoGame_SkiGame.States.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGame_SkiGame.States
{
    public class PlayingState: State
    {
        private readonly GameSession _session;

        private readonly Texture2D _pisteTex;
        private readonly Texture2D _skierTex;
        private readonly Texture2D _skier2Tex;

        private readonly Texture2D _rockTex;
        private readonly Texture2D _logTex;
        private readonly Texture2D _snowmanTex;

        private readonly BackgroundScroller _background;
        private readonly ObstacleSpawner _spawner;
        private readonly CollisionService _collisions;

        private readonly bool _spawnEnabled;

        public PlayingState(Game1 context, GameMode mode) : base(context)
        {
            _session = new GameSession(mode);

            // Load textures via Content (centralized usage)
            _pisteTex = ContentFacade.LoadTexture("piste");
            _skierTex = ContentFacade.LoadTexture("skier");
            _skier2Tex = ContentFacade.LoadTexture("skier2");

            _rockTex = ContentFacade.LoadTexture("rock");
            _logTex = ContentFacade.LoadTexture("log");
            _snowmanTex = ContentFacade.LoadTexture("snowman");

            _background = new BackgroundScroller(_pisteTex);
            _collisions = new CollisionService();

            _spawnEnabled = mode != GameMode.NoEnemies;
            _spawner = new ObstacleSpawner(new RandomService(), _rockTex, _logTex, _snowmanTex);

            CreatePlayers(mode);
        }

        private void CreatePlayers(GameMode mode)
        {
            // start positions: onderaan, wat gespreid
            var baseY = Game1.SCREEN_H - 160;

            if (mode == GameMode.ObstaclesTwoPlayersDifferentInput)
            {
                var p1 = new SkierSprite(_skierTex, new Vector2(170, baseY), new ArrowKeysInputService(), Game1.SCREEN_W, Game1.SCREEN_H);
                var p2 = new SkierSprite(_skier2Tex, new Vector2(300, baseY), new QzsdInputService(), Game1.SCREEN_W, Game1.SCREEN_H);
                _session.Skiers.Add(p1);
                _session.Skiers.Add(p2);
                return;
            }

            // single input service (arrows) reused for 1 or 3 skiers
            var arrows = new ArrowKeysInputService();

            if (mode == GameMode.ObstaclesThreeSkiersSameInput)
            {
                _session.Skiers.Add(new SkierSprite(_skierTex, new Vector2(120, baseY), arrows, Game1.SCREEN_W, Game1.SCREEN_H));
                _session.Skiers.Add(new SkierSprite(_skierTex, new Vector2(240, baseY), arrows, Game1.SCREEN_W, Game1.SCREEN_H));
                _session.Skiers.Add(new SkierSprite(_skierTex, new Vector2(360, baseY), arrows, Game1.SCREEN_W, Game1.SCREEN_H));
                return;
            }

            // default: 1 skier
            _session.Skiers.Add(new SkierSprite(_skierTex, new Vector2(240, baseY), arrows, Game1.SCREEN_W, Game1.SCREEN_H));
        }

        public override void Update(GameTime gameTime)
        {
            // pauze togglen met P :contentReference[oaicite:6]{index=6}
            if (InputFacade.WasKeyJustPressed(Keys.P))
            {
                Context.ChangeState(new PauzeState(Context, this));
                return;
            }

            // background scroll
            _background.Update(Game1.WORLD_SCROLL_SPEED);

            // obstakels spawnen volgens timers (niet in NoEnemies) :contentReference[oaicite:7]{index=7}
            if (_spawnEnabled)
                _spawner.Update(gameTime, _session.Obstacles);

            // world scroll op obstacles
            foreach (var o in _session.Obstacles)
            {
                o.ScrollDown(Game1.WORLD_SCROLL_SPEED);
                o.Update(gameTime); // snowman horizontaal
            }

            // player movement
            foreach (var skier in _session.Skiers)
            {
                if (skier.IsDead) continue;

                var dir = skier.GetMovementDirection();
                if (dir != Vector2.Zero)
                {
                    dir.Normalize();
                    skier.Move(dir * Game1.PLAYER_SPEED);
                }
                else
                {
                    // geen input => trager dan scroll => lijkt omhoog geduwd :contentReference[oaicite:8]{index=8}
                    skier.Move(new Vector2(0, -Game1.IDLE_DRIFT_UP));
                }
            }

            // collisions
            _collisions.HandleCollisions(_session.Skiers, _session.Obstacles);

            // cleanup
            _session.RemoveDeadObstacles();

            // game over als iedereen dood is :contentReference[oaicite:9]{index=9}
            if (_session.IsGameOver)
            {
                Context.ChangeState(new GameOverState(Context));
            }
        }

        public override void Draw(GameTime gameTime)
        {
            var sb = Context._spriteBatch;

            _background.Draw(sb);

            foreach (var o in _session.Obstacles)
                o.Draw(sb);

            foreach (var skier in _session.Skiers)
                if (!skier.IsDead) skier.Draw(sb);

            // UI: remaining alive
            var alive = 0;
            foreach (var s in _session.Skiers)
                if (!s.IsDead) alive++;

            sb.DrawString(Context._font, $"Alive: {alive}/{_session.Skiers.Count}", new Vector2(12, 12), Color.Black);
            sb.DrawString(Context._font, "P = Pause", new Vector2(12, 44), Color.Black);
        }
    }
}
