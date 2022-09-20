using System;

namespace Heartfield
{
    [Serializable]
    public readonly struct IndexTable
    {
        readonly int[] table;

        public IndexTable(int range)
        {
            table = new int[range + 2];
            table[0] = range - 1;
            table[^1] = 0;

            for (int i = 1; i < table.Length - 1; i++)
            {
                table[i] = i - 1;
            }
        }

        public int this[int index] => table[index];
        public int Next(int index) => table[index + 2];
        public int Previous(int index) => table[index];
    }

    static class ArrayUtilities { }
}