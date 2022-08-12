using UnityEngine;
using UnityEditor;
using Heartfield;

namespace HeartfieldEditor
{
    [CustomPropertyDrawer(typeof(ShowOnlyRangeAttribute))]
    public class ShowOnlyRangeDrawer : ReadOnlyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty prop, GUIContent label)
        {
            var attribute = (ShowOnlyRangeAttribute)this.attribute;

            ShowOnlyGUI(attribute, position, prop, out _);

            if (prop.propertyType == SerializedPropertyType.Float)
            {
                EditorGUI.Slider(position, label.text, prop.floatValue + attribute.offset, attribute.min, attribute.max);
            }
            else if (prop.propertyType == SerializedPropertyType.Integer)
            {
                EditorGUI.IntSlider(position, label.text, prop.intValue + (int)attribute.offset, (int)attribute.min, (int)attribute.max);
            }
            else
                EditorGUI.HelpBox(position, "Not Supported", MessageType.Warning);
        }
    }
}