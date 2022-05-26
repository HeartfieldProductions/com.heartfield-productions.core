using UnityEngine;
using UnityEditor;
using Heartfield;

namespace HeartfieldEditor
{
    [CustomPropertyDrawer(typeof(NavMeshMaskAttribute))]
    public class NavMeshMaskDrawer : PropertyDrawer
    {
        // Draw the property inside the given rect
        public override void OnGUI(Rect position, SerializedProperty serializedProperty, GUIContent label)
        {
            EditorGUI.BeginChangeCheck();
            string[] navMeshAreaNames = GameObjectUtility.GetNavMeshAreaNames();
            //int navMeshArea = serializedProperty.intValue;
            //int selectedIndex = -1;
            
            //for (int i = 0; i < navMeshAreaNames.Length; i++)
            //{
            //    if (GameObjectUtility.GetNavMeshAreaFromName(navMeshAreaNames[i]) == navMeshArea)
            //    {
            //        selectedIndex = i;
            //        break;
            //    }
            //}
            
            int mask = serializedProperty.intValue;

            mask = EditorGUI.MaskField(position, label.text, mask, navMeshAreaNames);
            
            if (EditorGUI.EndChangeCheck())
            {
                //int navMeshAreaFromName = GameObjectUtility.GetNavMeshAreaFromName(navMeshAreaNames[num]);
                serializedProperty.intValue = mask;
            }
        }
    }
}