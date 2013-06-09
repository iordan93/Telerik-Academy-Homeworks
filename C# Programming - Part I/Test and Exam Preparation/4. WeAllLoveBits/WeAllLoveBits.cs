using System;
using System.Threading;
using System.Globalization;
    class WeAllLoveBits
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                int result = 0;
                while (number != 0)
                {
                    int lastBit = number & 1;
                    result = result << 1;
                    result = result | lastBit;
                    number = number >> 1;
                }
                Console.WriteLine(result);
            }
        }
    }
