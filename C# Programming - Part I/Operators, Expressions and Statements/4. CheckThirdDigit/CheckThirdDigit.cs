using System;

class CheckThirdDigit
    {
        static void Main()
        {
            Console.WriteLine("Enter a number: ");
            int number = int.Parse(Console.ReadLine());
            int divideBy1000 = number % 1000;
            if (divideBy1000>=700 && divideBy1000<=799)
            {
                Console.WriteLine("The third digit from right to left is 7.");
            }
            else
            {
                Console.WriteLine("The third digit from right to left is not 7.");
            }
        }
    }
