using System;
using System.Collections.Generic;
using System.Linq;

    internal static class Extensions
    {
        internal static bool IsSorted<T>(this IEnumerable<T> elements) where T : IComparable<T>
        {
            // If there are no elements, the collection is sorted, else compare each element to the one before it
            if (!elements.Any())
            {
                return true;
            }

            T current = elements.First();

            foreach (T item in elements.Skip(1))
            {
                if (current.CompareTo(item) > 0)
                {
                    return false;
                }

                current = item;
            }

            return true;
        }
    }