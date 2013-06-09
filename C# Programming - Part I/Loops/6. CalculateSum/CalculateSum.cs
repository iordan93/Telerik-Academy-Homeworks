using System;
class CalculateSum
{
    static void Main()
    {
        Console.Write("Enter N: ");
        ulong n = ulong.Parse(Console.ReadLine());
        Console.Write("Enter X: ");
        ulong x = ulong.Parse(Console.ReadLine());
        double sum = 1;
        ulong nFactorial = 1;
        double xToTheN = 1;

        //Calculate N factorial and X^N
        for (ulong i = 1; i <= n; i++)
        {
            nFactorial *= i;
            xToTheN = Math.Pow(x, i);
            sum = sum + nFactorial / xToTheN;
        }
        Console.WriteLine(sum);
    }
}