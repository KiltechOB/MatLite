using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatLite.operation
{
    internal class PowerOperation:MathOperation
    {
        public double compute(double x, double y)
        {
            if (y.Equals(0))
            {
                return 1;
            }
            return Math.Pow(x,y);
        }
    }
}
