using System;
using System.Collections.Generic;
using System.Linq;

public class RemoveNumbersOccuringOddNumberOfTimes
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of integer numbers, each on its own line. " +
            "To end the sequence, input a blank line.");
        List<int> sequence = GetSequence();

        // Using a dictionary to store the number of occurrences of each number.
        // The keys are the numbers and the values - the number of occurrences
        Dictionary<int, int> numbersCount = new Dictionary<int, int>();

        // If the key is already in the dictionary, increase the occurrences by one, 
        // else add it (and set the initial number of occurrences to 1)
        foreach (var number in sequence)
        {
            if (numbersCount.Keys.Contains(number))
            {
                numbersCount[number]++;
            }
            else
            {
                numbersCount.Add(number, 1);
            }
        }

        // Remove all numbers from the sequence whose number of occurences is odd
        sequence.RemoveAll(number => numbersCount[number] % 2 != 0);

        Console.WriteLine(string.Join(Environment.NewLine, sequence));
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