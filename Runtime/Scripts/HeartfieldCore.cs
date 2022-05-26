using UnityEngine;

namespace Heartfield
{
    public class HeartfieldCore : MonoBehaviour
    {
        Transform tr;
        public Transform GetTransform => tr;

        GameObject go;
        public GameObject GetGameObject => go;

        bool _init = false;

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