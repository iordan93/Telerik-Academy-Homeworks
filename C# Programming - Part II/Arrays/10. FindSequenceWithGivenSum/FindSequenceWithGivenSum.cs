using System;
class FindSequenceWithGivenSum
{
    static void Main()
    {
        Console.WriteLine("This program will find the first subsequence of K consequent numbers in an integer array whose sum is equal to what the user has set.");

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
        Console.WriteLine("Which sum do you want to search for?");
        int sum = int.Parse(Console.ReadLine());

        // Solve the problem
        // Check if the sum we are searching for has been reached in any subsequence
        bool sumExists = false;
        // The first loop takes the ith number
        int bestArrStart = 0;
        int bestArrEnd = 0;
        for (int i = 0; i < length; i++)
        {
            int currentSum = 0;
            // The second number sums every number after the ith until the current sum is >= sum
            
            for (int j = i; j < length; j++)
            {
                currentSum += array[j];
                // If the current sum is equal to the one stated by the user, the start and end position are respectively i and j
                if (currentSum == sum)
                {
                    bestArrStart = i;
                    bestArrEnd = j;
                    sumExists = true;
                }
                if (sumExists)
                {
                    break;
                }
            }
        }

        // Produce output
        if (sumExists)
        {
            Console.WriteLine("Start position: {0}\tEnd position: {1}", bestArrStart, bestArrEnd);
        }
        else
        {
            Console.WriteLine("There is no such sum of consequent numbers in this array.");
        }
    }
}
