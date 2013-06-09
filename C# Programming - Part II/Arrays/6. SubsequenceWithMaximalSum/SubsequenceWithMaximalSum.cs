using System;
using System.Numerics;

class SubsequenceWithMaximalSum
{
    static void Main()
    {
        Console.WriteLine("This program will find the subsequence with maximal sum in an integer array. The elements need not be consequent.");

        // Read and check the input
        int n = 0;
        while (n <= 0)
        {
            Console.Write("How many elements should the array have? ");
            n = int.Parse(Console.ReadLine());
        }
        int[] array = new int[n];
        Console.WriteLine("Enter the elements of the array one by one.");
        for (int index = 0; index < n; index++)
        {
            Console.Write("{0}: ", index);
            array[index] = int.Parse(Console.ReadLine());
        }
        int k = 0;
        while ((k <= 0) || (k > n))
        {
            Console.Write("The subsequence we are looking for should contain K elements. Enter K: ");
            k = int.Parse(Console.ReadLine());
        }

        // We should find K elements with maximal sum, i.e. the biggest K elements
        Array.Sort(array);
        int maxSum = 0;
        for (int index = array.Length - 1; index > array.Length - 1 - k; index--)
        {
            maxSum += array[index];
        }

        // Produce output
        Console.WriteLine("The maximal sum of elements in the array is {0}", maxSum);
    }
}