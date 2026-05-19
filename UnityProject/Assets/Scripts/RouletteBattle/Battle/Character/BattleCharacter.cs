using RouletteBattle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteBattle.Battle;

namespace RouletteBattle.Battle.Character
{
    public class BattleCharacter:CharacterBase
    {
        public List<RoulettePieceParameter> m_pieceList;

        public CharacterStatus m_status = new CharacterStatus();

        public List<Magic> m_magicList;
        public List<Skill> m_skillList;

        public int MaxHP
        {
            get
            {
                return m_originStatus != null ? m_originStatus.HP : 0;
            }
        }
        public int CurrentHP => m_status.HP;
        
        public BattleCharacter()
        {
        }

        public void Init(DataImporter.CharacterInitStatus status)
        {
            m_originStatus = new CharacterStatus();
            m_originStatus.Init(status);

            m_status.Init(status);
        }

        public virtual void Damage(int damage)
        {
            m_status.SetHP(m_status.HP - damage);
        }

        /// <summary>
        /// テスト用の初期値設定
        /// </summary>
        public void SetTestSkills()
        {
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
