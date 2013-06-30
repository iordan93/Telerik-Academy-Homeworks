using System;
using System.IO;

public class MinimumEditDistance
{
    private const double ReplaceCost = 1;

    private const double DeleteCost = 0.9;

    private const double InsertCost = 0.8;

    public static void Main()
    {
        StreamReader input = new StreamReader("../../input.txt");
        Console.SetIn(input);
        string initialWord = Console.ReadLine();
        string finalWord = Console.ReadLine();

        double result = Compute(initialWord, finalWord);
        Console.WriteLine("The minimum edit distance between {0} and {1} is {2}.", initialWord, finalWord, result);
    }

    public static double Compute(string initialWord, string finalWord)
    {
        double[,] distancesTable = new double[initialWord.Length + 1, finalWord.Length + 1];

        // The basic case has 0 characters.
        // Fill all deletions vertically and all insertions horizontally
        for (int i = 0; i <= initialWord.Length; i++)
        {
            distancesTable[i, 0] = i * DeleteCost;
        }

        for (int j = 0; j <= finalWord.Length; j++)
        {
            distancesTable[0, j] = j * InsertCost;
        }

        for (int i = 1; i <= initialWord.Length; i++)
        {
            for (int j = 1; j <= finalWord.Length; j++)
            {
                // Check if the character needs replacing
                double cost = finalWord[j - 1] == initialWord[i - 1] ? 0 : ReplaceCost;

                // Get the minimum distance of all three - deletion, insertion and replacement
                distancesTable[i, j] = Math.Min(
                    Math.Min(distancesTable[i - 1, j] + DeleteCost, distancesTable[i, j - 1] + InsertCost),
                    distancesTable[i - 1, j - 1] + cost);
            }
        }

        return distancesTable[initialWord.Length, finalWord.Length];
    }
}