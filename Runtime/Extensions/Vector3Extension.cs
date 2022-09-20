using UnityEngine;

namespace Heartfield
{
    public static class Vector3Extension
    {
        public static float DistanceIgnoreY(this Vector3 from, Vector3 to)
        {
            Vector3 a = from;
            a.y = 0f;
            Vector3 b = to;
            b.y = 0f;
            return Vector3.Distance(a, b);
        }

        public static Vector3 DirectionIgnoreY(this Vector3 from, Vector3 to)
        {
            Vector3 a = from;
            a.y = 0f;
            Vector3 b = to;
            b.y = 0f;
            return b - a;
        }

        public static Vector3 PositionIgnoreY(this Transform transform)
        {
            Vector3 position = transform.position;
            position.y = 0f;
            return position;
        }

        public static Vector3 IgnoreY(this Vector3 vector)
        {
            vector.y = 0f;
            return vector;
        }
    }
}