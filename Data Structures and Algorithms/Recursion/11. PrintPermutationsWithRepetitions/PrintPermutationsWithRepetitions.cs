using System;

public class PrintPermutationsWithRepetitions
{
    public static void Main()
    {
        int[] numbers = new int[] 
        {
            1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 
        };
        
        GetPermutationsWithRepetitions(numbers);
    }

    private static void GetPermutationsWithRepetitions(int[] numbersSet)
    {
        Array.Sort(numbersSet);
        GetPermutations(numbersSet, 0, numbersSet.Length);
    }

    private static void GetPermutations(int[] numbersSet, int start, int end)
    {
        PrintNumbers(numbersSet);

        int valueToSwap = 0;

        if (start < end)
        {
            for (int i = end - 2; i >= start; i--)
            {
                for (int j = i + 1; j < end; j++)
                {
                    if (numbersSet[i] != numbersSet[j])
                    {
                        valueToSwap = numbersSet[i];
                        numbersSet[i] = numbersSet[j];
                        numbersSet[j] = valueToSwap;

                        GetPermutations(numbersSet, i + 1, end);
                    }
                }

                valueToSwap = numbersSet[i];
                for (int k = i; k < end - 1;)
                {
                    numbersSet[k] = numbersSet[++k];
                }

                numbersSet[end - 1] = valueToSwap;
            }
        }
    }

    private static void PrintNumbers(int[] numbers)
    {
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write("{0} ", numbers[i]);
        }

        Console.WriteLine();
    }
}