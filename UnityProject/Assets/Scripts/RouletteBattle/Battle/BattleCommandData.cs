using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RouletteBattle.Battle
{
    public enum CommandType
    {
        None = 0,
        Attack,
        NextRoulette,
    }

    /// <summary>
    /// 攻撃種別
    /// </summary>
    public enum AttackAttributeType
    {
        None = 0,
        /// <summary></summary>
        Physical,
        /// <summary></summary>
        Magic,
    }

    /// <summary>
    /// 威力の算出方法
    /// </summary>
    public enum PowerCalclateMethodType
    {
        /// <summary>キャラクターの能力値のみ参照</summary>
        CharacterPower,
        /// <summary>キャラの能力値+スキルのパワー値</summary>
        AddCharacterPower,
    }

    /// <summary>
    /// 攻撃範囲
    /// </summary>
    public enum AttackRangeType
    {
        None = 0,
        /// <summary>単体</summary>
        Single,
        /// <summary>全体</summary>
        All,
    }

    public class BattleCommandData
    {
        public int commandId;
        public string commandName;
        public CommandType commandType;
        public AttackAttributeType attackType;
        public AttackRangeType rangeType;
        public PowerCalclateMethodType powerCalclateType;
        /// <summary>威力</summary>
        public int power;
        /// <summary>威力の倍率</summary>
        public float powerMag;
        public int rouletteId;
    }
}
