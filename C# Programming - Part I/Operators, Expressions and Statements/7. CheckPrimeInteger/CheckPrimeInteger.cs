﻿using System;

class CheckPrimeInteger
{
    static void Main()
    {
        Console.Write("Enter a number: ");
        int number = int.Parse(Console.ReadLine());
        bool numberIsPrime = true;
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                numberIsPrime = false;
                break;
            }

        }

        if (numberIsPrime == true)
        {
            Console.WriteLine("{0} is prime.", number);
        }
        else
        {
            Console.WriteLine("{0} is not prime.", number);
        }
    }
}