using System;

public class PrintAllOrderedSubsets
{
    public static void Main()
    {
        string[] input;
        int k;
        ReadInput(out input, out k);

        string[] currentVariation = new string[k];

        GetVariations(0, input.Length, currentVariation, input);
    }

    private static void ReadInput(out string[] input, out int k)
    {
        Console.Write("Enter the elements to choose from, separated by commas: ");
        input = Console.ReadLine().Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);

        Console.Write("Enter the number of elements to choose (k): ");
        k = int.Parse(Console.ReadLine());
    }

    private static void GetVariations(int index, int n, string[] currentVariation, string[] input)
    {
        if (index == currentVariation.Length)
        {
            PrintValue(currentVariation);
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                currentVariation[index] = input[i];
                GetVariations(index + 1, n, currentVariation, input);
            }
        }
    }

    private static void PrintValue(string[] value)
    {
        Console.WriteLine(string.Join(" ", value));
    }
}