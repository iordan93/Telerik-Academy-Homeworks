using System;
using System.Collections.Generic;
using System.Linq;

public class FindTheMajorantOfAnArray
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of integer numbers, each on its own line. " +
            "To end the sequence, input a blank line.");
        int[] sequence = GetSequence();

        try
        {
            int majorant = FindMajorant(sequence);
            Console.WriteLine("The majorant of the array is {0}", majorant);
        }
        catch (ArgumentException) 
        {
            Console.WriteLine("The sequence has no majorant.");
        }
    }
  
    private static int FindMajorant(int[] sequence)
    {
        Dictionary<int, int> numbersCount = new Dictionary<int, int>();

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

        foreach (var number in sequence)
        {
            if (numbersCount[number] >= (sequence.Length / 2) + 1)
            {
                return number;
            }
        }

        throw new ArgumentException("The sequence has no majorant.");
    }

    private static int[] GetSequence()
    {
        List<int> sequence = new List<int>();

        string input = Console.ReadLine();
        while (input != string.Empty)
        {
            int number = int.Parse(input);
            sequence.Add(number);
            input = Console.ReadLine();
        }

        return sequence.ToArray();
    }
}