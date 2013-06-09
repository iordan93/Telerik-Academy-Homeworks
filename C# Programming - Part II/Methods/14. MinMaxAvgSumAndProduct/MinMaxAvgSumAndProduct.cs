using System;
class MinMaxAvgSumAndProduct
{
    static decimal[] InitializeArray()
    {
        Console.Write("Enter the length of the sequence: ");
        int n = int.Parse(Console.ReadLine());
        decimal[] array = new decimal[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("{0}: ", i);
            array[i] = decimal.Parse(Console.ReadLine());
        }
        return array;
    }

    static decimal Min(params decimal[] array)
    {
        decimal min = decimal.MaxValue;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }
        }
        return min;
    }

    static decimal Max(params decimal[] array)
    {
        decimal max = decimal.MinValue;
        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] > max)
            {
                max = array[i];
            }
        }
        return max;
    }

    static decimal Average(params decimal[] array)
    {
        decimal sum = 0;
        decimal average = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        average = sum / array.Length;
        return average;
    }

    static decimal Sum(params decimal[] array)
    {
        decimal sum = 0;
        for (int i = 0; i < array.Length; i++)
        {
            sum += array[i];
        }
        return sum;
    }

    static decimal Product(params decimal[] array)
    {
        decimal product = 1;
        for (int i = 0; i < array.Length; i++)
        {
            product *= array[i];
        }
        return product;
    }

    static void Main()
    {
        Console.WriteLine("This program will find the minimum, maximum, average, sum and product of the members in a sequence.");
        
        decimal[] array = InitializeArray();
        
        Console.WriteLine("Minimum: {0}", Min(array));
        Console.WriteLine("Maximum: {0}", Max(array));
        Console.WriteLine("Average: {0}", Average(array));
        Console.WriteLine("Sum: {0}", Sum(array));
        Console.WriteLine("Product: {0}", Product(array));
    }
}
