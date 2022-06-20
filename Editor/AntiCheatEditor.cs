using UnityEngine;
using UnityEditor;
using Heartfield.Protection.Test;

namespace HeartfieldEditor.Protection
{
    [CustomEditor(typeof(AntiCheatTest))]
    public class AntiCheatEditor : Editor
    {
        float health;
        int inventoryCapacity;
        bool wearArmor;

        static bool[] hasAnomaly = new bool[3] { false, false, false };
        int anomalyCount;

        bool showResultInfo;

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

            EditorGUILayout.LabelField("Health", source.health.ToString());
            EditorGUILayout.LabelField("Inventory Capacity", source.inventoryCapacity.ToString());
            EditorGUILayout.LabelField("Wear Armor", source.wearArmor.ToString());

            EditorGUILayout.Separator();

            health = EditorGUILayout.FloatField("Health", Mathf.Max(health, 0));
            inventoryCapacity = EditorGUILayout.IntField("Inventory Capacity", Mathf.Max(inventoryCapacity, 0));
            wearArmor = EditorGUILayout.Toggle("Wear Armor", wearArmor);

            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.BeginVertical();
            if (GUILayout.Button("Hack Health"))
            {
                source.health += 100;
            }
            if (GUILayout.Button("Hack Inventory Capacity"))
            {
                source.inventoryCapacity += 5;
            }
            if (GUILayout.Button("Hack Wear Armor"))
            {
                source.wearArmor = !source.wearArmor;
            }
            EditorGUILayout.EndVertical();

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
                EditorGUILayout.HelpBox($"{anomalyCount} Anomalies Identified", MessageType.Error);
            }
            else
            {
                EditorGUILayout.HelpBox("Everything looks fine", MessageType.Info);
            }
        }
    }
}