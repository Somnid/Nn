using System;

namespace Nn
{
    public static class CommonDistributions
    {
        private static Random _random;
        static Random Random { get
            {
                if(_random == null)
                {
                    _random = new Random();
                }
                return _random;
            }
        }
        public static double SmallUniformRandom()
        {
            return Random.NextDouble() / 1000;
        }
    }
}
