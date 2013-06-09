using System;
using System.Threading;
using System.Globalization;
class SevenlandNumbers
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int k = int.Parse(Console.ReadLine());
        int kPlusOne = k+1;
        if (k < 6)
        {
            Console.WriteLine(k + 1);
        }
        else
        {
            if (kPlusOne % 10 < 7)
            {
                Console.WriteLine(kPlusOne);
            }
            
            if ((kPlusOne % 10 == 7) || ((kPlusOne % 10 == 8)) || ((kPlusOne % 10 == 9)))
            {
                
                if (kPlusOne % 100 >= 60)
                {
                    int a = (k % 1000) / 100;
                    a = a + 1;
                    Console.WriteLine(a*100);
                }
                else
                {
                    Console.WriteLine(kPlusOne + 3);
                }
            }
            if (k==666)
            {
                Console.WriteLine(7000);
            }
            
        }
 
    }
}