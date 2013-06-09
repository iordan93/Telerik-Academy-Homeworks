using System;
using System.Collections.Generic;

public class ReverseNumbersUsingStack
{
    public static void Main()
    {
        Console.WriteLine("Please enter a sequence of integer numbers, each on its own line. " +
            "To end the sequence, input a blank line.");

        Stack<int> sequence = GetSequence();
        
        // Caching the initial count because it will change when removing elements
        int count = sequence.Count;
        for (int i = 0; i < count; i++)
        {
            int currentNumber = sequence.Pop();
            Console.WriteLine(currentNumber);
        }
    }

    private static Stack<int> GetSequence()
    {
        Stack<int> sequence = new Stack<int>();

        string input = Console.ReadLine();
        while (input != string.Empty)
        {
            int number = int.Parse(input);
            sequence.Push(number);
            input = Console.ReadLine();
        }

        return sequence;
    }
}
