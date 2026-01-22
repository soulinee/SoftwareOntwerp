using MonoGame_SkiGame.Objects.Obstacles;
using MonoGame_SkiGame.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Gameplay
{
    public class CollisionService
    {
        public void HandleCollisions(List<SkierSprite> skiers, List<Obstacle> obstacles)
        {
            foreach (var skier in skiers)
            {
                if (skier.IsDead) continue;

                foreach (var obstacle in obstacles)
                {
                    if (obstacle.IsExpired) continue;

                    if (skier.Bounds.Intersects(obstacle.Bounds))
                    {
                        obstacle.OnCollide(skier);
                    }
                }
            }
        }
    }
}
