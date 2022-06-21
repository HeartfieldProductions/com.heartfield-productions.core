using UnityEngine;
using UnityEditor;
using Heartfield.Protection.Test;

namespace HeartfieldEditor.Protection
{
    [CustomEditor(typeof(AntiCheatTest))]
    public class AntiCheatEditor : Editor
    {
        static float health;
        static int inventoryCapacity;
        static bool wearArmor;

        static bool[] hasAnomaly = new bool[3] { false, false, false };
        static int anomalyCount;

        static bool showResultInfo;

        bool CheckAnomaly()
        {
            bool result = false;
            anomalyCount = 0;

            for (int i = 0; i < hasAnomaly.Length; i++)
            {
                if (hasAnomaly[i])
                {
                    anomalyCount++;
                    result = true;
                }
            }

            return result;
        }

        public override void OnInspectorGUI()
        {
            var source = (AntiCheatTest)target;

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Health", source.health.ToString());
            EditorGUILayout.LabelField("Inventory Capacity", source.inventoryCapacity.ToString());
            EditorGUILayout.LabelField("Wear Armor", source.wearArmor.ToString());
            EditorGUILayout.EndVertical();

            EditorGUILayout.Separator();

            EditorGUILayout.BeginVertical();
            EditorGUILayout.BeginHorizontal();
            health = EditorGUILayout.FloatField("Health", Mathf.Max(health, 0));
            if (GUILayout.Button("Hack Value"))
            {
                source.health += Random.Range(25, 151);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            inventoryCapacity = EditorGUILayout.IntField("Inventory Capacity", Mathf.Max(inventoryCapacity, 0));
            if (GUILayout.Button("Hack Value"))
            {
                source.inventoryCapacity += Random.Range(5, 16);
            }
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            wearArmor = EditorGUILayout.Toggle("Wear Armor", wearArmor);
            if (GUILayout.Button("Hack Value"))
            {
                source.wearArmor = !source.wearArmor;
            }
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.EndVertical();

            EditorGUILayout.Separator();

            EditorGUILayout.BeginHorizontal();
            if (GUILayout.Button("Check Anomaly"))
            {
                hasAnomaly[0] = source.antiCheat.GetValue(ref source.health, health);
                hasAnomaly[1] = source.antiCheat.GetValue(ref source.inventoryCapacity, inventoryCapacity);
                hasAnomaly[2] = source.antiCheat.GetValue(ref source.wearArmor, wearArmor);

                showResultInfo = true;
            }

            if (GUILayout.Button("Clear Changes"))
            {
                health = 0;
                inventoryCapacity = 0;
                wearArmor = false;

                source.health = 0;
                source.inventoryCapacity = 0;
                source.wearArmor = false;
                source.antiCheat.Clear();

                for (int i = 0; i < hasAnomaly.Length; i++)
                {
                    hasAnomaly[i] = false;
                }

                showResultInfo = false;
            }
            EditorGUILayout.EndHorizontal();

            if (!showResultInfo)
                return;

            if (CheckAnomaly())
            {
                EditorGUILayout.HelpBox($"{anomalyCount} anomalies identified", MessageType.Error);
            }
            else
            {
                EditorGUILayout.HelpBox("Everything looks fine", MessageType.Info);
            }
        }
    }
}