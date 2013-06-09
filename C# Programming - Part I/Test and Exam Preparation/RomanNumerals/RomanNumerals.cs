using System;

class RomanNumerals
{
    static void Main()
    {
        int number = int.Parse(Console.ReadLine());

        //Numerals
        //one = 0
        //four = 01
        //five = 1
        //nine = 02
        //ten = 2
        //forty = 23
        //fifty = 3
        //ninety = 24
        //hundred = 4
        //fourHundred = 45
        //fiveHundred = 5
        //nineHundred = 46
        //thousand = 6
        while (true)
        {
            if (number >= 1000)
            {
                Console.Write("6");
                number -= 1000;
            }
            else if (number >= 900)
            {
                Console.Write("46");
                number -= 900;
            }
            else if (number >= 500)
            {
                Console.Write("5");
                number -= 500;
            }
            else if (number >= 400)
            {
                Console.Write("45");
                number -= 400;
            }
            else if (number >= 100)
            {
                Console.Write("4");
                number -= 100;
            }
            else if (number >= 90)
            {
                Console.Write("24");
                number -= 90;
            }
            else if (number >= 50)
            {
                Console.Write("3");
                number -= 50;
            }
            else if (number >= 40)
            {
                Console.Write("23");
                number -= 40;
            }
            else if (number >= 10)
            {
                Console.Write("2");
                number -= 10;
            }
            else if (number >= 9)
            {
                Console.Write("02");
                number -= 9;
            }
            else if (number >= 5)
            {
                Console.Write("1");
                number -= 5;
            }
            else if (number >= 4)
            {
                Console.Write("01");
                number -= 4;
            }
            else if (number >= 1)
            {
                Console.Write("0");
                number -= 1;
            }
            else if (number == 0)
            {
                Console.WriteLine();
                return;
            }
        }
    }
}