using System;
using System.Threading;
using System.Globalization;
class Trapezoid
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        string firstRowDots = new string('.', n);
        string firstRowStars = new string('*', n);
        string lastRowStars = new string('*', 2*n);
        Console.WriteLine("{0}{1}", firstRowDots, firstRowStars);
        for (int row = 2; row <= n; row++)
        {
            for (int col = 1; col <= 2 * n - 1; col++)
            {
                int starSeq = n - row + 2;
                if (col == starSeq)
                {
                    Console.Write("*");
                }
                else
                {
                    Console.Write(".");
                }

            }
            Console.WriteLine("*");
        }
        Console.WriteLine("{0}", lastRowStars);
    }
}
