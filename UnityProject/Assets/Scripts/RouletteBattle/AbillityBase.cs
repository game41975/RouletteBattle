using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBattle
{
    public class AbillityBase
    {
        /*protected*/public string m_abillityName;

        /// <summary>
        /// アビリティの効果値を返す
        /// </summary>
        /// <returns></returns>
        public virtual int GetValue() => 0;

        /// <summary>
        /// アビリティ仕様に必要な技ポイントの値を返す
        /// </summary>
        /// <returns></returns>
        public virtual int GetCost() => 0;

        public string GetAbillityName() => m_abillityName;
    }
}
