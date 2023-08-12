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
        public Queue<string> GetReversePolishNotations(string formula,PairsDictionary pairss=null)
        {
            PatternRegex pattern = new PatternRegex();
            string[] formulaA = pattern.PatternString(formula);
            string[] formulaArray;
            try
            {
                if (pairss.ContainsPairs(formulaA[0]) && formulaA[1] == "=")
                {
                    formulaArray = (from x in formulaA
                                    where x != formulaA[0] && x != formulaA[1]
                                    select x).ToArray();
                }
                else
                {
                    formulaArray = formulaA;
                }
            }catch (Exception ex) { formulaArray = formulaA; }


            foreach (string charFormula in formulaArray)
            {
                if (double.TryParse(charFormula, out num) || (pairss != null && pairss.dictionary.ContainsKey(charFormula)))
                {
                    if (pairss != null && pairss.dictionary.ContainsKey(charFormula))
                    {
                        numQueue.Enqueue(pairss.dictionary[charFormula].Replace(".",","));
                    }
                    else
                    {
                        numQueue.Enqueue(charFormula);
                    }
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
                    while (operatorStack.Count > 0 && (GetOperatorPrecedences.GetOperatorPrecedence(operatorStack.Peek()) >= GetOperatorPrecedences.GetOperatorPrecedence(charFormula)))
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
