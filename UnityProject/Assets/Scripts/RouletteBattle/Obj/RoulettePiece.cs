using UnityEngine;
using UnityEngine.UI;
using RouletteBattle.Battle.Character;
using RouletteBattle.Battle;

namespace RouletteBattle
{
    public class RoulettePiece : MonoBehaviour
    {
        [SerializeField]
        private Image m_imageBg;

        [SerializeField]
        private Text m_text;

        private bool m_selected;

        private RoulettePieceParameter m_param;
        private RoulettePieceParameter.PieceType m_pieceType;

        private BattleCommandData m_commandData;

        public RoulettePieceParameter GetParam()
        {
            return m_param;
        }

        public BattleCommandData CommandData => m_commandData;

        public void Init(RoulettePieceParameter param)
        {
            m_param = param;

            //テキスト設定
            string setText = "";
            switch (param.m_pieceType)
            {
                case RoulettePieceParameter.PieceType.Damage:
                    setText = $"{param.m_value}のダメージ";
                    break;
                case RoulettePieceParameter.PieceType.Miss:
                    setText = "ミス";
                    break;
            }
            m_text.text = setText;

            SetSelect(false);
        }

        public void Init(BattleCommandData data)
        {
            m_commandData = data;

            string setText = data.commandName;
            m_text.text = setText;

            SetSelect(false);
        }

        public void SetSelect(bool isSelect)
        {
            m_selected = isSelect;

            m_imageBg.color = isSelect ? Color.red : Color.white;
        }
    }
}

