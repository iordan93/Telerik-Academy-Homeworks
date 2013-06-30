namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SelectionSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (collection.Count <= 1)
            {
                return;
            }

            int minElementIndex;
            for (int i = 0; i < collection.Count - 1; i++)
            {
                minElementIndex = i;
                for (int j = i + 1; j < collection.Count; j++)
                {
                    if (collection[j].CompareTo(collection[minElementIndex]) < 0)
                    {
                        minElementIndex = j;
                    }
                }

                if (minElementIndex != i)
                {
                    Swap(collection, i, minElementIndex);
                }
            }
        }

        private static void Swap(IList<T> collection, int firstIndex, int secondIndex)
        {
            T temporaryStorage = collection[firstIndex];
            collection[firstIndex] = collection[secondIndex];
            collection[secondIndex] = temporaryStorage;
        }
    }
}