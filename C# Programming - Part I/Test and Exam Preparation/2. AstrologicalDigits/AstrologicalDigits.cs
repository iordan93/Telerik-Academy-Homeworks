using System;
using System.Threading;
using System.Globalization;
class AstrologicalDigits
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        ulong sum = 0;
        while (true)
        {
            int n = Console.Read();

            if (n == (int)'\r' || n == (int)'\n' || n == -1)
            {
                break;
            }
            
            if (n >= '0' && n <= '9')
            {
                ulong number = (ulong)n - (ulong)'0';
                sum += number;
            }
        }

        while (sum > 9)
        {
            ulong newSum = 0;
            while (sum > 0)
            {
                ulong last = sum % 10;
                newSum += last;
                sum /= 10;
            }
            sum = newSum;
        }
        Console.WriteLine(sum);
    }
}