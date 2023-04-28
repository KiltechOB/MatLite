using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatLite.operation
{
    internal class MultipleOperation : MathOperation
    {
        public double compute(double x, double y)
        {
            return x * y;
        }
    }
}
