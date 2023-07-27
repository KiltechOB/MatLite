using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatLite.operation
{
    internal class SquareRoot : MathOperation
    {
        public double compute(double x, double y)
        {
            if (x.Equals(x < 0))
            {
                throw new InvalidOperationException();
            }
            return Math.Sqrt(x);
        }
    }
}
