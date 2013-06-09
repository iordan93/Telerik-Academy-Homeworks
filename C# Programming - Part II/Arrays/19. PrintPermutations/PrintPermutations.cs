using System;

class PrintPermutations
{
    static void Main()
    {
        Console.WriteLine("This program will find all permutations of numbers in the range [1; ...; N].");
        // Read input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("How many elements should the array have? ");
            length = int.Parse(Console.ReadLine());
        }
        int[] array = new int[length];
        // Initialize the array with numbers from 1 to n
        for (int i = 0; i < length; i++)
        {
            array[i] = i + 1;
        }

        // Find the permutations recursively and produce output
        Console.WriteLine("All permutations are: ");
        FindPermutations(array, 0, array.Length - 1);
    }

    private static void FindPermutations(int[] array, int start, int length)
    {
        // If the starting element is equal to the length of the array, print the current permutation
        if (start == length)
        {
            // Print elements in one row, separated by spaces
            for (int i = 0; i <= length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
        else
        {
            // If the starting element is not equal to the length of the array, swap the values of the starting element and the current one.
            // Recursively call the fuction again to find all permutations of (n-1) elements and swap the current element and the starting one again.
            for (int i = start; i <= length; i++)
            {
                int temp = array[i];
                array[i] = array[start];
                array[start] = temp;
                FindPermutations(array, start + 1, length);
                temp = array[i];
                array[i] = array[start];
                array[start] = temp;
            }
        }
    }
}
