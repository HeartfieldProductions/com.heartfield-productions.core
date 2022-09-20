using Heartfield;
using UnityEngine;
using UnityEditor;

namespace HeartfieldEditor
{
    internal sealed class GameManagerEditorWindow : EditorWindow
    {
        static GameManagerAsset managerSO;
        static Editor managerEditor;

        const string GAME_MANAGER_PATH = "Packages/com.heartfield-productions.core/Runtime/Resources/Game Manager Asset.asset";

        [MenuItem("Heartfield Productions/Game Manager")]
        static void Create()
        {
            var window = GetWindow<GameManagerEditorWindow>(false, "Game Manager");
            window.Show();
        }

        void OnEnable()
        {
            if (managerEditor != null)
                return;

            managerSO = AssetDatabase.LoadAssetAtPath<GameManagerAsset>(GAME_MANAGER_PATH);
            managerEditor = Editor.CreateEditor(managerSO);
        }

        void OnGUI()
        {
            managerEditor.OnInspectorGUI();
        }
    }
}