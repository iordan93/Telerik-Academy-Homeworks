using System;
using System.Collections.Generic;
using System.Linq;

public class GetNumberOfOccurrences
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of integer numbers, each on its own line. " +
            "To end the sequence, input a blank line.");
        List<int> sequence = GetSequence();

        // Using a dictionary in the same manner like before 
        // but this time we want the keys to appear sorted by value, 
        // not by order of adding to the sequence
        SortedDictionary<int, int> numbersCount = new SortedDictionary<int, int>();

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

        foreach (var number in numbersCount.Keys)
        {
            int occurences = numbersCount[number];
            Console.WriteLine(occurences == 1 ? "{0} -> {1} time" : "{0} -> {1} times", number, occurences);
        }
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