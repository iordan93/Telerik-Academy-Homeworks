using System;
class Program
{
    static void Main()
    {
        int fibonacciFirst = 0;
        int fibonacciSecond = 1;
        int fibonacciCurrent = 0;
        Console.Write("Enter how many Fibonacci numbers you would like to print: ");
        int n = int.Parse(Console.ReadLine());
        //Print the first two members, 0 and 1
        Console.WriteLine("0\r\n1");
        //Print the remaining members
        for (int i = 1; i <= n-2; i++)
        {
            fibonacciCurrent = fibonacciFirst + fibonacciSecond;
            fibonacciFirst = fibonacciSecond;
            fibonacciSecond = fibonacciCurrent;
            Console.WriteLine(fibonacciCurrent);
        }
    }
}

