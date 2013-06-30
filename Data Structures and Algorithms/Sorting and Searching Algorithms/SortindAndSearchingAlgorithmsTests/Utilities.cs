namespace SortindAndSearchingAlgorithmsTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Utilities
    {
        private static readonly Random generator = new Random();

        public static IList<int> GetRandomCollection(int count)
        {
            IList<int> collection = new List<int>();

            for (int i = 0; i < count; i++)
            {
                collection.Add(generator.Next());
            }

            return collection;
        }

        public static IList<int> GetSortedCollection(int count)
        {
            IList<int> collection = new List<int>();

            for (int i = 0; i < count; i++)
            {
                collection.Add(i);
            }

            return collection;
        }

        public static IList<int> GetReversedCollection(int count)
        {
            IList<int> collection = new List<int>();

            for (int i = count; i >= 0; i--)
            {
                collection.Add(i);
            }

            return collection;
        }

        public static IList<int> GetFewUniqueItemsCollection(int count, int uniqueCount)
        {
            int[] values = new int[uniqueCount];
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = i;
            }

            IList<int> collection = new List<int>();
            for (int i = 0; i < count; i++)
            {
                int nextIndex = generator.Next(0, values.Length);
                collection.Add(values[nextIndex]);
            }

            return collection;
        }
    }
}
