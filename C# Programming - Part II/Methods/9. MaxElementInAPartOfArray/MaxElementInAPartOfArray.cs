using System;

class MaxElementInAPartOfArray
{
    static int[] InitializeIntArray()
    {
        Console.Write("How many numbers should the array have? ");
        int length = int.Parse(Console.ReadLine());
        int[] intArray = new int[length];
        Console.WriteLine("Now enter the elements of the array one by one.");
        for (int i = 0; i < length; i++)
        {
            Console.Write("{0}: ", i);
            intArray[i] = int.Parse(Console.ReadLine());
        }
        return intArray;
    }

    static int FindBiggestNumberInSubarray(int[] array, int start)
    {
        int max = int.MinValue;
        for (int index = start; index < array.Length; index++)
        {
            if (array[index] > max)
            {
                max = array[index];
            }
        }
        return max;
    }

    static int[] SortAscending(int[] array) 
    {
        // Selection sort
        int minValue = int.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            // Suppose that the minimum is equal to the ith element
            minValue = array[i];
            // Check all the elements in the array after the ith element if some of them is smaller
            for (int j = i + 1; j < array.Length; j++)
            {
                // If some element after the ith is smaller than it, swap array[i] and array[j]
                if (array[j] <= array[i])
                {
                    minValue = array[j];
                    array[j] = array[i];
                    array[i] = minValue;
                }
            }
        }
        return array;
    }

    static int[] SortDescending(int[] array)
    {
        SortAscending(array);
        Array.Reverse(array);
        return array;
    }

    static void PrintArray(int[] intArray)
    {
        for (int i = 0; i < intArray.Length; i++)
        {
            Console.Write("{0} ", intArray[i]);
        }
        Console.WriteLine();
    }

    static void Main()
    {
        Console.WriteLine("This program will find the maximal element in an integer array, starting from a given index, and then will sort the array.");

        // Read input
        int[] intArray = InitializeIntArray();
        int index = -1;
        while ((index < 0) || (index >= intArray.Length))
        {
            Console.WriteLine("Enter the index you want to start from: ");
            index = int.Parse(Console.ReadLine());
        }

        int biggest = FindBiggestNumberInSubarray(intArray, index);

        // Output - first part
        Console.WriteLine("The biggest number in the subarray {0} - {1} is {2}.", index, intArray.Length - 1, biggest);

        // Sort the array in ascending and descending order (using selection sort and the newly created method) and print it
        SortAscending(intArray);
        PrintArray(intArray);

        SortDescending(intArray);
        PrintArray(intArray);
    }
}