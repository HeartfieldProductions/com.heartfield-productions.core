using Heartfield;
using UnityEngine;
using UnityEditor;

namespace HeartfieldEditor
{
    sealed class GameManagerEditorWindow : EditorWindow
    {
        static GameManager managerSO;
        static Editor managerEditor;

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

            managerSO = Resources.Load<GameManager>("Game Manager Asset");
            managerEditor = Editor.CreateEditor(managerSO);
        }

        void OnGUI()
        {
            managerEditor.OnInspectorGUI();
        }
    }
}