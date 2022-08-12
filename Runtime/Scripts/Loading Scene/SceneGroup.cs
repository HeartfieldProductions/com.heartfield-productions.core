using UnityEngine;

namespace Heartfield.SceneManagement
{
    [CreateAssetMenu(fileName = "New Scene Group Asset", menuName = "Heartfield Productions/Scene Management/Scene Group Asset")]
    public sealed class SceneGroup : ScriptableObject
    {
        [SerializeField] int[] scenes;
        [SerializeField] int activeScene;

        int legth;
        float lengthFraction;

        void Initialize()
        {
            if (scenes == null)
                return;

            legth = scenes.Length;
            lengthFraction = 1f / legth;
        }

        public void Initialize(int sceneInBuildIndex, int activeScene)
        {
            scenes = new int[] { sceneInBuildIndex };
            this.activeScene = activeScene;
            Initialize();
        }

        void OnEnable()
        {
            Initialize();
        }

        public float LengthFraction => lengthFraction;
        public int Length => legth;
        public int this[int index] => scenes[index];
        public int ActiveScene => activeScene;
    }
}