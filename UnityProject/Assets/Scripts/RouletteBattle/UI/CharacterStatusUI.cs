using Mono.Cecil.Cil;
using NUnit.Framework;
using RouletteBattle.Battle.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RouletteBattle
{
    public class CharacterStatusUI : MonoBehaviour
    {
        [SerializeField]
        private Text m_textCharacterName;
        [SerializeField]
        private Slider m_sliderHp;
        [SerializeField]
        private Text m_textHp;
        [SerializeField]
        private Text m_prefabStatusText;
        [SerializeField]
        private RectTransform m_rootStatusText;

        private int m_currentHp;
        private int m_maxHp;

        private List<Text> m_statusTextList = new List<Text>();

        public void Init(BattleCharacter chara)
        {
            m_maxHp = chara.MaxHP;
            m_currentHp = m_maxHp;

            InitHpSlider();

            SetName(chara.GetName());
            UpdateStatusText(chara.GetStatus());
        }

        public void Init(int maxHp,string charaName)
        {
            m_maxHp = maxHp;
            m_currentHp = maxHp;

            InitHpSlider();

            SetName(charaName);
        }

        private void InitHpSlider()
        {
            m_sliderHp.maxValue = m_maxHp;
            m_sliderHp.minValue = 0;
            m_sliderHp.value = 1;

            UpdateHpText();
        }

        public void SetName(string name)
        {
            m_textCharacterName.text = name;
        }

        public void SetCurrentHP(int value,bool isOverMax = false)
        {
            m_currentHp += value;
            if (!isOverMax)
            {
                m_currentHp = Mathf.Min(m_maxHp, m_currentHp);
            }

            m_sliderHp.value = m_currentHp;

            UpdateHpText();
        }

        public void UpdateHpText()
        {
            m_textHp.text = $"{m_currentHp}/{m_maxHp}";
        }

        private void UpdateStatusText(CharacterStatus status)
        {
            foreach(var text in m_statusTextList)
            {
                if(text != null)
                {
                    Destroy(text.gameObject);
                }
            }
            m_statusTextList.Clear();
    
            foreach(CharacterParameterType type in Enum.GetValues(typeof(CharacterParameterType)))
            {
                var statusText = Instantiate(m_prefabStatusText, m_rootStatusText);
                statusText.gameObject.SetActive(true);
                statusText.text = $"{type.ToString()}:{status.GetStatus(type)}";
                m_statusTextList.Add(statusText);
            }
        }

    }
}