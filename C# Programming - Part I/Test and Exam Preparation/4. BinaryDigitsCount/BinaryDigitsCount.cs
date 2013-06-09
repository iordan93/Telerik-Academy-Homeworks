using System;
using System.Threading;
using System.Globalization;

class BinaryDigitsCount
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        byte b = byte.Parse(Console.ReadLine()); //Bit to look for - 0 or 1
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            uint number = uint.Parse(Console.ReadLine()); //Number to check
            ushort counter = 0;
            //Check the number bit by bit (by last position)
            while (number != 0)
            {
                if ((number & 1) == b)
                {
                    counter++;
                }
                number = number >> 1;
            }
            Console.WriteLine(counter);
        }
    }
}