using System;
using System.Numerics;
class FibonacciNumbers
{
    static void Main()
    {
        BigInteger firstNumber = 0;
        BigInteger secondNumber = 1;
        BigInteger fibonacci;
        for (int i = 1; i <= 100; i++)
        {
            fibonacci = firstNumber + secondNumber;
            firstNumber = secondNumber;
            secondNumber = fibonacci;
            Console.WriteLine(fibonacci);
        }
    }
}
