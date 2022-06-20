using System.Collections.Generic;

namespace Heartfield.Protection
{
    public sealed class AntiCheat
    {
        Dictionary<int, object> lastPropertyValue;

        public AntiCheat()
        {
            lastPropertyValue = new Dictionary<int, object>();
        }

        public AntiCheat(int capacity)
        {
            lastPropertyValue = new Dictionary<int, object>(capacity);
        }

        public void Clear()
        {
            lastPropertyValue.Clear();
        }

        int GetID<T>(T value)
        {
            return value.GetType().MetadataToken;
        }

        void RegistryChange<T>(int id, T value)
        {
            if (!lastPropertyValue.ContainsKey(id))
                lastPropertyValue.Add(id, value);

            lastPropertyValue[id] = value;
        }

        public void RegistryChange<T>(ref T current, T value)
        {
            RegistryChange(GetID(current), value);
            current = value;
        }

        /// <returns>return true if there is an anomaly with this property and revert the current value to the previous registered one</returns>
        public bool GetValue<T>(ref T current, T value)
        {
            bool hasAnomaly = GetValue(ref current, value, out _);

            if (hasAnomaly)
                current = (T)lastPropertyValue[GetID(current)];

            return hasAnomaly;
        }

        /// <returns>return true if there is an anomaly with this property</returns>
        public bool GetValue<T>(ref T current, T value, out T result)
        {
            int id = GetID(current);
            result = value;

            if (!lastPropertyValue.ContainsKey(id))
            {
                RegistryChange(id, value);
                current = value;
                return false;
            }

            bool hasAnomaly = !current.Equals(lastPropertyValue[id]);

            if (!hasAnomaly)
            {
                current = value;
                lastPropertyValue[id] = value;
            }

            return hasAnomaly;
        }
    }
}