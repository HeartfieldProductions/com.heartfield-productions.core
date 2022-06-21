using UnityEngine;
using System.Collections.Generic;

namespace Heartfield.Pooling
{
    public sealed class ObjectPooling : ObjectPooling<Transform>
    {
        public ObjectPooling(Transform prefab, int size, bool instantiate = false) : base(prefab, size, instantiate) { }
        public ObjectPooling(Transform[] prefabs, int size, bool instantiate = false) : base(prefabs, size, instantiate) { }
        public ObjectPooling(List<Transform> prefabs, int size, bool instantiate = false) : base(prefabs, size, instantiate) { }
    }

    public class ObjectPooling<T> where T : Component
    {
        List<Queue<T>> list = new List<Queue<T>>();

        void Initialize(T prefab, int size, bool instantiate)
        {
            if (size == 0)
            {
                Debug.LogError("Pooling size should be higher than 0");
                return;
            }

            var objectPool = new Queue<T>();
            var position = new Vector3(0, -10000, 0);
            var rotation = Quaternion.identity;

            for (int i = 0; i < size; i++)
            {
                if (instantiate)
                {
                    var go = Object.Instantiate(prefab, position, rotation);
                    objectPool.Enqueue(go);
                }
                else
                {
                    prefab.transform.SetPositionAndRotation(position, rotation);
                    objectPool.Enqueue(prefab);
                }
            }

            list.Add(objectPool);
        }

        public ObjectPooling(T prefab, int size, bool instantiate = false)
        {
            Initialize(prefab, size, instantiate);
        }

        public ObjectPooling(T[] prefabs, int size,bool instantiate = false)
        {
            for (int i = 0; i < prefabs.Length; i++)
            {
                Initialize(prefabs[i], size, instantiate);
            }
        }

        public ObjectPooling(List<T> prefabs, int size, bool instantiate = false)
        {
            for (int i = 0; i < prefabs.Count; i++)
            {
                Initialize(prefabs[i], size, instantiate);
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