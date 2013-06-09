using System;
using System.Collections.Generic;

public class RemoveAllNegativeNumbers
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of integer numbers, each on its own line. " +
            "To end the sequence, input a blank line.");
        List<int> sequence = GetSequence();

        List<int> nonnegativeNumbers = GetNonnegativeNumbers(sequence);
        Console.WriteLine(string.Join(Environment.NewLine, nonnegativeNumbers));
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

    private static List<int> GetNonnegativeNumbers(List<int> sequence)
    {
        List<int> nonnegativeNumbers = new List<int>();
        foreach (var number in sequence)
        {
            if (number >= 0)
            {
                nonnegativeNumbers.Add(number);
            }
        }

        return nonnegativeNumbers;
    }
}