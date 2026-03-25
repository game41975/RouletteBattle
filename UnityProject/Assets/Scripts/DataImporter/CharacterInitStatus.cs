using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

//******************************
// Output by DataImporter.cs
//******************************

namespace DataImporter
{
    public class CharacterInitStatusList : ScriptableObjectBase
    {
        [SerializeField]
        public List<CharacterInitStatus> m_dataList = new List<CharacterInitStatus>();

        public override void InitParam(List<List<string>> list)
        {
            if(list == null || list[0] == null)
        {
            return;
        }

            FieldInfo[] fields = typeof(CharacterInitStatus).GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);


            const int headerCount = 2;
            for(int row = 0; row < list.Count; row++)
            {
                if (list[row].Count != fields.Length)
            {
                Debug.LogError($"The number of elements does not match: row:{row + headerCount}");
                continue;
            }
                var addParam = new CharacterInitStatus();
                ConvertParam<int>(list[row][0], (_convertParam) =>{ addParam.id = _convertParam; });
                ConvertParam<int>(list[row][1], (_convertParam) =>{ addParam.hp = _convertParam; });
                ConvertParam<int>(list[row][2], (_convertParam) =>{ addParam.mp = _convertParam; });
                ConvertParam<int>(list[row][3], (_convertParam) =>{ addParam.strength = _convertParam; });
                ConvertParam<int>(list[row][4], (_convertParam) =>{ addParam.intelligence = _convertParam; });
                ConvertParam<int>(list[row][5], (_convertParam) =>{ addParam.speed = _convertParam; });
                m_dataList.Add(addParam);
            }
        }
    }
}

[System.Serializable]
public class CharacterInitStatus:ScriptableObjectParameterBase
{
    [SerializeField]
    public int id;
    [SerializeField]
    public int hp;
    [SerializeField]
    public int mp;
    [SerializeField]
    public int strength;
    [SerializeField]
    public int intelligence;
    [SerializeField]
    public int speed;
}

