using UnityEngine;

namespace Heartfield
{
    public abstract class HeartfieldCoreSingleton<T> : MonoBehaviour
    {
        protected abstract T Source { get; }

        static T _instance;
        public static T Instance => _instance;

        void InitializeSingleton()
        {
            if (_instance != null)
            {
                Destroy(this);
                return;
            }

            _instance = Source;
        }

#if UNITY_EDITOR
        void OnValidate()
        {
            InitializeSingleton();
        }
#endif

        void Awake()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
                return;
#endif

            InitializeSingleton();
            DontDestroyOnLoad(this);
        }
    }
}