using UnityEngine;
using UnityEditor;
using Heartfield;

namespace HeartfieldEditor
{
    [CustomPropertyDrawer(typeof(DisplayNameAttribute))]
    sealed class DisplayNameDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            try
            {
                var att = (DisplayNameAttribute)attribute;

                if (IsArray(property) == false)
                {
                    label.text = att.GetLabel;
                }
                else
                {
                    Debug.LogWarningFormat("{0}(\"{1}\") doesn't support arrays ", typeof(DisplayNameAttribute).Name, att.GetLabel);
                }

                EditorGUI.PropertyField(position, property, label);
            }
            catch (System.Exception ex)
            {
                //Debug.LogException(ex);
            }
        }

        bool IsArray(SerializedProperty property)
        {
            string path = property.propertyPath;
            int idot = path.IndexOf('.');

            if (idot == -1)
                return false;

            string propName = path.Substring(0, idot);
            var p = property.serializedObject.FindProperty(propName);

            return p.isArray;
        }
    }
}