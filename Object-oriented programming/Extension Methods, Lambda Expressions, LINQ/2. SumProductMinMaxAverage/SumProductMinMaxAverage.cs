using System;
using System.Collections.Generic;
using System.Linq;

public static class SumProductMinMaxAverage
{
    public static decimal Sum<T>(this IEnumerable<T> collection)
    {
        // Sum each element in the collection
        // To apply arithmetic operators, we have to use dynamic type
        decimal sum = 0;
        foreach (T item in collection)
        {
            sum += Convert.ToDecimal(item);
        }
        return sum;
    }

    public static decimal Product<T>(this IEnumerable<T> collection)
    {
        // Take the product of all elements in the collection
        // To apply arithmetic operators, we have to use dynamic type
        decimal product = 1;
        foreach (T item in collection)
        {
            checked
            {
                product *= Convert.ToDecimal(item);
            }
        }
        return product;
    }

    public static T Min<T>(this IEnumerable<T> collection) where T : IComparable
    {
        T min = collection.First<T>();
        foreach (T item in collection)
        {
            if (item.CompareTo(min) < 0)
            {
                min = item;
            }
        }
        return min;
    }

    public static T Max<T>(this IEnumerable<T> collection) where T : IComparable
    {
        T max = collection.First<T>();
        foreach (T item in collection)
        {
            if (item.CompareTo(max) > 0)
            {
                max = item;
            }
        }
        return max;
    }

    public static decimal Average<T>(this  IEnumerable<T> collection)
    {
        decimal sum = collection.Sum<T>();
        int count = collection.Count<T>();
        return sum / count;
    }
}