using System;
using System.Threading;
using System.Globalization;

class ExchangeConsequentBits
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        //Exchange group of bits p, ..., p + k - 1 --> q, ..., q + k - 1 in number n
        int n = 55027;
        //This will replace the 7th, 8th and 9th bit with the values of the 4th, 5th and 6th (zero-based)
        int p = 4;
        int q = 7;
        int k = 3;

        //Get bits p, ..., p + k
        int b = 0;
        int[] bitsArray = new int[k];
        for (int bit = p; bit < p + k; bit++)
        {
            int mask = 1 << bit;
            int nAndMask = n & mask;
            b = nAndMask >> bit;
            bitsArray[bit - p] = b; //Array to hold all bits
        }
        for (int bit = q; bit < q + k; bit++)
        {
            for (int i = 0; i < k; i++)
            {
                //if number is 1, set the bit at 1
                if (bitsArray[i] != 0)
                {
                    int mask = 1 << bit;
                    n = n | mask;
                }
                //if number is 0, set the bit at 0
                else if (bitsArray[i] == 0)
                {
                    int mask = 1 << bit;
                    n = n & (~mask);
                }
            }
        }
        Console.WriteLine(n);
    }
}