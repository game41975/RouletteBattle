using RouletteBattle;
using System.Collections;
using UnityEngine;

public class MapTestScene : MonoBehaviour
{
    [SerializeField] BranchMapGenerator m_mapGenerator;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_mapGenerator.GenerateBranchMap();
        }
    }
}