using RouletteBattle;
using RouletteBattle;
using UnityEngine;
using UnityEngine.UI;

namespace RouletteBattle
{
    public class RoulettePiece : MonoBehaviour
    {
        [SerializeField]
        private Image m_imageBg;

        [SerializeField]
        private Text m_text;

        private bool m_selected;

        private BattleCharacter.PieceParameter m_param;
        private BattleCharacter.PieceParameter.PieceType m_pieceType;

        public BattleCharacter.PieceParameter GetParam()
        {
            return m_param;
        }

        public void Init(BattleCharacter.PieceParameter param)
        {
            m_param = param;

            //テキスト設定
            string setText = "";
            switch (param.m_pieceType)
            {
                case BattleCharacter.PieceParameter.PieceType.Damage:
                    setText = $"{param.m_value}のダメージ";
                    break;
                case BattleCharacter.PieceParameter.PieceType.Miss:
                    setText = "ミス";
                    break;
            }
            m_text.text = setText;

            SetSelect(false);
        }

        public void Init(AbillityBase abillity)
        {
            //テキスト設定
            string setText = abillity.GetAbillityName();

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

