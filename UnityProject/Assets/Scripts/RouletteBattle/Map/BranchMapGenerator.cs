using System.Collections.Generic;
using UnityEngine;

namespace RouletteBattle
{
    public class BranchMapGenerator : MonoBehaviour
    {
        public GameObject tilePrefab;      // UIのマスプレハブ（Image等が入ったもの）
        public RectTransform mapParent;    // ⭐ Canvas内のマップを配置したい親パネル
        public int mainRouteLength = 12;
        public float tileSize = 80f;       // ⭐ UIのピクセル単位の間隔（例: 80ピクセル）

        private List<BoardTile> allTiles = new List<BoardTile>();

        void Start()
        {
            //GenerateBranchMap();
        }

        public void ClearTiles()
        {
            foreach (var tile in allTiles)
            {
                if(tile != null)
                {
                    Destroy(tile.gameObject);
                }
            }
            allTiles.Clear();
        }

        public void GenerateBranchMap()
        {
            ClearTiles();

            Vector2Int currentPos = Vector2Int.zero;
            BoardTile previousTile = null;

            for (int i = 0; i < mainRouteLength; i++)
            {
                BoardTile mainTile = CreateTile(currentPos, TileType.Normal);

                if (previousTile != null) previousTile.nextTiles.Add(mainTile);
                else mainTile.type = TileType.Start;

                // 確率で分岐（前回同様のロジック）
                if (i > 1 && i < mainRouteLength - 3 && Random.value < 0.3f)
                {
                    Vector2Int branchPos1 = currentPos + new Vector2Int(0, 1);  // 上にそれる
                    Vector2Int branchPos2 = currentPos + new Vector2Int(1, 1);  // 右に進む
                    Vector2Int mergePos = currentPos + new Vector2Int(2, 0);    // 合流点

                    BoardTile b1 = CreateTile(branchPos1, TileType.Enemy);
                    BoardTile b2 = CreateTile(branchPos2, TileType.Heal);

                    mainTile.nextTiles.Add(b1);
                    b1.nextTiles.Add(b2);

                    currentPos = mergePos;
                    BoardTile mergeTile = CreateTile(currentPos, TileType.Normal);

                    b2.nextTiles.Add(mergeTile);
                    mainTile.nextTiles.Add(mergeTile);

                    previousTile = mergeTile;
                    i++;
                    currentPos += Vector2Int.right;
                    continue;
                }

                previousTile = mainTile;
                currentPos += Vector2Int.right;
            }

            if (allTiles.Count > 0) allTiles[allTiles.Count - 1].type = TileType.Goal;

            ApplyTileSettings();
        }

        BoardTile CreateTile(Vector2Int gridPos, TileType type)
        {
            // ⭐ Instantiateの第3引数に親（mapParent）を指定する
            GameObject obj = Instantiate(tilePrefab, mapParent);

            // ⭐ UIの座標指定には RectTransform を使用する
            RectTransform rt = obj.GetComponent<RectTransform>();
            if (rt != null)
            {
                // グリッド座標からUIのローカル座標（アンカー基準）を計算
                rt.anchoredPosition = new Vector2(gridPos.x * tileSize, gridPos.y * tileSize);
            }

            BoardTile tile = obj.GetComponent<BoardTile>();
            if (tile == null) tile = obj.AddComponent<BoardTile>();

            tile.gridPosition = gridPos;
            tile.type = type;
            allTiles.Add(tile);
            return tile;
        }

        void ApplyTileSettings()
        {
            foreach (var tile in allTiles)
            {
                tile.name = $"Tile_{tile.type}";
                if (tile.tileImage == null) continue;

                // SpriteRendererの代わりにImageの色を変える
                if (tile.nextTiles.Count > 1) tile.tileImage.color = Color.yellow;
                else if (tile.type == TileType.Start) tile.tileImage.color = Color.green;
                else if (tile.type == TileType.Goal) tile.tileImage.color = Color.red;
                else if (tile.type == TileType.Enemy) tile.tileImage.color = Color.magenta;
                else if (tile.type == TileType.Heal) tile.tileImage.color = Color.cyan;
                else tile.tileImage.color = Color.white;
            }
        }
    }
}


