using System;

class MaximalSequenceOfEqualElements
{
    static void Main()
    {
        Console.WriteLine("This program will find the maximum sequence of equal numbers in an integer array. If there are more than one, it will return the first sequence.");

        // Read and check input
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

        // Find the longest sequence
        int currentStart = 0;
        int currentLength = 1;
        int longestSequenceStart = 0;
        int longestSequenceLength = 1;

        for (int index = 1; index < array.Length; index++)
        {
            if (array[index] == array[index - 1])
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
                currentStart = index;
            }
            if (longestSequenceLength < currentLength)
            {
                longestSequenceLength = currentLength;
                longestSequenceStart = currentStart;
            }
        }

        // Produce output
        Console.WriteLine("Start: {0}", longestSequenceStart);
        Console.WriteLine("Length: {0}", longestSequenceLength);
    }
}
