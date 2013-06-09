using System;

    class CheckOddOrEven
    {
        static void Main()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int divByTwo = number % 2;
            if (divByTwo == 0)
            {
                Console.WriteLine("The number you entered is even.");
            }
            else
            {
                Console.WriteLine("The number you entered is odd.");
            }
        }

    }
