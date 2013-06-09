using System;
using System.Collections.Generic;

public class PrintFirstMembersOfSequence
{
    public static void Main()
    {
        Console.Write("Please enter the starting integer member of the sequence: ");
        int firstNumber = int.Parse(Console.ReadLine());
        const int MembersCount = 50;

        Queue<int> sequence = new Queue<int>();        
        List<int> firstMembers = new List<int>();
        sequence.Enqueue(firstNumber);

        for (int i = 0; i < MembersCount; i++)
        {
            int current = sequence.Dequeue();

            firstMembers.Add(current);

            sequence.Enqueue(current + 1);
            sequence.Enqueue((2 * current) + 1);
            sequence.Enqueue(current + 2);
        }

        Console.WriteLine(string.Join(Environment.NewLine, firstMembers));
    }
}
