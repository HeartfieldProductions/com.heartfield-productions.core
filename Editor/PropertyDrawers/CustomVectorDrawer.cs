using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Heartfield;

namespace HeartfieldEditor
{
    [CustomPropertyDrawer(typeof(CustomVectorAttribute))]
    sealed class CustomVectorDrawer : PropertyDrawer
    {
        SerializedProperty x;
        SerializedProperty y;
        SerializedProperty z;

        string name;
        bool cache = false;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            if (!cache)
            {
                name = property.displayName;

                property.Next(true);
                x = property.Copy();
                property.Next(true);
                y = property.Copy();
                property.Next(true);
                z = property.Copy();

                cache = true;
            }

            Rect contentPosition = EditorGUI.PrefixLabel(position, new GUIContent(name));

            //Check if there is enough space to put the name on the same line (to save space)
            if (position.height > 16f)
            {
                position.height = 16f;
                EditorGUI.indentLevel += 1;
                contentPosition = EditorGUI.IndentedRect(position);
                contentPosition.y += 18f;
            }

            float half = contentPosition.width * .333f;
            GUI.skin.label.padding = new RectOffset(3, 3, 6, 6);

            //show the X and Y from the point
            EditorGUIUtility.labelWidth = 14f;
            contentPosition.width *= .333f;
            EditorGUI.indentLevel = 0;

            // Begin/end property & change check make each field
            // behave correctly when multi-object editing.
            EditorGUI.BeginProperty(contentPosition, label, x);
            {
                EditorGUI.BeginChangeCheck();
                float newVal = EditorGUI.FloatField(contentPosition, new GUIContent("X"), x.floatValue);
                
                if (EditorGUI.EndChangeCheck())
                    x.floatValue = newVal;
            }
            EditorGUI.EndProperty();

            contentPosition.x += half;

            EditorGUI.BeginProperty(contentPosition, label, y);
            {
                EditorGUI.BeginChangeCheck();
                float newVal = EditorGUI.FloatField(contentPosition, new GUIContent("Y"), y.floatValue);
                
                if (EditorGUI.EndChangeCheck())
                    y.floatValue = newVal;
            }
            EditorGUI.EndProperty();

            contentPosition.x += half;

            EditorGUI.BeginProperty(contentPosition, label, z);
            {
                EditorGUI.BeginChangeCheck();
                float newVal = EditorGUI.FloatField(contentPosition, new GUIContent("Z"), z.floatValue);
                
                if (EditorGUI.EndChangeCheck())
                    z.floatValue = newVal;
            }
            EditorGUI.EndProperty();
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return Screen.width < 333 ? (16f + 18f) : 16f;
        }
    }
}