using System;
using System.Threading;
using System.Globalization;
class BitwiseTricks
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

        ////Get bit b at position p in number n
        //int n = 6819; //number
        //int p = 5; //position
        //int mask = 1 << p;
        //int nAndMask = n & mask;
        //int b = nAndMask >> p;
        //Console.WriteLine(b); //return bit - 0 or 1

        ////Set bit at position p in number n to 0
        //int n = 6819; //number
        //int p = 5; //position
        //int mask = 1 << p;
        //n = n & (~mask);
        //Console.WriteLine(n); //return new number

        ////Set bit at position p in number n to 1
        //int n = 6819; //number
        //int p = 4; //position
        //int mask = 1 << p;
        //n = n | mask;
        //Console.WriteLine(n); //return new number

        ////Print number in binary format to the console
        //int number = 100;
        //Console.WriteLine(Convert.ToString(number, 2)); //Usual representation
        ////Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0')); //32-bit representation
    }                                                                                                                                                                                   
}