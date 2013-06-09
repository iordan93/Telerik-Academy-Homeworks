using System;
using System.Threading;
using System.Globalization;

    class OddNumber
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            long n = long.Parse(Console.ReadLine());
            long result = 0;
            for (int i = 1; i <= n; i++)
            {
                long number = long.Parse(Console.ReadLine());
                result ^= number;
            }
            Console.WriteLine(result);
        }
    }