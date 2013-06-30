using System;
using System.Collections.Generic;

public class PrintAllSubsets
{
    public static void Main()
    {
        string[] input;
        int k;
        ReadInput(out input, out k);

        string[] currentCombination = new string[k];

        GetCombinations(0, input.Length, currentCombination, input);
    }

    private static void ReadInput(out string[] input, out int k)
    {
        Console.Write("Enter the elements to choose from, separated by commas: ");
        input = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

        Console.Write("Enter the number of elements to choose (k): ");
        k = int.Parse(Console.ReadLine());
    }

    private static void GetCombinations(int index, int n, string[] currentCombination, string[] input)
    {
        int start;
        if (index == currentCombination.Length)
        {
            PrintValue(currentCombination);
        }
        else
        {
            if (index == 0)
            {
                start = 0;
            }
            else
            {
                string current = currentCombination[index - 1];
                start = Array.IndexOf(input, current) + 1;
            }

            for (int i = start; i < n; i++)
            {
                currentCombination[index] = input[i];
                GetCombinations(index + 1, n, currentCombination, input);
            }
        }
    }

    private static void PrintValue(string[] value)
    {
        Console.WriteLine(string.Join(" ", value));
    }
}