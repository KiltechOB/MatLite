﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatLite.operation
{
    internal class MinusOperation : MathOperation
    {
        public double compute(double c, double y)
        {
            return c - y;
        }
    }
}
