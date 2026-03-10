using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBattle
{
    public class Magic : AbillityBase
    {
        public Magic()
        {
            //m_abillityName = "まほう";
        }

        public override int GetValue()
        {
            return 20;
        }

        public override int GetCost()
        {
            return 30;
        }
    }
}
