using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatLite.factory
{
    public class PatternRegex
    {
        public string[] PatternString(string formula)
        {
            formula = formula.Replace(" ", ""); formula = formula.Replace(".", ",");

            string pattern = @"\b[a-zA-Z\,\d+]+\b|\b\d+(\,\d+)?\b|\+|\-|\*|\/|\(|\)|\^";
            MatchCollection matches = Regex.Matches(formula, pattern);
            string[] formulaArray = new string[matches.Count];

            for (int i = 0; i < matches.Count; i++)
            {
                formulaArray[i] = matches[i].ToString();
            }
            return formulaArray;
        }
    }
}
