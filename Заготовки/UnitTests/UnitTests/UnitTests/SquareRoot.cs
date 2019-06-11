using System;

namespace SquareRootFinder
{
    public class SquareRoot
    {
        public double FindSqrt(double a)
        {
            if (a < 0)
                throw new ArgumentOutOfRangeException(nameof(a));

            return Math.Sqrt(a);
        }
    }
}
