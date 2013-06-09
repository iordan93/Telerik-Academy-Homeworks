using System;
using System.Threading;
using System.Globalization;
class MathExpression
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        decimal n = decimal.Parse(Console.ReadLine());
        decimal m = decimal.Parse(Console.ReadLine());
        decimal p = decimal.Parse(Console.ReadLine());

        decimal numerator = (n * n) + (1 / (m * p)) + 1337;
        decimal denominator = n - (128.523123123m * p);
        int sinArgument = ((int)m) % 180;
        decimal sine = (decimal)(Math.Sin(sinArgument));

        decimal result = numerator / denominator + sine;
        Console.WriteLine("{0:0.000000}", result);
    }
}