using System;
using System.Collections.Generic;

public class SumAndAverageOfASequence
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of integer numbers, each on its own line. " +
            "To end the sequence, input a blank line.");
        List<int> sequence = GetSequence();

        long sum = FindSum(sequence);
        double average = FindAverage(sequence);
        Console.WriteLine("The sum of the entered sequence is {0}.", sum);
        Console.WriteLine("The average of the entered sequence is {0}.", average);
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

    private static long FindSum(List<int> sequence)
    {
        long sum = 0;
        foreach (var member in sequence)
        {
            sum += member;
        }

        return sum;
    }

    private static double FindAverage(List<int> sequence)
    {
        long sum = FindSum(sequence);
        double average = (double)sum / sequence.Count;

        return average;
    }
}