using RouletteBattle.Battle.Character;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using System;
using System.ComponentModel;
using Unity.Collections;
using UnityEngine.AddressableAssets;
using DataImporter;

public class Main : MonoBehaviour
{
    [SerializeField]
    private RouletteBattle.Roulette[] m_roulette;

    private BattleCharacter chara1;
    private BattleCharacter chara2;

    public void Start()
    {
        Type classType = Type.GetType("UnityEngine.MonoBehaviour");
        Type classTyp2 = Type.GetType("MonoBehaviour");
        Type c3 = Type.GetType("RouletteBattle.Skill");
        Type c4 = Type.GetType("TestList");

        chara1 = new BattleCharacter();
        chara1.m_pieceList = new List<PieceParameter>();
        chara1.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Skill, m_value = 20 });
        chara1.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Skill, m_value = 20 });
        chara1.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Skill, m_value = 0 });
        chara1.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Skill, m_value = 20 });
        chara1.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Skill, m_value = 20 });
        chara1.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Skill, m_value = 20 });

        chara2 = new BattleCharacter();
        chara2.m_pieceList = new List<PieceParameter>();
        chara2.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Magic, m_value = 20 });
        chara2.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Magic, m_value = 20 });
        chara2.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Magic, m_value = 20 });
        chara2.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Magic, m_value = 20 });
        chara2.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Magic, m_value = 0 });
        chara2.m_pieceList.Add(new PieceParameter() { m_pieceType = PieceParameter.PieceType.Magic, m_value = 20 });

        m_roulette[0].Initialize(chara1);
        m_roulette[1].Initialize(chara2);

        StartCoroutine(LoadAddressableAssetTest());
        StartCoroutine(MainLoopAsync());
    }

    public IEnumerator LoadAddressableAssetTest()
    {
        var handle = Addressables.LoadAssetAsync<ScriptableObjectBase>("CharacterInitStatus");
        yield return handle.Task;

        if (handle.IsDone)
        {
            var loadData = handle.Result;
        }

        yield break;
    }


    private BattleCharacter GetCharacter(int num)
    {
        if(num == 0)
        {
            return chara1;
        }
        else if(num == 1)
        {
            return chara2;
        }
        return null;
    }

    public void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (!m_roulette[0].IsPlayingRoulette())
        //    {
        //        m_roulette[0].StartRoulette();
        //        Debug.Log("StartRoulette");
        //    }
        //    else
        //    {
        //        m_roulette[0].StopRoulette();
        //    }
        //}
    }

    private IEnumerator MainLoopAsync()
    {
        Debug.Log("バトル開始");

        int rouletteTarget = 0;
        int opponentPlayerNum = 0;
        PieceParameter selectPieceParam;
        BattleCharacter chara;
        bool endBattle = false;

        while (true)
        {
            Debug.Log($"プレイヤー{rouletteTarget + 1}のターン");

            m_roulette[rouletteTarget].StartRoulette();

            yield return new WaitWhile(() => 
            {
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    return false;
                }
                return true;
            });

            m_roulette[rouletteTarget].StopRoulette();

            selectPieceParam = m_roulette[rouletteTarget].GetSelectPieceParameter();
            switch (selectPieceParam.m_pieceType)
            {
                case PieceParameter.PieceType.Damage:
                    opponentPlayerNum = rouletteTarget ^ 1;
                    chara = GetCharacter(opponentPlayerNum);
                    chara.m_healthPoint -= selectPieceParam.m_value;
                    Debug.Log($"プレイヤー{rouletteTarget + 1}の攻撃　プレイヤー{opponentPlayerNum+1}に{selectPieceParam.m_value}のダメージ");
                    if(chara.m_healthPoint <= 0)
                    {
                        Debug.Log($"プレイヤー{opponentPlayerNum + 1}は力尽きた プレイヤー{rouletteTarget + 1}の勝利");
                        endBattle = true;
                    }

                    break;
                case PieceParameter.PieceType.Miss:
                    Debug.Log($"プレイヤー{rouletteTarget + 1}の攻撃はミス");
                    break;
            }

            if (endBattle)
            {
                break;
            }

            //ルーレット対象プレイヤーを入れ替え
            rouletteTarget ^= 1;

            yield return null;
        }

        Debug.Log("バトル終了");

        yield break;
    }

}
