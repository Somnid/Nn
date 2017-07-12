using System;

namespace Nn
{
    public static class CommonActivations
    {
        public static double Rectifier(double input)
        {
            return Math.Max(0, input);
        }

        public static double Sigmoid(double input)
        {
            return 1 / (1 + Math.Pow(Math.E, input));
        }

        public static Func<double, double> BinaryThreshold(double threshold)
        {
            return x => x >= threshold ? 1 : 0;
        }
    }
}
