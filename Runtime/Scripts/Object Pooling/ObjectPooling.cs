using UnityEngine;
using System.Collections.Generic;

namespace Heartfield.Pooling
{
    public sealed class ObjectPooling : ObjectPooling<Transform>
    {
        public ObjectPooling(Transform prefab, int size) : base(prefab, size) { }
        public ObjectPooling(List<Transform> prefabs, int size) : base(prefabs, size) { }
    }

    public class ObjectPooling<T> where T : Component
    {
        List<Queue<T>> list = new List<Queue<T>>();

        void Initialize(T prefab, int size)
        {
            if (size == 0)
            {
                Debug.LogError("Pooling size should be higher than 0");
                return;
            }

            var objectPool = new Queue<T>();

            for (int i = 0; i < size; i++)
            {
                var go = Object.Instantiate(prefab, new Vector3(0, -10000, 0), Quaternion.identity);
                objectPool.Enqueue(go);
            }

            list.Add(objectPool);
        }

        public ObjectPooling(T prefab, int size)
        {
            Initialize(prefab, size);
        }

        public ObjectPooling(List<T> prefabs, int size)
        {
            for (int i = 0; i < prefabs.Count; i++)
            {
                Initialize(prefabs[i], size);
            }
        }

        public T Instantiate(int id, Vector3 position, Quaternion rotation)
        {
            var objectToSpawn = list[id].Dequeue();
            objectToSpawn.transform.SetPositionAndRotation(position, rotation);
            list[id].Enqueue(objectToSpawn);

            return objectToSpawn;
        }

        public T Instantiate(int id, Vector3 position) => Instantiate(id, position, Quaternion.identity);
        public T Instantiate(Vector3 position, Quaternion rotation) => Instantiate(0, position, rotation);
        public T Instantiate(Vector3 position) => Instantiate(position, Quaternion.identity);
        public T InstantiateRandom(Vector3 position, Quaternion rotation) => Instantiate(Random.Range(0, list.Count), position, rotation);
        public T InstantiateRandom(Vector3 position) => InstantiateRandom(position, Quaternion.identity);
    }
}