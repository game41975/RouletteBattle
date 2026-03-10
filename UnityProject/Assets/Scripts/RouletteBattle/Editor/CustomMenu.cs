using UnityEditor;
using UnityEngine;

namespace RouletteButtle.Editor
{
    public class CustomMenu : EditorWindow
    {
        private string name;

        [MenuItem("RouletteBattle/OpenWindow")]
        private static void OpenWindow()
        {
            var window = GetWindow<CustomMenu>("UIElements");
            window.titleContent = new GUIContent("RouletteBattleMenu"); // エディタ拡張ウィンドウのタイトル
            window.Show();
        }

        private void OnGUI()
        {
            name = EditorGUILayout.TextField("FileName",name);

            if (GUILayout.Button("Hoge"))
            {

            }
        }
    }
}