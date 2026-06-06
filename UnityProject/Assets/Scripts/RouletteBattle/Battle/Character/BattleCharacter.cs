using RouletteBattle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RouletteBattle.Battle;
using RouletteBattle.Battle.Character;

namespace RouletteBattle.Battle.Character
{
    public class BattleCharacter:CharacterBase
    {
        public List<RoulettePieceParameter> m_pieceList;

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

        public BattleCharacter()
        {
        }

        public void SetInitStatus(DataImporter.CharacterInitStatus status)
        {
            m_originStatus = new CharacterStatus();
            m_originStatus.Init(status);

            m_status.Init(status);
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
