using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;

class MissCat
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int x1 = 0;
        int x2 = 0;
        int x3 = 0;
        int x4 = 0;
        int x5 = 0;
        int x6 = 0;
        int x7 = 0;
        int x8 = 0;
        int x9 = 0;
        int x10 = 0;
        int max = 0;
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            int vote = int.Parse(Console.ReadLine());
            switch (vote)
            {
                case 1: x1++; break;
                case 2: x2++; break;
                case 3: x3++; break;
                case 4: x4++; break;
                case 5: x5++; break;
                case 6: x6++; break;
                case 7: x7++; break;
                case 8: x8++; break;
                case 9: x9++; break;
                case 10: x10++; break;
            }
        }
        if (x1 >= x2 && x1 >= x3 && x1 >= x4 && x1 >= x5 && x1 >= x6 && x1 >= x7 && x1 >= x8 && x1 >= x9 && x1 >= x10) max = 1;
        else if (x2 >= x1 && x2 >= x3 && x2 >= x4 && x2 >= x5 && x2 >= x6 && x2 >= x7 && x2 >= x8 && x2 >= x9 && x2 >= x10) max = 2;
        else if (x3 >= x1 && x3 >= x2 && x3 >= x4 && x3 >= x5 && x3 >= x6 && x3 >= x7 && x3 >= x8 && x3 >= x9 && x3 >= x10) max = 3;
        else if (x4 >= x1 && x4 >= x2 && x4 >= x3 && x4 >= x5 && x4 >= x6 && x4 >= x7 && x4 >= x8 && x4 >= x9 && x4 >= x10) max = 4;
        else if (x5 >= x1 && x5 >= x2 && x5 >= x3 && x5 >= x4 && x5 >= x6 && x5 >= x7 && x5 >= x8 && x5 >= x9 && x5 >= x10) max = 5;
        else if (x6 >= x1 && x6 >= x2 && x6 >= x3 && x6 >= x4 && x6 >= x5 && x6 >= x7 && x6 >= x8 && x6 >= x9 && x6 >= x10) max = 6;
        else if (x7 >= x1 && x7 >= x2 && x7 >= x3 && x7 >= x4 && x7 >= x5 && x7 >= x6 && x7 >= x8 && x7 >= x9 && x7 >= x10) max = 7;
        else if (x8 >= x1 && x8 >= x2 && x8 >= x3 && x8 >= x4 && x8 >= x5 && x8 >= x6 && x8 >= x7 && x8 >= x9 && x8 >= x10) max = 8;
        else if (x9 >= x1 && x9 >= x2 && x9 >= x3 && x9 >= x4 && x9 >= x5 && x9 >= x6 && x9 >= x7 && x9 >= x8 && x9 >= x10) max = 9;
        else if (x10 >= x1 && x10 >= x2 && x10 >= x3 && x10 >= x4 && x10 >= x5 && x10 >= x6 && x10 >= x7 && x10 >= x8 && x10 >= x9) max = 10;
        Console.WriteLine(max);
    }
}