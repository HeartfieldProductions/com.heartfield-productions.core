using UnityEngine;
using Heartfield.Utils;
using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

namespace Heartfield.SceneManagement
{
    public static class LoadingManager
    {
        static Queue<int> activeScenes = new Queue<int>();
        static List<int> persistentScenes = new List<int>();
        static float totalLoadingProgress;

        static Dictionary<int, SceneGroup> cachedSceneGroups = new Dictionary<int, SceneGroup>();

        internal delegate void LoadingScreenCheck();
        internal static LoadingScreenCheck OnLoadingScreenOpened;
        internal static LoadingScreenCheck OnLoadingScreenClosed;

        public delegate void LoadingProgressCheck(float progress);
        public static LoadingProgressCheck OnLoadingProgress;

        public delegate void SceneChangeCheck(int sceneIndex);
        public static SceneChangeCheck OnLoadScenesStarted;
        public static SceneChangeCheck OnLoadScene;
        public static SceneChangeCheck OnLoadScenesCompleted;
        public static SceneChangeCheck OnUnloadScene;
        public static SceneChangeCheck OnFinishLoadScene;

        public static void RegisterPersistentScene(int sceneIndex)
        {
            if (!persistentScenes.Contains(sceneIndex))
                persistentScenes.Add(sceneIndex);
        }

        public static void Load(SceneGroup sceneGroup)
        {
            MonoBehaviourHelper.StartCoroutine(LoadScenes(sceneGroup));
        }

        public static void Load(int sceneInBuildIndex)
        {
            if (!cachedSceneGroups.ContainsKey(sceneInBuildIndex))
            {
                var sceneGroup = ScriptableObject.CreateInstance<SceneGroup>();
                sceneGroup.Initialize(sceneInBuildIndex, sceneInBuildIndex);
                cachedSceneGroups.Add(sceneInBuildIndex, sceneGroup);
            }

            Load(cachedSceneGroups[sceneInBuildIndex]);
        }

        public static void ToggleUiScene(int sceneIndex, bool display)
        {
            if (display)
                SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
            else
                SceneManager.UnloadSceneAsync(sceneIndex);
        }

        static IEnumerator LoadingProgress(AsyncOperation operation, float scenesFraction)
        {
            operation.allowSceneActivation = false;

            while (!operation.isDone)
            {
                float currentProgress = operation.progress;

                if (currentProgress >= .9f)
                {
                    currentProgress = 1f;
                    operation.allowSceneActivation = true;
                }

                totalLoadingProgress = currentProgress * scenesFraction;
                OnLoadingProgress?.Invoke(totalLoadingProgress);

                yield return null;
            }
        }

        static IEnumerator LoadScenes(SceneGroup scenesToLoad)
        {
            if (scenesToLoad.ActiveScene == SceneManager.GetActiveScene().buildIndex)
                yield break;

            int loadScreenSceneIndex = GameManager.Instance.LoadingScreenSceneIndex;
            totalLoadingProgress = 0;

            yield return SceneManager.LoadSceneAsync(loadScreenSceneIndex, LoadSceneMode.Additive);

            //Unload active scenes
            while (activeScenes.Count > 0)
            {
                var sceneIndex = activeScenes.Dequeue();
                var operation = SceneManager.UnloadSceneAsync(sceneIndex);
                OnUnloadScene?.Invoke(sceneIndex);

                yield return LoadingProgress(operation, scenesToLoad.LengthFraction);
            }

            OnLoadingScreenOpened?.Invoke();
            OnLoadScenesStarted?.Invoke(scenesToLoad.ActiveScene);

            //Add new scene to load to the queue
            for (int i = 0; i < scenesToLoad.Length; i++)
            {
                var sceneIndex = scenesToLoad[i];

                //if isn't a persistent scene, add it to queue
                if (!persistentScenes.Contains(sceneIndex))
                    activeScenes.Enqueue(sceneIndex);

                var operation = SceneManager.LoadSceneAsync(sceneIndex, LoadSceneMode.Additive);
                OnLoadScene?.Invoke(sceneIndex);

                if (sceneIndex == scenesToLoad.ActiveScene)
                    OnLoadingScreenClosed?.Invoke();

                yield return LoadingProgress(operation, scenesToLoad.LengthFraction);

                OnFinishLoadScene?.Invoke(sceneIndex);
            }

            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(scenesToLoad.ActiveScene));

            yield return Yielders.WaitSeconds(.1f);

            OnLoadScenesCompleted?.Invoke(scenesToLoad.ActiveScene);

            yield return SceneManager.UnloadSceneAsync(loadScreenSceneIndex);
        }

        public static float GetLoadingProgress() => Mathf.RoundToInt(totalLoadingProgress);
    }
}