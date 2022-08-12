using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using Heartfield.SceneManagement;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace HeartfieldEditor.SceneManagement
{
    [CustomEditor(typeof(SceneGroup))]
    sealed class SceneGroupsEditor : Editor
    {
        ReorderableList scenesList;
        string[] scenesInBuildNames;

        bool CheckScenesAvailability(out List<int> includedScenes)
        {
            includedScenes = new List<int>();

            for (int i = 0; i < scenesList.count; i++)
            {
                includedScenes.Add(scenesList.serializedProperty.GetArrayElementAtIndex(i).intValue);
            }

            return includedScenes.Count != SceneManager.sceneCountInBuildSettings;
        }

        string[] GetScenesInBuildNames()
        {
            int scenesCount = SceneManager.sceneCountInBuildSettings;

            CheckScenesAvailability(out List<int> includedScenes);

            scenesInBuildNames = new string[scenesCount];

            for (int i = 0; i < scenesCount; i++)
            {
                if (includedScenes.Contains(i))
                    continue;

                scenesInBuildNames[i] = SceneManager.GetSceneByBuildIndex(i).name;
            }

            return scenesInBuildNames;
        }

        void AddScene(int sceneIndex, ReorderableList list)
        {
            ReorderableList.defaultBehaviours.DoAddButton(list);
            list.serializedProperty.GetArrayElementAtIndex(list.count - 1).intValue = sceneIndex;
        }

        void ShowScenesInBuildContextMenu(ReorderableList list)
        {
            var menu = new GenericMenu();
            var addScene = new GenericMenu.MenuFunction2((index) => AddScene((int)index, list));
            var scenesName = GetScenesInBuildNames();

            for (int i = 0; i < scenesName.Length; i++)
            {
                string name = scenesName[i];
                menu.AddItem(new GUIContent(name), false, addScene, SceneManager.GetSceneByName(name).buildIndex);
            }

            menu.ShowAsContext();
        }

        void CheckScenesList(SerializedObject so)
        {
            if (scenesList != null)
                return;

            var property = so.FindProperty("scenes");
            float lineHeight = EditorGUIUtility.singleLineHeight;
            bool displayAddButton = scenesList == null || CheckScenesAvailability(out _);

            scenesList = new ReorderableList(so, property, true, true, displayAddButton, true);

            scenesList.drawHeaderCallback += (rect) => EditorGUI.LabelField(rect, "Scenes");

            scenesList.drawElementCallback += (rect, index, isActive, isFocused) =>
                 {
                     var element = scenesList.serializedProperty.GetArrayElementAtIndex(index);
                     var sceneName = SceneManager.GetSceneByBuildIndex(element.intValue).name;

                     EditorGUI.LabelField(rect, sceneName);
                 };

            scenesList.onAddCallback += (list) =>
            {
                ShowScenesInBuildContextMenu(list);
            };
        }

        public override void OnInspectorGUI()
        {
            var so = new SerializedObject(target);

            EditorGUI.BeginChangeCheck();
            CheckScenesList(so);
            so.Update();
            scenesList.DoLayoutList();
            
            if (EditorGUI.EndChangeCheck())
                so.ApplyModifiedProperties();
        }
    }
}