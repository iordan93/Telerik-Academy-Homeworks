using System;

    class ExchangeValues
    {
        static void Main()
        {
            int firstValue = 5;
            int secondValue = 10;
            Console.WriteLine("Before exchanging:");
            Console.WriteLine("First value: " + firstValue);
            Console.WriteLine("Second value: " + secondValue);
            int tempValue = secondValue;
            secondValue = firstValue;
            firstValue = tempValue;
            Console.WriteLine("After exchanging:");
            Console.WriteLine("First value: " + firstValue);
            Console.WriteLine("Second value: " + secondValue);
        }
    }
