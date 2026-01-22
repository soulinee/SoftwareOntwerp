using MonoGame_SkiGame.Objects;
using MonoGame_SkiGame.Objects.Obstacles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Domain
{
    public class GameSession
    {
        public GameMode Mode { get; }
        public List<SkierSprite> Skiers { get; } = new();
        public List<Obstacle> Obstacles { get; } = new();

        public bool IsGameOver => Skiers.All(s => s.IsDead);

        public GameSession(GameMode mode)
        {
            Mode = mode;
        }

        public void RemoveDeadObstacles()
        {
            Obstacles.RemoveAll(o => o.IsExpired);
        }
    }
}
