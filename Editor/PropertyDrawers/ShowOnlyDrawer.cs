using UnityEngine;
using UnityEditor;
using Heartfield;

namespace HeartfieldEditor
{
    [CustomPropertyDrawer(typeof(ShowOnlyAttribute), true)]
    public class ReadOnlyDrawer : PropertyDrawer
    {
        protected void ShowOnlyGUI<T>(T attribute, Rect position, SerializedProperty prop, out string valueStr) where T : ShowOnlyAttribute
        {
            switch (prop.propertyType)
            {
                case SerializedPropertyType.Integer:
                    //intValue = prop.intValue + (int)att.offset;
                    valueStr = (prop.intValue + (int)attribute.offset).ToString();
                    break;

                case SerializedPropertyType.Boolean:
                    valueStr = prop.boolValue.ToString();
                    break;

                case SerializedPropertyType.Float:
                    //floatValue = prop.floatValue + att.offset;
                    valueStr = (prop.floatValue + attribute.offset).ToString("f2").Replace(',', '.');
                    break;

                case SerializedPropertyType.String:
                    valueStr = prop.stringValue;
                    break;

                case SerializedPropertyType.Enum:
                    if (prop.enumValueIndex >= 0)
                        valueStr = prop.enumDisplayNames[prop.enumValueIndex];
                    else
                        valueStr = "(Error)";
                    break;

                case SerializedPropertyType.Vector2:
                    valueStr = prop.vector2Value.ToString();
                    break;

                case SerializedPropertyType.Vector2Int:
                    valueStr = prop.vector2IntValue.ToString();
                    break;

                case SerializedPropertyType.Vector3:
                    valueStr = prop.vector3Value.ToString();
                    break;

                case SerializedPropertyType.Vector3Int:
                    valueStr = prop.vector3IntValue.ToString();
                    break;

                case SerializedPropertyType.Vector4:
                    valueStr = prop.vector4Value.ToString();
                    break;

                case SerializedPropertyType.Quaternion:
                    valueStr = prop.quaternionValue.ToString();
                    break;

                case SerializedPropertyType.Rect:
                    valueStr = prop.rectValue.ToString();
                    break;

                case SerializedPropertyType.RectInt:
                    valueStr = prop.rectIntValue.ToString();
                    break;

                case SerializedPropertyType.ObjectReference:
                    try
                    {
                        valueStr = prop.objectReferenceValue.ToString();
                    }
                    catch (System.NullReferenceException)
                    {
                        if (prop.type == "PPtr<$Transform>")
                            valueStr = "None (Transform)";
                        else if (prop.type == "PPtr<$GameObject>")
                            valueStr = "None (Game Object)";
                        else
                            valueStr = "(Not Supported)";
                    }
                    break;

                case SerializedPropertyType.Generic:
                    valueStr = string.Empty;
                    EditorGUI.PropertyField(position, prop);
                    break;

                case SerializedPropertyType.AnimationCurve:
                    valueStr = string.Empty;
                    EditorGUI.PropertyField(position, prop);
                    break;

                default:
                    valueStr = "(Not Supported)";
                    Debug.Log(prop.type);
                    break;
            }
        }

        public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
        {
            ShowOnlyGUI((ShowOnlyAttribute)attribute, position, prop, out string valueStr);
            EditorGUI.LabelField(position, label.text, valueStr);
        }
    }
}