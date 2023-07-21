using MathNet.Symbolics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatLite.factory
{
    public class Pairs
    {
        public string Name { get; set; }
        public string Values { get; set; }

        public Pairs()
        {

        }
        public Pairs(string Name, string Values)
        {
            this.Name = Name;
            this.Values = Values;
        }

        public string Converting(string name)
        {
            if (name.Equals(Name))
            {
                return Values;
            }
            else
            {
                return name;
            }
        }
    }
}
