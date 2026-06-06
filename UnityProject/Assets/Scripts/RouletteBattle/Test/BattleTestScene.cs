using DataImporter;
using NPOI.SS.Formula.Functions;
using NPOI.SS.UserModel;
using RouletteBattle.Battle;
using RouletteBattle.Battle.Character;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using Unity.Collections;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class BattleTestScene : MonoBehaviour
{
    enum State
    {
        None = -1,

        INIT,
        MAIN,

        Max
    }

    [SerializeField]
    private RouletteBattle.Roulette[] m_roulette;

    private BattleCharacter chara1;
    private BattleCharacter chara2;

    private State m_currentState;

    public void Start()
    {
        ChangeState(State.INIT);
    }

    private void ChangeState(State state)
    {
        switch (state)
        {
            case State.INIT:
                StartCoroutine(InitializeAsync(()=>
                {
                    ChangeState(State.MAIN);
                }));
                break;
            case State.MAIN:
                StartCoroutine(MainLoopAsync());
                break;
        }

        m_currentState = state;
    }

    private IEnumerator InitializeAsync(Action initializedAction = null)
    {
        yield return TestDataManager.InitializeAsync();

        chara1 = new BattleCharacter();
        chara1.Init(1, 1);
        chara1.SetInitStatus(new CharacterInitStatus()
        {
            id = 1,
            hp = 100,
            mp = 0,
            intelligence = 0,
            strength = 10,
            speed = 1,
        });

        chara2 = new BattleCharacter();
        chara2.Init(2, 2);
        chara2.SetInitStatus(new CharacterInitStatus()
        {
            id = 2,
            hp = 85,
            mp = 0,
            intelligence = 10,
            strength = 5,
            speed = 1,
        });

        m_roulette[0].Initialize(chara1);
        m_roulette[1].Initialize(chara2);

        initializedAction?.Invoke();

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
    }

    private IEnumerator MainLoopAsync()
    {
        Debug.Log("バトル開始");

        int rouletteTarget = 0;
        int opponentPlayerNum = 0;
        RoulettePieceParameter selectPieceParam;
        BattleCommandData commandData = null;
        BattleCharacter chara;
        bool endBattle = false;
        bool turnEnd = false;

        while (true)
        {
            Debug.Log($"プレイヤー{rouletteTarget + 1}のターン");

            turnEnd = false;

            while (!turnEnd)
            {
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

                commandData = m_roulette[rouletteTarget].GetSelectCommand();
                switch (commandData.commandType)
                {
                    case CommandType.Attack:
                        {
                            opponentPlayerNum = rouletteTarget ^ 1;
                            chara = GetCharacter(opponentPlayerNum);
                            var owner = GetCharacter(rouletteTarget);
                            int damage = CalcDamage(owner, chara, commandData);
                            chara.Damage(damage);
                            Debug.Log($"プレイヤー{rouletteTarget + 1}の{commandData.commandName} プレイヤー{opponentPlayerNum + 1}に{damage}のダメージ");
                            if (chara.CurrentHP <= 0)
                            {
                                Debug.Log($"プレイヤー{opponentPlayerNum + 1}は力尽きた プレイヤー{rouletteTarget + 1}の勝利");
                                endBattle = true;
                            }
                        }
                        turnEnd = true;
                        break;
                    case CommandType.NextRoulette:
                        {
                            m_roulette[rouletteTarget].SetRoulette(commandData.rouletteId);
                        }
                        Debug.Log($"プレイヤー{rouletteTarget+1}の{commandData.commandName}");
                        break;
                }

                yield return null;
            }

            if (endBattle)
            {
                break;
            }

            //ルーレット設定をデフォに戻す
            m_roulette[rouletteTarget].SetRoulette(true);
            //ルーレット対象プレイヤーを入れ替え
            rouletteTarget ^= 1;

            yield return null;
        }

        Debug.Log("バトル終了");

        yield break;
    }


    private int CalcDamage(BattleCharacter owner, BattleCharacter target, BattleCommandData useCommand)
    {
        int baseCharacterPower = 0;
        switch (useCommand.attackType)
        {
            case AttackAttributeType.Physical:
                baseCharacterPower = owner.m_status.Strength;
                break;
            case AttackAttributeType.Magic:
                baseCharacterPower = owner.m_status.Intelligence;
                break;
        }

        int damageValue = 0;
        switch (useCommand.powerCalclateType)
        {
            case PowerCalclateMethodType.CharacterPower:
                damageValue = baseCharacterPower;
                break;
            case PowerCalclateMethodType.AddCharacterPower:
                damageValue = baseCharacterPower + useCommand.power;
                break;
        }

        return damageValue;
    }
}
