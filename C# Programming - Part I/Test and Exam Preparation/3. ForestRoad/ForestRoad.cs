using System;
using System.Threading;
using System.Globalization;
class ForestRoad
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        char star = '*';
        char dot = '.';
        for (int col = 1; col <= n; col++)
        {
            string dotsBefore = new string(dot, col - 1);
            string dotsAfter = new string(dot, n - col);
            Console.WriteLine("{0}{1}{2}", dotsBefore, star, dotsAfter);
        }

        for (int col = 2; col <= n; col++)
        {
            string dotsAfter = new string(dot, col - 1);
            string dotsBefore = new string(dot, n - col);
            Console.WriteLine("{0}{1}{2}", dotsBefore, star, dotsAfter);
        }

    }
}