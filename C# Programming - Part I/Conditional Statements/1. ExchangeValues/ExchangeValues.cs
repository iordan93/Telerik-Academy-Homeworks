using System;
    class ExchangeValues
    {

        static void Main()
        {
            Console.Write("Enter first number: ");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            double secondNumber = double.Parse(Console.ReadLine());
            if (firstNumber>secondNumber)
            {
                double temp = secondNumber;
                secondNumber = firstNumber;
                firstNumber = temp;
            }
            Console.WriteLine("The first number is {0}\r\nand the second number is {1}", firstNumber, secondNumber);
        }
    }