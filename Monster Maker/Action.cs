using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monster_Maker
{
    [Serializable]
    class Action : AbstractAction
    {
        public Action(string name, string description) : base(name, description)
        {
        }
    }
}
