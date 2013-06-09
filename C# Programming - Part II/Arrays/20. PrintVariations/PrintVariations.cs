using System;

class PrintVariations
{
    static void Main()
    {
        Console.WriteLine("This program will find all variations of K numbers in the range [1; ...; N].");
        // Read input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("How many elements should the array have? ");
            length = int.Parse(Console.ReadLine());
        }
        //int[] array = new int[length];
        int k = 0;
        while ((k <= 0) || (k > length))
        {
            Console.Write("How many elements should each variation contain? ");
            k = int.Parse(Console.ReadLine());
        }

        // Find the variations recursively and produce output
        // Since all variations contain k elements (from n), initialize an array of k elements to store the current variation
        int[] allVariations = new int[k];
        Console.WriteLine("All variations are: ");
        FindVariations(allVariations, 0, length);        
    }

    private static void FindVariations(int[] array, int start, int length)
    {
        // If the length of the array is equal to the starting element, print the resulting array - it contains the current variation
        if (start == array.Length)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
        else 
        {
            // If the length of the array is not equal to the starting element, call the function recursively, this time for (n-1) elements.
            // Do this until length = start and print the array to finish the method's execution.
            for (int j = 1; j <= length; j++)
            {
                array[start] = j;
                FindVariations(array, start + 1, length);
            }
        }
    }
}
