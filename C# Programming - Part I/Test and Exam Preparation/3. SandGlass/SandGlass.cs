using System;
using System.Threading;
using System.Globalization;

class SandGlass
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        char dot = '.';
        char star = '*';
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i <= n; i += 2)
        {
            string dots = new string(dot, i / 2);
            string stars = new string(star, (n - i));
            Console.WriteLine("{0}{1}{2}", dots, stars, dots);
        }
        for (int i = n - 3; i >= 0; i -= 2)
        {
            string dots = new string(dot, i / 2);
            string stars = new string(star, (n - i));
            Console.WriteLine("{0}{1}{2}", dots, stars, dots);
        }
    }
}
