using UnityEngine;
using UnityEditor;

namespace HeartfieldEditor
{
    public static class EditorGUILayoutExtension
    {
        public static void DrawSeparatorLine()
        {
            EditorGUILayout.Separator();
            EditorGUILayout.LabelField(string.Empty, GUI.skin.horizontalSlider);
            EditorGUILayout.Separator();
        }
    }
}