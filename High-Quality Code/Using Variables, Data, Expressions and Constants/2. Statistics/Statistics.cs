using System;

public class Statistics
{
    public static void PrintStatistics(double[] numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException("numbers");
        }

        if (numbers.Length == 0)
        {
            throw new ArgumentException("There are no numbers in the array");
        }

        PrintMaxNumber(numbers);

        PrintMinNumber(numbers);
        
        PrintAverageNumber(numbers);
    }

    private static void PrintMaxNumber(double[] numbers)
    {
        Console.WriteLine("The maximum number is {0}", FindMaxNumber(numbers));
    }

    private static void PrintMinNumber(double[] numbers)
    {
        Console.WriteLine("The minimum number is {0}", FindMinNumber(numbers));
    }

    private static void PrintAverageNumber(double[] numbers)
    {
        Console.WriteLine("The average of the numbers is {0}", FindAverageNumber(numbers));
    }

    private static double FindMaxNumber(double[] numbers)
    {
        double max = double.MinValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] > max)
            {
                max = numbers[i];
            }
        }

        return max;
    }

    private static double FindMinNumber(double[] numbers)
    {
        double min = double.MaxValue;

        for (int i = 0; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min = numbers[i];
            }
        }

        return min;
    }

    private static double FindAverageNumber(double[] numbers)
    {
        double sum = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            sum += numbers[i];
        }

        return sum / numbers.Length;
    }
}