using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBattle.Battle.Character
{
    public enum CharacterParameterType
    {
        HP,
        MP,
        STR,
        INT,
        SPD,
    }


    public enum StyleType
    {
        /// <summary>ステータス増減</summary>
        STATUS_BUFF_DEBUFF,
    }


    public class CharacterStyleData
    {
        public int styleId;
        public int[] targetClassIds;
        public string name;
        public string description;
        public StyleType type;
        public CharacterStyleOptionData[] options;
    }

    public class CharacterStyleOptionData
    {
        public CharacterParameterType target;
        public int value;
    }
}
