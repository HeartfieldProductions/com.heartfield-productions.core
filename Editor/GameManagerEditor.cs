using Heartfield;
using UnityEditor;
using UnityEngine.Internal;
using UnityEngine.SceneManagement;

namespace HeartfieldEditor
{
    [CustomEditor(typeof(GameManager))]
    sealed class GameManagerEditor : Editor
    {
        string[] scenes;

        string[] GetScenesInBuild()
        {
            int scenesCount = SceneManager.sceneCountInBuildSettings;
            

            //if (scenes != null && scenes.Length == scenesCount)
            //    return scenes;

            scenes = new string[scenesCount];

            for (int i = 0; i < scenesCount; i++)
            {
                UnityEngine.Debug.Log(SceneUtility.GetScenePathByBuildIndex(i));
                scenes[i] = SceneManager.GetSceneByBuildIndex(i).name;
            }

            return scenes;
        }

        /*public override void OnInspectorGUI()
        {
            EditorGUI.BeginChangeCheck();

            serializedObject.Update();

            EditorGUI.BeginChangeCheck();
            var pauseIndexProp = serializedObject.FindProperty("pauseMenuSceneIndex");
            var pauseMenuSceneIndex = pauseIndexProp.intValue;
            pauseMenuSceneIndex = EditorGUILayout.Popup("Pause Menu Scene", pauseMenuSceneIndex, GetScenesInBuild());
            pauseIndexProp.intValue = pauseMenuSceneIndex;

            EditorGUILayout.Separator();

            var loadingIndexProp = serializedObject.FindProperty("loadingScreenSceneIndex");
            var loadingScreenSceneIndex = loadingIndexProp.intValue;
            loadingScreenSceneIndex = EditorGUILayout.Popup("Loading Screen Scene", loadingScreenSceneIndex, GetScenesInBuild());
            loadingIndexProp.intValue = loadingScreenSceneIndex;

            if (EditorGUI.EndChangeCheck())
            {
                //GetScenesInBuild();
                serializedObject.ApplyModifiedProperties();
            }
        }*/
    }
}