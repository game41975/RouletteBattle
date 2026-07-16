using System.Collections;
using UnityEngine;
using System.Collections.Specialized;

namespace RouletteBattle
{
    using Mono.Cecil.Cil;
    using RouletteBattle.Battle.Character;
    using System;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using UnityEngine;
    using UnityEngine.UI;

    public class ScrollMenuUI : MonoBehaviour
    {
        [Header("UI要素の設定")]
        [SerializeField] private ScrollRect m_scrollRect;
        [SerializeField] private ScrollMenuUIContent buttonPrefab;       // 可変幅ボタンのプレハブ

        [Header("レイアウト設定")]
        [SerializeField] private float horizontalSpacing = 10f; // ボタン間の横の隙間
        [SerializeField] private float verticalSpacing = 10f;   // 行同士の縦の隙間

        private List<KeyValuePair<RectTransform, List<ScrollMenuUIContent>>> m_rowContentObjects
            = new List<KeyValuePair<RectTransform, List<ScrollMenuUIContent>>>();

        void Start()
        {
            
        }

        public void Initialize(CharacterStyleData[] styleDatas)
        {

        }

        private void ClearObjects()
        {
            for(int i = 0; i < m_rowContentObjects.Count; i++)
            {
                if (m_rowContentObjects[i].Key != null)
                {
                    Destroy(m_rowContentObjects[i].Key.gameObject);
                }

                foreach(var obj in m_rowContentObjects[i].Value)
                {
                    if(obj != null)
                    {
                        Destroy(obj.gameObject);
                    }
                }
            }
            m_rowContentObjects.Clear();
        }

        private void GenerateContentObject()
        {
            //表示領域（Content）の最大横幅を取得
            float maxWidth = m_scrollRect.viewport.rect.width;
            //オブジェクトの配置先(最後尾の行)を取得
            var targetRow = GetLastRow();
            int rowNum = m_rowContentObjects.Count;

            var obj = Instantiate(buttonPrefab, targetRow);

            // 💡重要：Content Size Fitterによるサイズ決定を即座に強制確定させる
            LayoutRebuilder.ForceRebuildLayoutImmediate(obj.Rect);

            // 生成したボタンの横幅を取得
            float buttonWidth = obj.Rect.rect.width;

            // 今の行に足した場合の幅を計算（2個目以降は隙間も足す）
            float nextLineWidth = buttonWidth + CalculateWidth(rowNum);

            // 【はみ出し判定】最大幅を超える場合は、次の行へ移す
            if (nextLineWidth > maxWidth)
            {
                // 新しい行（Row）を作成して、ボタンをそこへ引っ越しさせる
                targetRow = CreateNewRow();
                obj.transform.SetParent(targetRow, false);
            }

            // 最後に全体のレイアウトを再計算
            LayoutRebuilder.ForceRebuildLayoutImmediate(m_scrollRect.content);

            int index = m_rowContentObjects.FindIndex(_ => _.Key == targetRow);
            if(index != -1)
            {
                m_rowContentObjects[index].Value.Add(obj);
            }
        }

        // 新しい「行」オブジェクトを生成する関数
        private RectTransform CreateNewRow()
        {
            GameObject rowObj = new GameObject("Row", typeof(RectTransform));
            RectTransform rt = rowObj.GetComponent<RectTransform>();
            //アンカー設定(左上)
            rt.anchorMin = Vector2.up;
            rt.anchorMax = Vector2.up;
            rt.pivot = Vector2.up;

            rowObj.transform.SetParent(m_scrollRect.content, false);
            
            HorizontalLayoutGroup layout = rowObj.AddComponent<HorizontalLayoutGroup>();
            layout.childControlWidth = true;
            layout.childControlHeight = true;
            layout.childForceExpandWidth = false;
            layout.childForceExpandHeight = false;
            layout.spacing = horizontalSpacing;

            ContentSizeFitter fitter = rowObj.AddComponent<ContentSizeFitter>();
            fitter.verticalFit = ContentSizeFitter.FitMode.PreferredSize;
            fitter.horizontalFit = ContentSizeFitter.FitMode.PreferredSize;

            m_rowContentObjects.Add(new KeyValuePair<RectTransform, List<ScrollMenuUIContent>>(rt,new List<ScrollMenuUIContent>()));

            return rt;
        }

        private RectTransform GetLastRow()
        {
            if (m_rowContentObjects.Count == 0) return CreateNewRow();
            return m_rowContentObjects[m_rowContentObjects.Count - 1].Key;
        }

        private float CalculateWidth(int row)
        {
            float result = 0;

            if (m_rowContentObjects.Count < row) return 0;

            for(int i = 0;i< m_rowContentObjects[row-1].Value.Count; i++)
            {
                result += m_rowContentObjects[row-1].Value[i].Rect.rect.width;
                if(i > 0)
                {
                    result += horizontalSpacing;
                }
            }
            
            return result;
        }
    }
}