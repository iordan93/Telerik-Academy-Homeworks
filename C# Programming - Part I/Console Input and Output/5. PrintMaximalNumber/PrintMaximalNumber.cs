using System;

    class PrintMaximalNumber
    {
        static void Main()
        {
            Console.Write("Enter a = ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter b = ");
            int secondNumber = int.Parse(Console.ReadLine());
            int max = Math.Max(firstNumber, secondNumber);
            Console.WriteLine("The greater number is {0}", max);
        }
    }
