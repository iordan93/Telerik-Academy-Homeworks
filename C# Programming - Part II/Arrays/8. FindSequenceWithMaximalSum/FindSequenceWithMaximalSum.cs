using System;

class FindSequenceWithMaximalSum
{
    static void Main()
    {
        Console.WriteLine("This program will find the subsequence of K consequent numbers in an integer array whose sum is maximal.");

        // Read input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("How many elements should the array have? ");
            length = int.Parse(Console.ReadLine());
        }
        int[] array = new int[length];
        Console.WriteLine("Enter the elements of the array one by one.");
        for (int index = 0; index < length; index++)
        {
            Console.Write("{0}: ", index);
            array[index] = int.Parse(Console.ReadLine());
        }
        int k = 0;
        while ((k <= 0) || (k > length))
        {
            Console.Write("The subsequence we are looking for should contain K elements. Enter K: ");
            k = int.Parse(Console.ReadLine());
        }

        // Find all subsequences of K consequent elements - {0, ..., K - 1}, {1, ..., K}, {2, ..., K + 1}...
        int maxSum = 0;
        for (int startIndex = 0; startIndex <= length - k; startIndex++)
        {
            int currentSum = 0;
            for (int index = startIndex; index < startIndex + k; index++)
            {
                currentSum += array[index];
            }
            // Set the maximal sum
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
        }

        // Output
        Console.WriteLine(maxSum);
        
    }
}
