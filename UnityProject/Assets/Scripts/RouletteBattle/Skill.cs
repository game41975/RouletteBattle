using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBattle
{
    /// <summary>
    /// 特技
    /// </summary>
    public class Skill:AbillityBase
    {
        public Skill()
        {
            //m_abillityName = "とくぎ";
        }

        public override int GetValue()
        {
            return 20;
        }

        public override int GetCost()
        {
            return 20;
        }
    }
}
