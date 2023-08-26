
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MatLite.factory
{
    public class PairsDictionary : Pairs
    {
        public string FullName { get;set; }
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
        public void RemoveDictionary(string Key)
        {
            if (dictionary.ContainsKey(Key))
            {
                dictionary.Remove(Key);
            }
        }
        public bool ContainsPairs(string Key)
        {
            if (dictionary.ContainsKey(Key))
            {
                return true;
            }
            else { return false; }
        }
        public string WritePairs()
        {
            FullName = "";
            foreach (KeyValuePair<string, string> pair in dictionary)
            {
                if(pair.Key == "e"||pair.Key== "π") { continue; }
               
                FullName += $"{pair.Key}={pair.Value}\n";
            }
            return FullName;
        }
    }
}
