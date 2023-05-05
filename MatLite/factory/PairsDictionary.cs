using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MatLite.factory
{
    public class PairsDictionary
    {
        private string key;
        public string Key { get { return key; } set { key = value; } }

        private string values;
        public string Values { get { return values; } set { values = value; } }

        public Dictionary<string, string> dictionary=new Dictionary<string, string>();
        
        public void AddDictionary(Pairs pairs)
        {
            if (!dictionary.ContainsKey(pairs.Name))
            {
                dictionary.Add(pairs.Name, pairs.Values);
            }
        }
    }
}
