using System;

class CheckSubsetSum
{
    static void Main()
    {
        Console.WriteLine("Enter five numbers: ");
        int a = int.Parse(Console.ReadLine());
        int b = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int e = int.Parse(Console.ReadLine());
        bool subsetSumIsZero = false;
        if ((a + b == 0) ||
            (a + c == 0) ||
            (a + d == 0) ||
            (a + e == 0) ||
            (b + c == 0) ||
            (b + d == 0) ||
            (b + e == 0) ||
            (c + d == 0) ||
            (c + e == 0) ||
            (d + e == 0) ||
            (a + b + c == 0) ||
            (a + b + d == 0) ||
            (a + b + e == 0) ||
            (a + c + d == 0) ||
            (a + c + e == 0) ||
            (a + d + e == 0) ||
            (b + c + d == 0) ||
            (b + c + e == 0) ||
            (b + d + e == 0) ||
            (c + d + e == 0) ||
            (a + b + c + d == 0) ||
            (a + b + c + e == 0) ||
            (a + c + d + e == 0) ||
            (b + c + d + e == 0) ||
            (a + b + c + d + e == 0))
        {
            subsetSumIsZero = true;
        }
        if (subsetSumIsZero)
        {
            Console.WriteLine("There's a subset that sums up to zero.");
        }
        else
        {
            Console.WriteLine("No subset sums up to zero.");
        }
    }

}
