using UnityEngine;

namespace Heartfield.Pooling
{
    public interface IPoolable
    {
        GameObject GetPrefab { get; }
        Transform GetTransform { get; }
    }
}