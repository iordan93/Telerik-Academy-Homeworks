using System;
using System.Threading;
using System.Globalization;

class FallDown
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[,] matrix = new int[8, 8];
        for (int row = 0; row <= 7; row++)
        {
            byte number = byte.Parse(Console.ReadLine());
            for (int col = 0; col <= 7; col++)
            {
                matrix[row, col] = (number >> (7 - col)) & 1;
            }
        }
    }
}