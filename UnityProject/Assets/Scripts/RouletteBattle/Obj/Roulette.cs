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

        private int m_selectedPieceIndex = -1;

        private Coroutine m_coroutineRoulette = null;

        private BattleCharacter m_character;
        private int m_currentRouletteId = 0;

        public RoulettePieceParameter GetSelectPieceParameter()
        {
            return m_pieceList[m_selectedPieceIndex].GetParam();
        }

        public BattleCommandData GetSelectCommand()
        {
            return m_pieceList[m_selectedPieceIndex].CommandData;
        }

        private void ClearPieceList()
        {
            if(m_pieceList != null)
            {
                for (int i = 0; i < m_pieceList.Count; i++)
                {
                    var piece = m_pieceList[i];
                    if (piece != null)
                    {
                        Destroy(piece.gameObject);
                    }
                }
                m_pieceList.Clear();
            }
            else
            {
                m_pieceList = new List<RoulettePiece>();
            }
        }

        public void Initialize(BattleCharacter character)
        {            
            m_character = character;
            SetRoulette();
        }

        private void SetRoulette(SkillRouletteData rouletteData, bool clearPiece = true, bool keepSelect = false)
        {
            if (m_roulettePiecePrefab == null)
            {
                Debug.Log("ルーレットピースのモデルデータがnull");
                return;
            }

            if (rouletteData != null)
            {
                m_currentRouletteId = rouletteData.rouletteId;

                if (clearPiece)
                {
                    ClearPieceList();
                }

                for (int i = 0; i < rouletteData.commandIds.Length; i++)
                {
                    var commandData = TestDataManager.GetCommandData(rouletteData.commandIds[i]);
                    if (commandData != null)
                    {
                        var instObj = Instantiate(m_roulettePiecePrefab, transform);
                        if (instObj != null)
                        {
                            instObj.gameObject.SetActive(true);
                            instObj.Init(commandData);
                            m_pieceList.Add(instObj);
                        }
                    }
                }

                if (keepSelect) 
                {
                    if(m_pieceList.Count >= m_selectedPieceIndex)
                    {
                        m_pieceList[m_selectedPieceIndex].SetSelect(true);
                    }
                    else
                    {
                        m_selectedPieceIndex = 0;
                    }
                }
                else
                {
                    m_selectedPieceIndex = -1;
                }
            }
        }

        /// <summary>
        /// ルーレット設定(指定のルーレット)
        /// </summary>
        /// <param name="rouletteId"></param>
        /// <param name="clearPiece"></param>
        public void SetRoulette(int rouletteId, bool clearPiece = true)
        {
            var rouletteData = TestDataManager.GetRouletteData(rouletteId);
            SetRoulette(rouletteData);
        }

        /// <summary>
        /// ルーレット設定(装備武器の初期ルーレット)
        /// </summary>
        public void SetRoulette(bool keepSelect = false)
        {
            if (m_character.WeaponData != null)
            {
                var rouletteData = TestDataManager.GetRouletteData(m_character.WeaponData.rouletteId);
                SetRoulette(rouletteData,keepSelect:keepSelect);
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
            int frameCount = 0;

            //初期値の場合は先頭を選択状態にしておく
            if(m_selectedPieceIndex == -1)
            {
                m_selectedPieceIndex = 0;
            }

            m_pieceList[m_selectedPieceIndex].SetSelect(true);

            while (true)
            {
                frameCount++;

                //6フレ経過後に次にマスに移動
                if(frameCount >= 6)
                {
                    m_pieceList[m_selectedPieceIndex].SetSelect(false);
                    
                    m_selectedPieceIndex++;
                    if(m_selectedPieceIndex >= m_pieceList.Count)
                    {
                        m_selectedPieceIndex = 0;
                    }

                    m_pieceList[m_selectedPieceIndex].SetSelect(true);

                    frameCount = 0;
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

