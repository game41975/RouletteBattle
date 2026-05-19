using System.Collections;
using UnityEngine;

namespace RouletteBattle.Battle.Character
{
    public class CharacterBase
    {
        /// <summary>名前</summary>
        protected string m_name;
        /// <summary>能力値</summary>
        protected CharacterStatus m_originStatus;

        public string GetName() => m_name;
        public void SetName(string name)
        {
            m_name = name;
        }
    }
}