using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace RouletteBattle.Battle.Character
{
    public class CharacterStatus
    {
        protected int m_hp;
        protected int m_mp;
        protected int m_strength;
        protected int m_intelligence;
        protected int m_speed;

        public int HP => m_hp;
        public int MP => m_mp;
        public int Strength => m_strength;
        public int Intelligence => m_intelligence;
        public int Speed => m_speed;

        public CharacterStatus()
        {
            m_hp = 0;
            m_mp = 0;
            m_strength = 0;
            m_intelligence = 0;
            m_speed = 0;
        }

        public CharacterStatus(CharacterStatus status)
        {
            m_hp = status.m_hp;
            m_mp = status.m_mp;
            m_strength = status.m_strength;
            m_intelligence = status.m_intelligence;
            m_speed = status.m_speed;
        }

        public static CharacterStatus operator +(CharacterStatus status1,CharacterStatus status2)
        {
            return new CharacterStatus()
            {
                m_hp = status1.m_hp + status2.m_hp,
                m_mp = status1.m_mp + status2.m_mp,
                m_strength = status1.m_strength + status2.m_strength,
                m_intelligence = status1.m_intelligence + status2.m_intelligence,
                m_speed = status1.m_speed + status2.m_speed,
            };
        }


        public void Init(DataImporter.CharacterInitStatus status)
        {
            m_hp = status.hp;
            m_mp = status.mp;
            m_strength = status.strength;
            m_intelligence = status.intelligence;
            m_speed = status.speed;
        }

        public void SetParameter(CharacterParameterType type, int value)
        {
            switch (type)
            {
                case CharacterParameterType.HP:
                    m_hp = value;
                    break;
                case CharacterParameterType.MP:
                    m_mp = value;
                    break;
                case CharacterParameterType.INT:
                    m_intelligence = value;
                    break;
                case CharacterParameterType.STR:
                    m_strength = value;
                    break;
                case CharacterParameterType.SPD:
                    m_speed = value;
                    break;
            }
        }

        public void AddParameter(CharacterParameterType type, int value)
        {
            switch (type) 
            {
                case CharacterParameterType.HP:
                    m_hp += value;
                    break;
                case CharacterParameterType.MP:
                    m_mp += value;
                    break;
                case CharacterParameterType.INT:
                    m_intelligence += value;
                    break;
                case CharacterParameterType.STR:
                    m_strength += value;
                    break;
                case CharacterParameterType.SPD:
                    m_speed += value;
                    break;
            }
        }

        public void SetHP(int hp)
        {
            m_hp = hp;
        }

        public void SetMP(int mp)
        {
            m_mp = mp;
        }

        public void SetStrength(int strength) 
        {
            m_strength = strength;
        }

        public void SetIntelligence(int intelligence)
        {
            m_intelligence = intelligence;
        }

        public void SetSpeed(int speed)
        {
            m_speed = speed;
        }

        public int GetStatus(CharacterParameterType type)
        {
            switch (type)
            {
                case CharacterParameterType.HP:
                    return m_hp;
                case CharacterParameterType.MP:
                    return m_mp;
                case CharacterParameterType.INT:
                    return m_intelligence;
                case CharacterParameterType.STR:
                    return m_strength;
                case CharacterParameterType.SPD:
                    return m_speed;
            }
            return 0;
        }
    }
}

