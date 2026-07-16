using DataImporter;
using RouletteBattle.Battle;
using RouletteBattle.Battle.Character;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public static class TestDataManager
{
    private static List<CharacterClassData> m_testClassDataList = new List<CharacterClassData>();
    private static List<CharacterStyleData> m_testStyleDataList = new List<CharacterStyleData>();
    private static List<Weapon> m_testWeaponDataList = new List<Weapon>();
    private static List<SkillRouletteData> m_testSkillRouletteDataList = new List<SkillRouletteData>();
    private static List<BattleCommandData> m_testCommandDataList = new List<BattleCommandData>();

    private static Dictionary<string, AsyncOperationHandle> m_handles = new Dictionary<string, AsyncOperationHandle>();

    public static IEnumerator InitializeAsync()
    {
        m_testClassDataList.Clear();
        m_testStyleDataList.Clear();
        m_testWeaponDataList.Clear();
        m_testSkillRouletteDataList.Clear();
        m_testCommandDataList.Clear();

        m_testClassDataList.Add(new CharacterClassData()
        {
            classId = 1,
            className = "戦士",
            characterInitStatusId = 1,
        });
        m_testClassDataList.Add(new CharacterClassData()
        {
            classId = 2,
            className = "魔法使い",
            characterInitStatusId = 2,
        });

        m_testStyleDataList.Add(new CharacterStyleData()
        {
            styleId = 1,
            targetClassIds = new int[] { 1 },
            name = "戦士スタイル1",
            description = "",
            type = StyleType.STATUS_BUFF_DEBUFF,
            options = new CharacterStyleOptionData[]
            {
                new CharacterStyleOptionData()
                {
                    target = CharacterParameterType.STR,
                    value = 10
                }
            }
        });
        m_testStyleDataList.Add(new CharacterStyleData()
        {
            styleId = 2,
            targetClassIds = new int[] { 1 },
            name = "戦士スタイル2",
            description = "",
            type = StyleType.STATUS_BUFF_DEBUFF,
            options = new CharacterStyleOptionData[]
            {
                new CharacterStyleOptionData()
                {
                    target = CharacterParameterType.STR,
                    value = 10
                }
            }
        });
        m_testStyleDataList.Add(new CharacterStyleData()
        {
            styleId = 3,
            targetClassIds = new int[] { 1 },
            name = "戦士スタイル3",
            description = "",
            type = StyleType.STATUS_BUFF_DEBUFF,
            options = new CharacterStyleOptionData[]
            {
                new CharacterStyleOptionData()
                {
                    target = CharacterParameterType.STR,
                    value = 10
                }
            }
        });
        m_testStyleDataList.Add(new CharacterStyleData()
        {
            styleId = 4,
            targetClassIds = new int[] { 1 },
            name = "戦士スタイル4",
            description = "",
            type = StyleType.STATUS_BUFF_DEBUFF,
            options = new CharacterStyleOptionData[]
            {
                new CharacterStyleOptionData()
                {
                    target = CharacterParameterType.STR,
                    value = 10
                }
            }
        });

        m_testStyleDataList.Add(new CharacterStyleData()
        {
            styleId = 101,
            targetClassIds = new int[] { 2 },
            name = "魔法使いスタイル1",
            description = "",
            type = StyleType.STATUS_BUFF_DEBUFF,
            options = new CharacterStyleOptionData[]
            {
                new CharacterStyleOptionData()
                {
                    target = CharacterParameterType.INT,
                    value = 10
                }
            }
        });
        //m_testStyleDataList.Add(new CharacterStyleData()
        //{
        //    styleId = 102,
        //    targetClassIds = new int[] { 2 },
        //    name = "魔法使いスタイル2",
        //    description = ""
        //});
        //m_testStyleDataList.Add(new CharacterStyleData()
        //{
        //    styleId = 103,
        //    targetClassIds = new int[] { 2 },
        //    name = "魔法使いスタイル3",
        //    description = ""
        //});

        m_testWeaponDataList.Add(new Weapon()
        {
            itemId = 1,
            itemName = "ショートソード",
            weaponType = WeaponType.Sword,
            rouletteId = 1,

        });
        m_testWeaponDataList.Add(new Weapon()
        {
            itemId = 2,
            itemName = "杖",
            weaponType = WeaponType.Cane,
            rouletteId = 2,
        });

        m_testSkillRouletteDataList.Add(new SkillRouletteData()
        {
            rouletteId = 1,
            commandIds = new int[]
            {
                1000001,
                1000001,
                1000001,
                1000001,
                1000001,
                1000001
            }
        });
        m_testSkillRouletteDataList.Add(new SkillRouletteData()
        {
            rouletteId = 2,
            commandIds = new int[]
            {
                2000001,
                2000001,
                2000001,
                2000004,
                2000004,
                2000004,
            }
        });
        m_testSkillRouletteDataList.Add(new SkillRouletteData()
        {
            rouletteId = 3,
            commandIds = new int[]
            {
                2000001,
                2000002,
                2000003,
                2000001,
                2000002,
                2000003,
            }
        });

        BattleCommandData[] commands = new BattleCommandData[]
        {
            new BattleCommandData()
            {
                commandId = 1000001,
                commandName = "こうげき",
                commandType = CommandType.Attack,
                attackType = AttackAttributeType.Physical,
                rangeType = AttackRangeType.Single,
                powerCalclateType = PowerCalclateMethodType.CharacterPower,
            },
            new BattleCommandData()
            {
                commandId = 2000001,
                commandName = "メラ",
                commandType = CommandType.Attack,
                attackType = AttackAttributeType.Magic,
                rangeType = AttackRangeType.Single,
                powerCalclateType = PowerCalclateMethodType.AddCharacterPower,
                power = 8,
            },
            new BattleCommandData()
            {
                commandId = 2000002,
                commandName = "メラミ",
                commandType = CommandType.Attack,
                attackType = AttackAttributeType.Magic,
                rangeType = AttackRangeType.Single,
                powerCalclateType = PowerCalclateMethodType.AddCharacterPower,
                power = 25,
            },
            new BattleCommandData()
            {
                commandId = 2000003,
                commandName = "イオ",
                commandType = CommandType.Attack,
                attackType = AttackAttributeType.Magic,
                rangeType = AttackRangeType.All,
                powerCalclateType = PowerCalclateMethodType.AddCharacterPower,
                power = 8,
            },
            new BattleCommandData()
            {
                commandId = 2000004,
                commandName = "呪文詠唱",
                commandType = CommandType.NextRoulette,
                attackType = AttackAttributeType.None,
                rangeType = AttackRangeType.None,
                rouletteId = 3,
                //powerCalclateType = PowerCalclateMethodType.AddCharacterPower,
                //power = 8,
            },
        };
        m_testCommandDataList.AddRange(commands);

        yield return LoadSOFilesAsync();

        yield break;
    }

    public static void Release()
    {
        foreach (var item in m_handles)
        {
            if (item.Value.IsValid())
            {
                item.Value.Release();
            }
        }
        m_handles.Clear();
    }

    public static IEnumerator LoadSOFilesAsync()
    {
        yield return LoadSOAsync<CharacterInitStatusList>("CharacterInitStatus");

        yield break;
    }

    private static IEnumerator LoadSOAsync<T>(string assetKey) where T : ScriptableObjectBase
    {
        var handle = Addressables.LoadAssetAsync<T>(assetKey);
        yield return handle.Task;

        if (handle.IsDone)
        {
            m_handles.Add(assetKey,handle);
        }
    } 

    public static CharacterClassData GetClassData(int id)
    {
        return m_testClassDataList.Find(_ => _.classId == id);
    }

    public static CharacterStyleData GetStyleData(int id) 
    {
        return m_testStyleDataList.Find(_ => _.styleId == id);
    }

    public static Weapon GetWeaponData(int id)
    {
        return m_testWeaponDataList.Find(_ => _.itemId == id);
    }

    public static SkillRouletteData GetRouletteData(int id)
    {
        return m_testSkillRouletteDataList.Find(_ => _.rouletteId == id);
    }

    public static BattleCommandData GetCommandData(int id)
    {
        return m_testCommandDataList.Find(_ => _.commandId == id);
    }

    public static CharacterInitStatus GetCharacterInitStatus(int id)
    {
        string key = "CharacterInitStatus";

        if (!m_handles.ContainsKey(key) || !m_handles[key].IsValid()) return null;
        var obj = m_handles[key].Result as CharacterInitStatusList;
        if (obj == null || obj.m_dataList == null) return null;

        return obj.m_dataList.Find(_ => _.id == id);
    }
}