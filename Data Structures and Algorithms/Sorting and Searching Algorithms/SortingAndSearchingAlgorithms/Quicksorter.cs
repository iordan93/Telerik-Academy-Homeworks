namespace SortingAndSearchingAlgorithms
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class QuickSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            IList<T> sortedCollection = QuickSort(collection);
            
            collection.Clear();
            foreach (var item in sortedCollection)
            {
                collection.Add(item);
            }
        }

        private static IList<T> QuickSort(IList<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            if (collection.Count <= 1)
            {
                return collection;
            }

            T pivot = GetPivot(collection);

            collection.Remove(pivot);
            IList<T> left = new List<T>();
            IList<T> right = new List<T>();

            foreach (var item in collection)
            {
                if (item.CompareTo(pivot) <= 0)
                {
                    left.Add(item);
                }
                else
                {
                    right.Add(item);
                }
            }

            left = QuickSort(left);
            right = QuickSort(right);
            collection = left;
            collection.Add(pivot);
            collection = collection.Concat(right).ToList();

            return collection;
        }

        private static T GetPivot(IList<T> collection)
        {
            T leftCandidate = collection[0];
            T middleCandidate = collection[collection.Count - 1];
            T rightCandidate = collection[collection.Count / 2];

            if (leftCandidate.CompareTo(middleCandidate) >= 0)
            {
                if (leftCandidate.CompareTo(rightCandidate) <= 0)
                {
                    return leftCandidate;
                }
                else if (rightCandidate.CompareTo(middleCandidate) >= 0)
                {
                    return middleCandidate;
                }
                else
                {
                    return rightCandidate;
                }
            }
            else
            {
                if (middleCandidate.CompareTo(rightCandidate) <= 0)
                {
                    return middleCandidate;
                }
                else
                {
                    return rightCandidate;
                }
            }
        }
    }
}
