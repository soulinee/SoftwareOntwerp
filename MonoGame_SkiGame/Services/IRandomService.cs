using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonoGame_SkiGame.Services
{
    public interface IRandomService
    {
        int Next(int minInclusive, int maxExclusive);
        float NextFloat(float minInclusive, float maxInclusive);
    }
}
