using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame_SkiGame.Objects.Obstacles;
using MonoGame_SkiGame.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Gameplay
{
    public class ObstacleSpawner
    {
        private readonly IRandomService _rng;
        private readonly Texture2D _rockTex;
        private readonly Texture2D _logTex;
        private readonly Texture2D _snowmanTex;

        private double _tRock;
        private double _tLog;
        private double _tSnowman;

        private int _nextRockMs;
        private int _nextLogMs;
        private int _nextSnowmanMs;

        public ObstacleSpawner(IRandomService rng, Texture2D rock, Texture2D log, Texture2D snowman)
        {
            _rng = rng;
            _rockTex = rock;
            _logTex = log;
            _snowmanTex = snowman;

            RollNextTimes();
        }

        private void RollNextTimes()
        {
            // Spawn ranges volgens opdracht :contentReference[oaicite:5]{index=5}
            _nextRockMs = _rng.Next(500, 2001);
            _nextLogMs = _rng.Next(1500, 5001);
            _nextSnowmanMs = _rng.Next(3000, 10001);
        }

        public void Update(GameTime gameTime, List<Obstacle> obstacles)
        {
            var ms = gameTime.ElapsedGameTime.TotalMilliseconds;

            _tRock += ms;
            _tLog += ms;
            _tSnowman += ms;

            if (_tRock >= _nextRockMs)
            {
                obstacles.Add(SpawnRock());
                _tRock = 0;
                _nextRockMs = _rng.Next(500, 2001);
            }

            if (_tLog >= _nextLogMs)
            {
                obstacles.Add(SpawnLog());
                _tLog = 0;
                _nextLogMs = _rng.Next(1500, 5001);
            }

            if (_tSnowman >= _nextSnowmanMs)
            {
                obstacles.Add(SpawnSnowman());
                _tSnowman = 0;
                _nextSnowmanMs = _rng.Next(3000, 10001);
            }
        }

        private Obstacle SpawnRock()
        {
            var x = _rng.Next(0, Game1.SCREEN_W - _rockTex.Width);
            var y = -_rockTex.Height - _rng.Next(0, 200);
            return new RockObstacle(_rockTex, new Vector2(x, y));
        }

        private Obstacle SpawnLog()
        {
            var x = _rng.Next(0, Game1.SCREEN_W - _logTex.Width);
            var y = -_logTex.Height - _rng.Next(0, 200);
            return new LogObstacle(_logTex, new Vector2(x, y));
        }

        private Obstacle SpawnSnowman()
        {
            var x = _rng.Next(0, Game1.SCREEN_W - _snowmanTex.Width);
            var y = -_snowmanTex.Height - _rng.Next(0, 200);

            // horizontale snelheid: random links/rechts
            var vx = _rng.NextFloat(1.8f, 3.2f);
            if (_rng.Next(0, 2) == 0) vx = -vx;

            return new SnowmanObstacle(_snowmanTex, new Vector2(x, y), vx);
        }
    }
}
