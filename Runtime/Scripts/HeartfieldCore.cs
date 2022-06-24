using UnityEngine;

namespace Heartfield
{
    [DefaultExecutionOrder(-1000)]
    public abstract class HeartfieldCore : MonoBehaviour
    {
        [HideInInspector] Transform tr;
        public Transform GetTransform => tr;

        [HideInInspector] GameObject go;
        public GameObject GetGameObject => go;

        [HideInInspector] bool _init = false;

        void Init()
        {
            if (_init)
                return;

            tr = transform;
            go = gameObject;

            _init = true;
        }

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            Init();
        }
#endif

        protected virtual void Awake()
        {
            Init();
        }
    }
}