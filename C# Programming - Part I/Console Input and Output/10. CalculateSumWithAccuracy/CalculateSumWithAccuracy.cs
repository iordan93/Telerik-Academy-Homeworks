using System;

    class Program
    {
        static void Main()
        {
            double sum = 0;
            for (int i = 1; i <= 1000; i++)
            {
                double sign = Math.Pow(-1, i-1);
                double number = (1 / (double)i) * sign;
                sum += number;
            }
            Console.WriteLine("The sum is: {0:0.###}", sum);
        }
    }
