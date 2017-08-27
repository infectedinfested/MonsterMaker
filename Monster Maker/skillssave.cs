using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Maker
{
    class skillssave
    {
        public int order { get; }
        public string name { get; }
        public int amount { get;}
        public skillssave(string name, int amount)
        {
            this.name = name;
            this.amount = amount;
            order = GetOrder(name);
        }

        private int GetOrder(string name)
        {
            switch (name)
            {
                case "Str": return 1;
                case "Dex": return 2;
                case "Con": return 3;
                case "Int": return 4;
                case "Wis": return 5;
                case "Cha": return 6;
            }
            return 0;
        }

        override
        public string ToString()
        {
            return name + "  "+ amount;
        }
        override
        public bool Equals(object x)
        {
            skillssave temp = (skillssave)x;
            if (name == temp.name)
            {
                return true;
            }
            return false;
        }

    }
}
