using System;

public class PrintCombinationsWithoutDuplicates
{
    public static void Main()
    {
        int k = 0;
        int n = 0;

        try
        {
            ReadInput(out k, out n);
        }
        catch (ArgumentException ex)
        {
            if (ex.ParamName == "n")
            {
                Console.WriteLine("The number n is invalid. It should be positive. Please try again.");
            }
            else if (ex.ParamName == "k")
            {
                Console.WriteLine("The number k is invalid. It should be positive and less than n. Please try again.");
            }

            return;
        }

        int[] combinations = new int[k];
        GetCombinations(combinations, 0, 1, n);
    }

    private static void ReadInput(out int k, out int n)
    {
        Console.Write("Enter the number of elements to choose from (n): ");
        n = int.Parse(Console.ReadLine());
        if (n <= 0)
        {
            throw new ArgumentException("The number n must be positive.", "n");
        }

        Console.Write("Enter the number of elements to choose (k, k <= n): ");
        k = int.Parse(Console.ReadLine());

        if (k <= 0 || n < k)
        {
            throw new ArgumentException("The number k must be less than or equal to n.", "k");
        }
    }

    private static void GetCombinations(int[] currentCombination, int start, int current, int length)
    {
        if (start == currentCombination.Length)
        {
            PrintValue(currentCombination);
        }
        else
        {
            for (int i = current; i <= length; i++)
            {
                currentCombination[start] = i;

                GetCombinations(currentCombination, start + 1, i + 1, length);
            }
        }
    }

    private static void PrintValue(int[] value)
    {
        Console.WriteLine(string.Join(" ", value));
    }
}