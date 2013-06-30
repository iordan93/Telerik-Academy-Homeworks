using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

public class SequenceOfColourfulBalls
{
    public static void Main()
    {
        string line = Console.ReadLine();
        Dictionary<char, int> balls = new Dictionary<char, int>();

        for (int i = 0; i < line.Length; i++)
        {
            if (!balls.Keys.Contains(line[i]))
            {
                balls[line[i]] = 1;
            }
            else
            {
                balls[line[i]]++;
            }
        }

        BigInteger allSequences = CalculateFactorial(line.Length);
        BigInteger repeatedSequences = 1;
        foreach (var value in balls.Values)
        {
            repeatedSequences *= CalculateFactorial(value);
        }

        Console.WriteLine(allSequences / repeatedSequences);
    }

    private static BigInteger CalculateFactorial(int number)
    {
        BigInteger factorial = 1;
        for (int i = 2; i <= number; i++)
        {
            factorial *= i;
        }

        return factorial;
    }
}
