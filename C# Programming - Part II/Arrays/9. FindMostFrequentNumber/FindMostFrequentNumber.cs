using System;
class FindMostFrequentNumber
{
    static void Main()
    {
        Console.WriteLine("This program will find the the most frequent number in an integer array.");

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

        // Sort the array
        Array.Sort(array);

        // Find the maximal sequence of equal elements in the sorted array
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

        // Output - the array[longestSequenceStart] is the most frequent number in the array
        Console.WriteLine("The most frequent number in the array is: {0}", array[longestSequenceStart]);
    }
}