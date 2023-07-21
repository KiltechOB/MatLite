using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MatLite.factory
{
    public class PairsDictionary : Pairs
    {
        public Dictionary<string, string> dictionary=new Dictionary<string, string>();
        
        public void AddDictionary(Pairs pairs)
        {

            if (dictionary.ContainsKey(pairs.Name))
            {
                dictionary[pairs.Name] = pairs.Values;
            }
            else
            {
                dictionary.Add(pairs.Name, pairs.Values);
            }
        }

        //public string WriteAllPairs()
        //{
        //    foreach (KeyValuePair<string, string> pair in dictionary)
        //    {
        //        allPairs+=$"{pair.Key} = {pair.Value}; \n";
        //    }
        //    return allPairs;
        //}
    }
}
