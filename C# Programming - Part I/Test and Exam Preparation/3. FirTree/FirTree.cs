using System;
using System.Threading;
using System.Globalization;

class FirTree
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i < n; i++)
        {
            string stars = new string('*', 2 * i - 1);
            string dots = new string('.', n - i - 1);
            Console.Write("{0}{1}{2}", dots, stars, dots);
            Console.WriteLine();
        }
        string starsBase = new string('*', 1);
        string dotsBase = new string('.', n - 2);
        Console.Write("{0}{1}{2}", dotsBase, starsBase, dotsBase);
        Console.WriteLine();
    }
}