using RouletteBattle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBattle
{
    public class BattleCharacter
    {
        public class PieceParameter
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

        public List<PieceParameter> m_pieceList;

        /// <summary>体力</summary>
        public int m_healthPoint;
        
        /// <summary>力</summary>
        public int m_power;
        /// <summary>知力</summary>
        public int m_intelligence;

        /// <summary>素早さ</summary>
        public int m_speed;

        /// <summary>技ポイント</summary>
        public int m_magicPoint;
        /// <summary>最大体力</summary>
        public int m_maxHealthPoint;
        /// <summary>最大技ポイント</summary>
        public int m_maxMagicPoint;

        public List<Magic> m_magicList;
        public List<Skill> m_skillList;

        /// <summary>
        /// テスト用の初期値設定
        /// </summary>
        public BattleCharacter()
        {
            m_healthPoint = 100;
            m_power = 20;
            m_intelligence = 20;
            m_speed = 20;
            m_magicPoint = 50;

            m_magicList = new List<Magic>()
            {
                new Magic()
                {
                    m_abillityName = "まほう1"
                },
                new Magic()
                {
                    m_abillityName = "まほう2"
                },
                new Magic()
                {
                    m_abillityName = "まほう3"
                },
                new Magic()
                {
                    m_abillityName = "まほう4"
                },
                new Magic()
                {
                    m_abillityName = "まほう5"
                },
                new Magic()
                {
                    m_abillityName = "まほう6"
                },
            };

            m_skillList = new List<Skill>()
            {
                new Skill()
                {
                    m_abillityName = "とくぎ1"
                },
                new Skill()
                {
                    m_abillityName = "とくぎ2"
                },
                new Skill()
                {
                    m_abillityName = "とくぎ3"
                },
                new Skill()
                {
                    m_abillityName = "とくぎ4"
                },
                new Skill()
                {
                    m_abillityName = "とくぎ5"
                },
                new Skill()
                {
                    m_abillityName = "とくぎ6"
                }
            };
        }
    }
}
