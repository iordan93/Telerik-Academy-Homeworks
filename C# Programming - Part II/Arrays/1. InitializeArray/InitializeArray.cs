using System;
class InitializeArray
{
    static void Main()
    {
        Console.WriteLine("This program initializes an array, fills it, and prints it to the console.");
        // Initialize array
        int length = 20;
        int[] intArray = new int[length];

        // Fill array
        for (int index = 0; index < length; index++)
        {
            intArray[index] = 5 * index;
        }

        // Print array to the console
        for (int index = 0; index < length; index++)
        {
            Console.Write("{0} ", intArray[index]);
        }
        Console.WriteLine();
    }
}