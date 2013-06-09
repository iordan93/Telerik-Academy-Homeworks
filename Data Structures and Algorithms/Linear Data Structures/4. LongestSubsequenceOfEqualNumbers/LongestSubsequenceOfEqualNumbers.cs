using System;
using System.Collections.Generic;

public class LongestSubsequenceOfEqualNumbers
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of integer numbers, each on its own line. " +
        "To end the sequence, input a blank line.");

        List<int> sequence = GetSequence();

        List<int> longestSubsequence = GetLongestSubsequenceOfEqualNumbers(sequence);
        Console.WriteLine(string.Join(Environment.NewLine, longestSubsequence));
    }

    public static List<int> GetLongestSubsequenceOfEqualNumbers(List<int> sequence)
    {
        if (sequence == null)
        {
            throw new ArgumentNullException("sequence", "The initial sequence should not be null.");
        }

        if (sequence.Count == 0)
        {
            throw new ArgumentException("The initial sequence should not be empty.");
        }

        int currentStart = 0;
        int currentLength = 1;
        int longestSubsequenceStart = 0;
        int longestSubsequenceLength = 1;

        for (int index = 1; index < sequence.Count; index++)
        {
            if (sequence[index] == sequence[index - 1])
            {
                currentLength++;
            }
            else
            {
                currentLength = 1;
                currentStart = index;
            }

            if (longestSubsequenceLength < currentLength)
            {
                longestSubsequenceLength = currentLength;
                longestSubsequenceStart = currentStart;
            }
        }

        List<int> longestSubsequence = new List<int>();
        for (int i = longestSubsequenceStart; i < longestSubsequenceStart + longestSubsequenceLength; i++)
        {
            longestSubsequence.Add(sequence[i]);
        }

        return longestSubsequence;
    }

    private static List<int> GetSequence()
    {
        List<int> sequence = new List<int>();

        string input = Console.ReadLine();
        while (input != string.Empty)
        {
            int number = int.Parse(input);
            sequence.Add(number);
            input = Console.ReadLine();
        }

        return sequence;
    }
}
