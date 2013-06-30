namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

        public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            IList<T> sortedCollection = MergeSort(collection);

            collection.Clear();
            foreach (var item in sortedCollection)
            {
                collection.Add(item);
            }
        }

        private static IList<T> MergeSort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (collection.Count <= 1)
            {
                return collection;
            }

            int middle = collection.Count / 2;

            IList<T> right = new List<T>();
            IList<T> left = new List<T>();

            for (int index = 0; index < middle; index++)
            {
                left.Add(collection[index]);
            }

            for (int index = middle; index < collection.Count; index++)
            {
                right.Add(collection[index]);
            }

            left = MergeSort(left);
            right = MergeSort(right);

            IList<T> result = Merge(left, right);
            return result;
        }

        private static IList<T> Merge(IList<T> left, IList<T> right)
        {
            IList<T> result = new List<T>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left[0].CompareTo(right[0]) <= 0)
                    {
                        result.Add(left[0]);
                        left.RemoveAt(0);
                    }
                    else
                    {
                        result.Add(right[0]);
                        right.RemoveAt(0);
                    }
                }
                else if (right.Count > 0)
                {
                    result.Add(right[0]);
                    right.RemoveAt(0);
                }
                else if (left.Count > 0)
                {
                    result.Add(left[0]);
                    left.RemoveAt(0);
                }
            }

            return result;
        }
    }
}