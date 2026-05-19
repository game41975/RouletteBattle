using System.Collections;
using UnityEngine;

namespace RouletteBattle.Battle
{
    public class RoulettePieceParameter
    {
        public enum PieceType
        {
            None = 0,

            /// <summary></summary>
            Damage,
            Miss,
            Heal,

            /// <summary>通常攻撃</summary>
            Attack,
            //MagicAttack,

            /// <summary>魔法</summary>
            Magic,
            /// <summary>特技</summary>
            Skill,

            MAX,
        }


        public PieceType m_pieceType;

        /// <summary>
        /// 効果量
        /// </summary>
        public int m_value;

    }
}