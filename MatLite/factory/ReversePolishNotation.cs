using MatLite.operation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatLite.factory
{
    public class ReversePolishNotation:BoolOperator
    {
        private Queue<string> numQueue = new Queue<string>();
        private Stack<string> operatorStack = new Stack<string>();
        private double num;

        private static int GetOperatorPrecedence(string op)
        {
            switch (op)
            {
                case "+":
                case "-":
                    return 1;
                case "*":
                case "/":
                    return 2;
                case "^":
                    return 3;
                default:
                    return 0;
            }
        }
        public Queue<string> GetReversePolishNotation(string formula)
        {
            formula = formula.Replace(" ", ""); formula = formula.Replace(".", ",");

            string pattern = @"(\d+(\,\d+)?|\+|\-|\*|\/|\(|\)|\^)";
            MatchCollection matches = Regex.Matches(formula, pattern);
            string[] formulaArray = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                formulaArray[i] = matches[i].ToString();
            }

            foreach (string charFormula in formulaArray)
            {
                if (double.TryParse(charFormula, out num))
                {
                    numQueue.Enqueue(charFormula);
                }
                else if (charFormula == "(")
                {
                    operatorStack.Push(charFormula);
                }
                else if (charFormula == ")")
                {
                    while (operatorStack.Count > 0 && operatorStack.Peek() != "(")
                    {
                        numQueue.Enqueue(operatorStack.Pop());
                    }
                    if (operatorStack.Count > 0 && operatorStack.Peek() == "(")
                    {
                        operatorStack.Pop();
                    }
                }
                else if (IsOperator(charFormula))
                {
                    while (operatorStack.Count > 0 && (GetOperatorPrecedence(operatorStack.Peek()) >= GetOperatorPrecedence(charFormula)))
                    {
                        numQueue.Enqueue(operatorStack.Pop());
                    }

                    operatorStack.Push(charFormula);
                }
            }

            while (operatorStack.Count > 0)
            {
                numQueue.Enqueue(operatorStack.Pop());
            }

            return numQueue;
        }
    }
}
