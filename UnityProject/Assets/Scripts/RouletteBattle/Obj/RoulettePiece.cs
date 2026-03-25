using UnityEngine;
using UnityEngine.UI;
using RouletteBattle.Battle.Character;

namespace RouletteBattle
{
    public class RoulettePiece : MonoBehaviour
    {
        [SerializeField]
        private Image m_imageBg;

        [SerializeField]
        private Text m_text;

        private bool m_selected;

        private PieceParameter m_param;
        private PieceParameter.PieceType m_pieceType;

        public PieceParameter GetParam()
        {
            return m_param;
        }

        public void Init(PieceParameter param)
        {
            m_param = param;

            //テキスト設定
            string setText = "";
            switch (param.m_pieceType)
            {
                case PieceParameter.PieceType.Damage:
                    setText = $"{param.m_value}のダメージ";
                    break;
                case PieceParameter.PieceType.Miss:
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

