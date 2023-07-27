using MatLite.factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace MatLite.constants
{
    public class Constants: PairsDictionary
    {
        string[] LetterName = new string[] { "π", "e"};
        string[] LetterValue = new string[] { "3,14159", "2.71828"};
        List <Pairs> pairs = new List<Pairs>();
        private List <Pairs> CreateConst(string[] LN, string[] LV)
        {
            for (int i = 0; i < LN.Length; i++)
            {
                Pairs p = new Pairs(LN[i], LV[i]);
                pairs.Add(p);
            }
            return pairs;
        }
        public void AddConstants(PairsDictionary dict)
        {
            CreateConst(LetterName, LetterValue);
            foreach (Pairs p in pairs)
            {
                dict.AddDictionary(p);
            }         
        }

    }
}
