using System;

class NumberOfOccurrences
{
    static int GetNumberOfOccurrences(int[] intArray, int number)
    {
        int counter = 0;
        // Flag whether the number has been found in the array
        bool isFound = false;
        for (int i = 0; i < intArray.Length; i++)
        {
            if (intArray[i] == number)
            {
                counter++;
                isFound = true;
            }
        }
        if (isFound)
        {
            return counter;
        }
        // If the number has not been found in the array, return -1
        else
        {
            return -1;
        }
    }

    static int[] InitializeIntArray()
    {
        Console.Write("How many numbers should the array have? ");
        int length = int.Parse(Console.ReadLine());
        int[] intArray = new int[length];
        Console.WriteLine("Now enter the elements of the array one by one.");
        for (int i = 0; i < length; i++)
        {
            Console.Write("{0}: ", i + 1);
            intArray[i] = int.Parse(Console.ReadLine());
        }
        return intArray;
    }

    static void Output(int occurencesCount)
    {
        if (occurencesCount != -1)
        {
            if (occurencesCount != 1)
            {
                Console.WriteLine("The number occurs {0} times in the array.", occurencesCount);
            }
            else
            {
                Console.WriteLine("The number occurs once in the array.");
            }
        }
        // If the method did not find the number, write an error message
        else
        {
            Console.WriteLine("The number you are looking for is not in the current array.");
        }
    }

    static void Main()
    {
        Console.WriteLine("This program will look for a specified number in an array.");

        // Read the input
        int[] intArray = InitializeIntArray();
        Console.Write("Which number would you like to search for? ");
        int number = int.Parse(Console.ReadLine());

        int occurencesCount = GetNumberOfOccurrences(intArray, number);

        // Output
        Output(occurencesCount);
    }
}