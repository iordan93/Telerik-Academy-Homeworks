using System;
class CompareArraysElementByElement
{
    static void Main()
    {
        Console.WriteLine("This program will compare two integer arrays element by element.");
        Console.Write("How many elements should the arrays have? ");
        int length = int.Parse(Console.ReadLine());

        // Initialize arrays
        int[] firstArray = new int[length];
        int[] secondArray = new int[length];

        // Read array elements
        Console.WriteLine("Enter the elements of the first array one by one.");
        for (int index = 0; index < length; index++)
        {
            Console.Write("{0}: ", index);
            firstArray[index] = int.Parse(Console.ReadLine());
        }
        Console.WriteLine("Enter the elements from the second array one by one.");
        for (int index = 0; index < length; index++)
        {
            Console.Write("{0}: ", index + 1);
            secondArray[index] = int.Parse(Console.ReadLine());
        }

        // Compare arrays
        Console.WriteLine();
        for (int index = 0; index < length; index++)
        {
            if (firstArray[index] < secondArray[index])
            {
                Console.WriteLine("{0} < {1}", firstArray[index], secondArray[index]);
            }
            if (firstArray[index] > secondArray[index])
            {
                Console.WriteLine("{0} > {1}", firstArray[index], secondArray[index]);
            }
            if (firstArray[index] == secondArray[index])
            {
                Console.WriteLine("{0} = {1}", firstArray[index], secondArray[index]);
            }
        }

    }
}
