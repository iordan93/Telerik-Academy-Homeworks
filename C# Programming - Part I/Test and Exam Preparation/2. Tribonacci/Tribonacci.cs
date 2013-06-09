﻿using System;
using System.Numerics;
using System.Threading;
using System.Globalization;

class Tribonacci
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        BigInteger t1 = BigInteger.Parse(Console.ReadLine());
        BigInteger t2 = BigInteger.Parse(Console.ReadLine());
        BigInteger t3 = BigInteger.Parse(Console.ReadLine());
        int n = int.Parse(Console.ReadLine());

        if (n == 1)
        {
            Console.WriteLine(t1);
        }
        else if (n == 2)
        {
            Console.WriteLine(t2);
        }
        else if (n == 3)
        {
            Console.WriteLine(t3);
        }
        else
        {
            for (int i = 4; i <= n; i++)
            {
                BigInteger number = t1 + t2 + t3;
                t1 = t2;
                t2 = t3;
                t3 = number;
            }
            Console.WriteLine(t3);
        }
    }
}