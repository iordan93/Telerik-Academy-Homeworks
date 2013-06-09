using System;
using System.Diagnostics;
using System.Linq;

public class Assertions
{
    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        // Preconditions - the array should not be null
        Debug.Assert(arr != null, "The array to be sorted should not be null.");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        // Postconditions - the array should be sorted
        Debug.Assert(arr.IsSorted(), "The array is not sorted.");
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        // Preconditions - the array should not be null and should be sorted first
        // The postconditions are checked in the internal method
        Debug.Assert(arr != null, "The array to be searched should not be null.");
        Debug.Assert(arr.IsSorted(), "The array to be searched should be sorted first.");

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        return minElementIndex;
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        // Searched value not found
        // The preconditions have been already checked - look only for postconditions
        // The method should not be trying to return -1 but the value is in the array
        Debug.Assert(!arr.Contains(value), "The array contains the value but the method is trying to return -1");
        return -1;
    }
}
