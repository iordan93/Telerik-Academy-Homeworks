using System;
using System.Collections.Generic;
class FindSequenceOfKElementsWithSumS
{
    static void Main()
    {
        Console.WriteLine("This program will find the subsequence of K numbers in an integer array whose sum is equal to what the user has set.");

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
        Console.WriteLine("How many elements should the subset have?");
        int subsetLength = 0;
        while ((subsetLength <= 0) || (subsetLength > length))
        {
            subsetLength = int.Parse(Console.ReadLine());
        }

        // Find all possible sums
        int currentSum = 0;
        int count = 0;
        int currentLength = 0;
        // Binary algorithm for finding all subsets - (2^n-1) times get the bits from j one by one. 
        // The bits represent whether a number is (1) or is not (0) in the current subset.
        // Include a counter to check if the length of the subset is exactly K
        for (int i = 1; i < (int)Math.Pow(2, length); i++)
        {
            currentSum = 0;
            currentLength = 0;
            for (int j = 0; j <= length; j++)
            {
                int bit = (i & (1 << j)) >> j;
                if (bit == 1)
                {
                    currentSum += array[j];
                    currentLength++;
                }
            }
            // If the current sum is equal to the one we are looking for, there is one more subset that meets the requirements in the problem 
            if ((currentSum == sum) && (currentLength == subsetLength))
            {
                count++;
            }
        }

        // Output
        if (count > 1)
        {
            Console.WriteLine("There are {0} subsets with {1} elements whose sum is {2}.", count, subsetLength, sum);
        }
        else if (count == 1)
        {
            Console.WriteLine("There is 1 subset with {0} elements whose sum is {1}.", subsetLength, sum);
        }
        else
        {
            Console.WriteLine("There are no subsets with {0} elements whose sum is {1}.", subsetLength, sum);
        }
    }
}
