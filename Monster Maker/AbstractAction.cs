using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Maker
{
    [Serializable]
    class AbstractAction
    {
        int attackbonus;
        string damagebonus;
        string damagedice;
        string desc;
        string name;
        public AbstractAction(string name, string description)
        {
            this.name = name;
            desc = description;
            damagebonus = "null";
            try
            {
                string[] descsplit = desc.Split('+');
                attackbonus = Convert.ToInt32(descsplit[1][0]);
            }
            catch (Exception)
            {
                attackbonus = 0;
            }
            try
            {
                string[] descsplit = desc.Split('(');
                string[] descsplit2 = descsplit[1].Split(')');
                Convert.ToInt32(descsplit[2][0]);
                damagedice = descsplit[2];
            }
            catch (Exception)
            {
                damagedice = null;
            }
        }
        override
        public string ToString()
        {
            return name.ToUpper() + " : " + desc;
        }
    }
}
