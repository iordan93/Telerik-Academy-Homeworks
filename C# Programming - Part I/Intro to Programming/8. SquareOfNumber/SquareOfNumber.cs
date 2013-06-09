using System;

class SquareOfNumber
{
    static void Main()
    {
        double number = Double.Parse(Console.ReadLine());
        double result = Math.Pow(number, 2);
        Console.WriteLine("{0} to the power of 2 is {1}", number, result);
    }
}