using NUnit.Framework;
using RouletteBattle.Battle.Character;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using RouletteBattle.Battle;

namespace RouletteBattle
{
    public class Roulette : MonoBehaviour
    {
        [SerializeField]
        private RoulettePiece m_roulettePiecePrefab;

        private List<RoulettePiece> m_pieceList;

        private int m_selectedPieceCount = 0;

        private Coroutine m_coroutineRoulette = null;

        public RoulettePieceParameter GetSelectPieceParameter()
        {
            return m_pieceList[m_selectedPieceCount].GetParam();
        }

        private void ClearPieceList()
        {
            if(m_pieceList != null)
            {
                m_pieceList.Clear();
            }
            else
            {
                m_pieceList = new List<RoulettePiece>();
            }
        }

        public void Initialize(BattleCharacter character)
        {
            ClearPieceList();
            if (m_roulettePiecePrefab != null)
            {
                for (int i = 0; i < character.m_pieceList.Count; i++)
                {
                    var instObj = Instantiate(m_roulettePiecePrefab, transform);
                    if (instObj != null)
                    {
                        instObj.gameObject.SetActive(true);
                        instObj.Init(character.m_pieceList[i]);
                        m_pieceList.Add(instObj);
                    }
                }
            }
        }

        public void StartRoulette()
        {
            if(m_coroutineRoulette == null)
            {
                m_coroutineRoulette = StartCoroutine(RouletteAsync());
            }
        }

        private IEnumerator RouletteAsync()
        {
            int count = 0;

            //m_selectedPieceCount = 0;
            m_pieceList[m_selectedPieceCount].SetSelect(true);

            while (true)
            {
                count++;

                //6フレ経過後に次にマスに移動
                if(count >= 6)
                {
                    m_pieceList[m_selectedPieceCount].SetSelect(false);
                    
                    m_selectedPieceCount++;
                    if(m_selectedPieceCount >= m_pieceList.Count)
                    {
                        m_selectedPieceCount = 0;
                    }

                    m_pieceList[m_selectedPieceCount].SetSelect(true);

                    count = 0;
                }

                yield return null;
            }
        }

        public void StopRoulette()
        {
            if(m_coroutineRoulette != null)
            {
                StopCoroutine(m_coroutineRoulette);
                m_coroutineRoulette = null;
            }
        }

        public bool IsPlayingRoulette()
        {
            return m_coroutineRoulette != null;
        }
    }
}

