using RouletteBattle.Battle.Character;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace RouletteBattle
{
    public class ScrollMenuUIContent : MonoBehaviour
    {
        [SerializeField] Button m_button;
        [SerializeField] Text m_text;

        private RectTransform m_rect;
        public RectTransform Rect => m_rect;

        private CharacterStyleData m_styleData;
        public CharacterStyleData StyleData => m_styleData;

        private void Awake()
        {
            m_rect = GetComponent<RectTransform>();
        }

        public void Init(CharacterStyleData styleData,Action<ScrollMenuUIContent> onClickedAction)
        {
            m_text.text = styleData.name;
            m_button.onClick.AddListener(() => 
            {
                onClickedAction?.Invoke(this);
            });
        }
    }
}