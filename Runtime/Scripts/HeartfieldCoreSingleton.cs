using UnityEngine;

namespace Heartfield
{
    public abstract class HeartfieldCoreSingleton<T> : HeartfieldCore
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
        protected override void OnValidate()
        {
            base.OnValidate();
            InitializeSingleton();
        }
#endif

        protected override void Awake()
        {
#if UNITY_EDITOR
            if (!Application.isPlaying)
                return;
#endif

            base.Awake();
            InitializeSingleton();
            DontDestroyOnLoad(this);
        }
    }
}