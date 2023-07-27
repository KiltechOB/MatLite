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
        private double result; private string Result;
        private Stack<double> stackNums=new Stack<double>();
        public string getResult(Queue<string> reversPN)
        {
            foreach(string rever in reversPN)
            {
                if (!IsOperator(rever))
                {
                    stackNums.Push(double.Parse(rever));
                }
                else
                {
                    if (rever == "√")
                    {
                        result = getOperationSquare(stackNums.Pop(), 0);
                        stackNums.Push(result);
                    }
                    else if (stackNums.Count >= 2)
                    {
                        result = getOperation(rever, stackNums.Pop(), stackNums.Pop());
                        stackNums.Push(result);
                    }                    
                    else
                    {
                        break;
                    }
                }
                if(stackNums.Count == 1)
                {
                    Result = string.Format("{0:0.###}", result);
                }
            }
            return Result;
        }
    }
}
