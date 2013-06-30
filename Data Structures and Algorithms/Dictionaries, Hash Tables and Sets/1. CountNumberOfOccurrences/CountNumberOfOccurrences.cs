using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;

public class CountNumberOfOccurrences
{
    public static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        Console.WriteLine("Please enter a sequence of integer numbers, each on its own line. " +
                          "To end the sequence, input a blank line.");
        List<double> sequence = GetSequence();

        Dictionary<double, int> numbersCount = new Dictionary<double, int>();

        foreach (var number in sequence)
        {
            if (numbersCount.ContainsKey(number))
            {
                numbersCount[number]++;
            }
            else
            {
                numbersCount[number] = 1;
            }
        }

        // Sort the dictionary by keys (since we are not allowed to use SortedDictionary from the beginning)
        Dictionary<double, int> sortedNumbersCount =
            (from entry in numbersCount
             orderby entry.Key ascending
             select entry)
             .ToDictionary(pair => pair.Key, pair => pair.Value);

        foreach (var number in sortedNumbersCount.Keys)
        {
            int occurences = sortedNumbersCount[number];
            Console.WriteLine(occurences == 1 ? "{0} -> {1} time" : "{0} -> {1} times", number, occurences);
        }
    }

    private static List<double> GetSequence()
    {
        List<double> sequence = new List<double>();

        string input = Console.ReadLine();
        while (input != string.Empty)
        {
            double number = double.Parse(input);
            sequence.Add(number);
            input = Console.ReadLine();
        }

        return sequence;
    }
}