using UnityEngine;
using System.Collections;

namespace Heartfield
{
    public static class CoroutineHelpers
    {
        static CoroutineDummy dummy;

        static CoroutineHelpers()
        {
            var gameObject = new GameObject();
            dummy = gameObject.AddComponent<CoroutineDummy>();
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

    class CoroutineDummy : MonoBehaviour { }
}