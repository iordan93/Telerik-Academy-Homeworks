using System;
class PrintComplexFactorial
{
    static void Main()
    {
        Console.Write("Enter N: ");
        ulong n = ulong.Parse(Console.ReadLine());
        Console.Write("Enter K (K > N): ");
        ulong k = ulong.Parse(Console.ReadLine());
        ulong nFactorial = 1;
        ulong kFactorial = 1;
        ulong kMinusNFactorial = 1;
        if ((k < n) || (k < 1) || (n < 1))
        {
            Console.WriteLine("You entered a wrong number. Follow this guideline: 1 < N < K");
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
        for (ulong i = 1; i <= k-n; i++)
        {
            kMinusNFactorial *= i;
        }
        ulong result = nFactorial * kFactorial / kMinusNFactorial;
        Console.WriteLine("N! * K! / (K-N)! = {0}", result);
    }
}
