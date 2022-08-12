using UnityEngine;
using System.Collections;

namespace Heartfield
{
    public static class MonoBehaviourHelper
    {
        static MonoBehaviourDummy dummy;

        public delegate void UnityMethod();
        public static UnityMethod OnPostRender;

        static MonoBehaviourHelper()
        {
            var go = new GameObject("[MonoBehaviour Dummy]");
            dummy = go.AddComponent<MonoBehaviourDummy>();
            Object.DontDestroyOnLoad(dummy);
        }

        public static Coroutine StartCoroutine(string methodName)
        {
            return dummy.StartCoroutine(methodName);
        }

        public static Coroutine StartCoroutine(IEnumerator routine)
        {
            return dummy.StartCoroutine(routine);
        }

        public static Coroutine StartCoroutine(string methodName, object value)
        {
            return dummy.StartCoroutine(methodName, value);
        }

        public static void StopCoroutine(IEnumerator routine)
        {
            dummy.StopCoroutine(routine);
        }

        public static void StopCoroutine(Coroutine routine)
        {
            dummy.StopCoroutine(routine);
        }

        public static void StopCoroutine(string methodName)
        {
            dummy.StopCoroutine(methodName);
        }
    }

    sealed class MonoBehaviourDummy : MonoBehaviour
    {
        void OnPostRender()
        {
            MonoBehaviourHelper.OnPostRender?.Invoke();
        }
    }
}