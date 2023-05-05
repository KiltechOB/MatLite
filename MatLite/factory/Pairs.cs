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
        private string name;
        public string Name { get { return name; } set { name = value;} }

        private string values;
        public string Values { get { return values; } set { values = value; } }

        public string FullName()
        {
            return $"{Name} = {Values}";
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
