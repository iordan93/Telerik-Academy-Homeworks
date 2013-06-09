using System;

    class NumbersDivisibleByFive
    {
        static void Main()
        {
            Console.Write("Enter first number: ");
            int firstNumber = int.Parse(Console.ReadLine());
            Console.Write("Enter second number: ");
            int secondNumber = int.Parse(Console.ReadLine());
            int remnant = ((secondNumber - firstNumber) / 5);
            if (firstNumber%5==0 || firstNumber%5==5)
            {
                remnant = remnant + 1;
            }
            else if (secondNumber%5==0 || secondNumber%5==5)
            {
                remnant = remnant + 1;
            }
            Console.WriteLine(remnant);
        }
    }
