using System;

class Program
{
    static void Main()
    {
        int number;
        int min = int.MaxValue;
        int max = int.MinValue;
        Console.Write("Enter how numbers you would like to enter: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Now enter {0} more numbers: ", n);
        for (int i = 1; i <= n; i++)
        {
            number = int.Parse(Console.ReadLine());
            if (max < number)
            {
                max = number;
            }
            if (min > number)
            {
                min = number;
            }
        }
        Console.WriteLine("Min: {0}\r\nMax: {1}", min, max);
    }
}
