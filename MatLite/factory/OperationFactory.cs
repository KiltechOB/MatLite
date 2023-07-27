using MatLite.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatLite.factory
{
    public class OperationFactory:BoolOperator
    {
        public double getOperation(string operation, double x, double y)
        {
            switch (operation)
            {
                case "+":
                    AddOperation pairsAdd = new AddOperation();
                    return pairsAdd.compute(y, x);
                case "-":
                    MinusOperation pairsMinus = new MinusOperation();
                    return pairsMinus.compute(y, x);
                case "*":
                    MultipleOperation pairsMultiple = new MultipleOperation();
                    return pairsMultiple.compute(y, x);
                case "/":
                    DivisionOperation pairsDiv = new DivisionOperation();
                    return pairsDiv.compute(y, x);
                case "^":
                    PowerOperation pairsPower = new PowerOperation();
                    return pairsPower.compute(y, x);
            }
            return double.NaN;
        }
        public double getOperationSquare(double x, double y)
        {
            SquareRoot notPairsRoot = new SquareRoot();
            return notPairsRoot.compute(x, y);
        }
    }
}
