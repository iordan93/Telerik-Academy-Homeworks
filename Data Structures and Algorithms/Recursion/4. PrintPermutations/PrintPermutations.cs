using System;

public class PrintPermutations
{
    public static void Main()
    {
        Console.Write("Enter the number of elements (n): ");
        int n = int.Parse(Console.ReadLine());

        int[] permutations = InitializePermutationsSequence(n);

        GetPermutations(permutations, 0);
    }

    private static int[] InitializePermutationsSequence(int n)
    {
        int[] permutations = new int[n];

        for (int i = 0; i < n; i++)
        {
            permutations[i] = i + 1;
        }

        return permutations;
    }

    private static void GetPermutations(int[] currentPermutation, int start)
    {
        if (start == currentPermutation.Length - 1)
        {
            PrintValue(currentPermutation);
        }
        else
        {
            for (int i = start; i <= currentPermutation.Length - 1; i++)
            {
                Swap(currentPermutation, i, start);
                GetPermutations(currentPermutation, start + 1);
                Swap(currentPermutation, start, i);
            }
        }
    }

    private static void PrintValue(int[] value)
    {
        Console.WriteLine(string.Join(" ", value));
    }

    private static void Swap(int[] array, int firstIndex, int secondIndex)
    {
        int temporaryStorage = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = temporaryStorage;
    }
}