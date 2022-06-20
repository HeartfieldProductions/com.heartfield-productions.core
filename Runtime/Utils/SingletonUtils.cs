using UnityEngine;

namespace Heartfield
{
    [DefaultExecutionOrder(-1000)]
    public static class SingletonUtils
    {
        public static T Get<T>(T source, T instance) where T : MonoBehaviour
        {
            if (instance != source)
                Object.Destroy(instance);
            else if (instance == null)
                instance = source;

            return instance;
        }
    }
}