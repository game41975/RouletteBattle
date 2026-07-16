using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RouletteBattle
{
    using System.Collections.Generic;
    using UnityEngine;
    using UnityEngine.UI; // 追加

    public enum TileType { Start, Goal, Normal, Shop, Enemy, Heal }

    public class BoardTile : MonoBehaviour
    {
        public TileType type;
        public Vector2Int gridPosition;
        public List<BoardTile> nextTiles = new List<BoardTile>();

        // uGUIのImageの色を変えるための参照
        [HideInInspector] public Image tileImage;

        void Awake()
        {
            tileImage = GetComponent<Image>();
        }

        public void OnPlayerEnter()
        {
            Debug.Log($"{type}マスに止まった！");
        }
    }


}