using System;

public class NestedLoopsSimulation
{
    public static void Main()
    {
        Console.Write("Enter the number of loops to simulate: ");
        int numberOfLoops = int.Parse(Console.ReadLine());
        int[] currentValue = new int[numberOfLoops];

        GenerateCurrentValue(currentValue, numberOfLoops);
    }

    private static void GenerateCurrentValue(int[] currentValue, int numberOfLoops)
    {
        if (numberOfLoops == 0)
        {
            PrintValue(currentValue);
            return;
        }

        for (int i = 1; i <= currentValue.Length; i++)
        {
            currentValue[currentValue.Length - numberOfLoops] = i;
            GenerateCurrentValue(currentValue, numberOfLoops - 1);
        }
    }

    private static void PrintValue(int[] value)
    {
        Console.WriteLine(string.Join(" ", value));
    }
}