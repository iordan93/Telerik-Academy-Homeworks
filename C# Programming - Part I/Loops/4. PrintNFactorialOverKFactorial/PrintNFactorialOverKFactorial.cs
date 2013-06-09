using System;
class PrintNFactorialOverKFactorial
{
    static void Main()
    {
        Console.Write("Enter N: ");
        ulong n = ulong.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        ulong k = ulong.Parse(Console.ReadLine());
        ulong nFactorial = 1;
        ulong kFactorial = 1;
        if ((k > n) || (k < 1))
        {
            Console.WriteLine("K must be greater than 1 and smaller than N.");
            return;
        }
        for (ulong i = 1; i <= n; i++)
        {
            nFactorial *= i;
        }
        for (ulong i = 1; i <= k; i++)
        {
            kFactorial *= i;
        }
        ulong result = nFactorial / kFactorial;
        Console.WriteLine("N! / K! = {0}", result);
    }
}