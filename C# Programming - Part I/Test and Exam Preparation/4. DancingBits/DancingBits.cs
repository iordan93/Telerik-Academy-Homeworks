using System;
using System.Threading;
using System.Globalization;
using System.Collections.Generic;

class DancingBits
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int k = int.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());
        int dancingBits = 0;
        int length = 0;
        int lastBit = -1;

        for (int i = 1; i <= n; i++)
        {
            int number = int.Parse(Console.ReadLine());
            bool zero = true;
            for (int bit = 31; bit >= 0; bit--)
            {
                int bitValue = (number >> bit) & 1;
                if (bitValue == 1)
                {
                    zero = false;
                }
                if (zero == false)
                {
                    if (lastBit == bitValue)
                    {
                        length++;
                    }
                    else
                    {
                        if (length == k)
                        {
                            dancingBits++;
                        }
                        length = 1;
                    }
                    lastBit = bitValue;
                }
            }
        }
        if (length == k)
        {
            dancingBits++;
        }
        Console.WriteLine(dancingBits);
    }
}