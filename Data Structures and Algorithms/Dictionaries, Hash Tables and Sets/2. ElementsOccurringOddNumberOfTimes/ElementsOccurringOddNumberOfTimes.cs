using System;
using System.Collections.Generic;
using System.Linq;

public class ElementsOccurringOddNumberOfTimes
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of strings, each on its own line. " +
        "To end the sequence, input a blank line.");
        List<string> sequence = GetSequence();

        Dictionary<string, int> elementsCount = new Dictionary<string, int>();

        foreach (var element in sequence)
        {
            if (elementsCount.ContainsKey(element))
            {
                elementsCount[element]++;
            }
            else
            {
                elementsCount[element] = 1;
            }
        }

        foreach (var element in elementsCount.Keys)
        {
            int occurences = elementsCount[element];
            if (occurences % 2 == 1)
            {
                Console.WriteLine(element);
            }
        }
    }

    private static List<string> GetSequence()
    {
        List<string> sequence = new List<string>();

        string input = Console.ReadLine();
        while (input != string.Empty)
        {
            sequence.Add(input);
            input = Console.ReadLine();
        }

        return sequence;
    }
}
