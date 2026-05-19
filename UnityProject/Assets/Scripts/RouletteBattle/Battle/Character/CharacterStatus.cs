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


        public void Init(DataImporter.CharacterInitStatus status)
        {
            m_hp = status.hp;
            m_mp = status.mp;
            m_strength = status.strength;
            m_intelligence = status.intelligence;
            m_speed = status.speed;
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
    }
}

