using System;
using System.Collections.Generic;
using System.Linq;

public class Divisors
{
    private static int minNumberOfDivisors = int.MaxValue;
    private static List<int> candidates;

    public static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        byte[] digits = new byte[n];

        for (int i = 0; i < n; i++)
        {
            digits[i] = byte.Parse(Console.ReadLine());
        }

        GetPermutations(digits, 0);

        Console.WriteLine(candidates.Min());
    }

    private static void GetPermutations(byte[] digits, int start)
    {
        if (start == digits.Length - 1)
        {
            int number = GetNumber(digits);
            int numberOfDivisors = 0;
            for (int i = 1; i <= number; i++)
            {
                if (number % i == 0)
                {
                    numberOfDivisors++;
                }
            }

            if (numberOfDivisors < minNumberOfDivisors)
            {
                candidates = new List<int>();
                candidates.Add(number);
                minNumberOfDivisors = numberOfDivisors;
            }
            else if (numberOfDivisors == minNumberOfDivisors)
            {
                candidates.Add(number);
            }
        }
        else
        {
            for (int i = start; i <= digits.Length - 1; i++)
            {
                Swap(digits, i, start);
                GetPermutations(digits, start + 1);
                Swap(digits, start, i);
            }
        }
    }

    private static int GetNumber(byte[] value)
    {
        string numberAsString = string.Join(string.Empty, value);
        int number = int.Parse(numberAsString);
        return number;
    }

    private static void Swap(byte[] array, int firstIndex, int secondIndex)
    {
        byte temporaryStorage = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = temporaryStorage;
    }
}