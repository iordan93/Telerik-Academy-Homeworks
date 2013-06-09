using System;

class ExchangeThreeBits
{
    static void Main()
    {
        Console.Write("Enter number n: ");
        long n = long.Parse(Console.ReadLine());
        //Initialize variables and checking statements
        long mask = 1;
        long thirdBit = mask << 3;
        long fourthBit = mask << 4;
        long fifthBit = mask << 5;
        long twentyFourthBit = mask << 24;
        long twentyFifthBit = mask << 25;
        long twentySixthBit = mask << 26;
        long checkThirdBit = n & thirdBit;
        long checkFourthBit = n & fourthBit;
        long checkFifthBit = n & fifthBit;

        //Set values for the given bits - 0 or 1
        if (checkThirdBit != 0)
        {
            thirdBit = 1;
        }
        else
        {
            thirdBit = 0;
        }
        if (checkFourthBit != 0)
        {
            fourthBit = 1;
        }
        else
        {
            fourthBit = 0;
        }
        if (checkFifthBit != 0)
        {
            fifthBit = 1;
        }
        else
        {
            fifthBit = 0;
        }

        //Set the values at the given positions
        if (thirdBit != 0)
        {
            n = n | (1 << 24);
        }
        else
        {
            n = n & (~(1 << 24));
        }
        if (fourthBit != 0)
        {
            n = n | (1 << 25);
        }
        else
        {
            n = n & (~(1 << 25));
        }
        if (fifthBit != 0)
        {
            n = n | (1 << 26);
        }
        else
        {
            n = n & (~(1 << 26));
        }
        Console.WriteLine(n);
    }
}
