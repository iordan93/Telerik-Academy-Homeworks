using System;
using System.Threading;
using System.Globalization;
    class LeastMajorityMultiple
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            for (int number = 4; number <= 100*100*100; number++)
            {
                int count = 0;
                if (number % a == 0)
                {
                    count++;
                }
                if (number % b == 0)
                {
                    count++;
                }
                if (number % c == 0)
                {
                    count++;
                }
                if (number % d == 0)
                {
                    count++;
                }
                if (number % e == 0)
                {
                    count++;
                }
                if (count >= 3)
                {
                    Console.WriteLine(number);
                    break;
                }
            }
        }
    }