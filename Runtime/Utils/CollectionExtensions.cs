namespace System.Collections.Generic
{
    public static class CollectionExtensions
    {
        public static void Add<T>(this List<T> list, T item, bool ignoreRepeat = false)
        {
            if (!list.Contains(item))
                list.Add(item);
        }

        public static void AddRange<T>(this List<T> list, IEnumerable<T> collection, bool ignoreRepeat = false)
        {
            foreach (var item in collection)
            {
                if (!list.Contains(item))
                    list.Add(item);
            }
        }
    }
}