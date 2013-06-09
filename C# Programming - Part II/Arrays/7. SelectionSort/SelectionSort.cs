using System;

class SelectionSort
{
    static void Main()
    {
        Console.WriteLine("This program will sort an integer array using the selection sort algorithm.");

        // Read and check the input
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

        // Selection sort
        int minValue = 0;
        for (int i = 0; i < length; i++)
        {
            // Suppose that the minimum is equal to the ith element
            minValue = array[i];
            // Check all the elements in the array after the ith element if some of them is smaller
            for (int j = i + 1; j < length; j++)
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
        
        // Output the sorted array
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write("{0} ", array[i]);
        }

    }
}
