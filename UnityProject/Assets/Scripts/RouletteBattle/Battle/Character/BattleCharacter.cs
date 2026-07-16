using RouletteBattle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteBattle.Battle;
using RouletteBattle.Battle.Character;
using NPOI.HSSF.Record.Drawing;

namespace RouletteBattle.Battle.Character
{
    public class BattleCharacter:CharacterBase
    {
        public List<RoulettePieceParameter> m_pieceList;
        private List<CharacterStyleData> m_styleList = new List<CharacterStyleData>();

        public CharacterStatus m_status = new CharacterStatus();

        private CharacterClassData classData;
        private Weapon weaponData;

        public int MaxHP
        {
            get
            {
                return m_originStatus != null ? m_originStatus.HP : 0;
            }
        }
        public int CurrentHP => m_status.HP;

        public Weapon WeaponData => weaponData;

        public CharacterStatus GetStatus(bool isOrigin = false)
        {
            if (isOrigin)
            {
                //元のステータス返す
                return m_status;
            }
            else
            {
                CharacterStatus status = new CharacterStatus(m_status);
                //スタイルでの強化分も含める
                foreach (var style in m_styleList) 
                {
                    switch (style.type)
                    {
                        case StyleType.STATUS_BUFF_DEBUFF:
                            {
                                foreach(var option in style.options)
                                {
                                    status.AddParameter(option.target,option.value);
                                }
                            }
                            break;
                    }
                }

                return status;
            }
        }


        public BattleCharacter()
        {
        }

        public void SetInitStatus(DataImporter.CharacterInitStatus status)
        {
            m_originStatus = new CharacterStatus();
            m_originStatus.Init(status);

            m_status.Init(status);
        }

        public void AddStyle(CharacterStyleData style)
        {
            m_styleList.Add(style);
        }

        public void AddStyle(int id)
        {
            var style = TestDataManager.GetStyleData(id);
            if(style != null)
            {
                AddStyle(style);
            }
        }
        public void AddStyles(int[] idArray)
        {
            foreach(int id in idArray)
            {
                AddStyle(id);
            }
        }

        public void RemoveStyle(int styleId)
        {
            int index = m_styleList.FindIndex(_ => _.styleId == styleId);
            if (index >= 0)
            {
                m_styleList.RemoveAt(index);
            }
        }

        public void Init(int classId,int weaponId)
        {
            classData = TestDataManager.GetClassData(classId);
            weaponData = TestDataManager.GetWeaponData(weaponId);
        }

        public virtual void Damage(int damage)
        {
            m_status.SetHP(m_status.HP - damage);
        }
    }
}
