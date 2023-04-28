using MatLite.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatLite.factory
{
    public class Calculation:OperationFactory
    {
        private double result;
        private Stack<double> stackNums=new Stack<double>();
        public double getResult(Queue<string> reversPN)
        {
            foreach(string rever in reversPN)
            {
                if (!IsOperator(rever))
                {
                    stackNums.Push(double.Parse(rever));
                }
                else
                {
                    if (stackNums.Count >= 2)
                    {
                        result = getOperation(rever, stackNums.Pop(), stackNums.Pop());
                        stackNums.Push(result);
                    }
                    else
                    {
                        break;
                    }
                }
            }

            return result;
        }
    }
}
