﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatLite.factory
{
    public class BoolOperator
    {
        public static bool IsOperator(string operation)
        {
            return operation == "+" || operation == "-" || operation == "*" || operation == "/" || operation == "^"|| operation== "√";
        }
    }
}
