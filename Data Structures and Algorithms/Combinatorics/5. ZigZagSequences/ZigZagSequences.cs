using System;

public class ZigZagSequences
{
    private static int n;
    private static int k;
    private static bool[] usedElements;
    private static int numberOfSequences;

    public static void Main()
    {
        string line = Console.ReadLine();

        var numbers = line.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
        int n = int.Parse(numbers[0]);
        int k = int.Parse(numbers[1]);

        int output = GetSequences(k, n);

        Console.WriteLine(output);
    }

    private static int GetSequences(int currentK, int currentN)
    {
        // Clear the initial values
        k = currentK;
        n = currentN;
        numberOfSequences = 0;
        usedElements = new bool[n];

        PlaceBiggerElement(0, -1);

        return numberOfSequences;
    }

    private static void PlaceBiggerElement(int lastPlacedElement, int currentElement)
    {
        if (lastPlacedElement == k)
        {
            numberOfSequences++;
            return;
        }

        if (currentElement == n - 1)
        {
            return;
        }

        for (int i = currentElement + 1; i < n; i++)
        {
            if (!usedElements[i])
            {
                usedElements[i] = true;
                PlaceSmallerElement(lastPlacedElement + 1, i);
                usedElements[i] = false;
            }
        }
    }

    private static void PlaceSmallerElement(int lastPlacedElement, int currentElement)
    {
        if (lastPlacedElement == k)
        {
            numberOfSequences++;
            return;
        }

        if (currentElement == 0)
        {
            return;
        }

        for (int i = 0; i < currentElement; i++)
        {
            if (!usedElements[i])
            {
                usedElements[i] = true;
                PlaceBiggerElement(lastPlacedElement + 1, i);
                usedElements[i] = false;
            }
        }
    }
}