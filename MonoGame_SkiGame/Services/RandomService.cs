using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Services
{
    public class RandomService : IRandomService
    {
        private readonly Random _rng = new();

        public int Next(int minInclusive, int maxExclusive) => _rng.Next(minInclusive, maxExclusive);

        public float NextFloat(float minInclusive, float maxInclusive)
        {
            var t = (float)_rng.NextDouble();
            return minInclusive + (maxInclusive - minInclusive) * t;
        }
    }
}
