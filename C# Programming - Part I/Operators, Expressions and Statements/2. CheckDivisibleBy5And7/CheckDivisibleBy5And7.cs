using System;

    class CheckDivisibleBy5And7
    {
        static void Main()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int divideByFive = number % 5;
            int divideBySeven = number % 7;
            bool divisibleByFive = divideByFive == 0;
            bool divisibleBySeven = divideBySeven == 0;
            if (divisibleByFive&&divisibleBySeven==true)
            {
                Console.WriteLine("The number is divisible by 5 and 7.");
            }
            else
            {
                Console.WriteLine("The number is not divisible by 5 and 7.");
            }
        }
    }