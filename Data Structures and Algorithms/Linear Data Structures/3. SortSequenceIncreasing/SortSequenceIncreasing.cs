using System;
using System.Collections.Generic;

public class SortSequenceIncreasing
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of integer numbers, each on its own line. " +
            "To end the sequence, input a blank line.");
        List<int> sequence = GetSequence();
        
        sequence.Sort();

        // A more interesting way is to sort using a lambda expression:
        // sequence.Sort((x, y) => x.CompareTo(y));
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
