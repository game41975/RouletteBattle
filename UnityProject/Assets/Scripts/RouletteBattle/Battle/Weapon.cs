using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBattle.Battle
{
    public enum WeaponType
    {
        /// <summary>剣</summary>
        Sword,
        /// <summary>杖</summary>
        Cane,
    }

    public class Weapon : EquipmentItemBase
    {
        public WeaponType weaponType;
        public int rouletteId;
    }
}
