using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatLite.operation
{
    internal class DivisionOperation : MathOperation
    {
        public double compute(double x, double y)
        {
            if (y.Equals(0))
            {
                throw new DivideByZeroException();
            }
            return x / y;
        }
    }
}
