using System;
using System.Threading;
using System.Globalization;
class Lines
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int[,] matrix = new int[8, 8];
        for (int row = 0; row <= 7; row++)
        {
            byte n = byte.Parse(Console.ReadLine());
            for (int col = 0; col <= 7; col++)
            {
                if ((n & (1 << col)) != 0)
                {
                    matrix[row, col] = 1;
                }
            }
        }
        int maxLength = 0;
        int count = 0;

        for (int row = 0; row <= 7; row++)
        {
            for (int col = 0; col <= 7; col++)
            {
                int length = 0;

                while (col <= 7 && matrix[row, col] == 1)
                {
                    col++;
                    length++;
                }
                if (length == maxLength)
                {
                    count++;
                }
                if (length > maxLength)
                {
                    maxLength = length;
                    count = 1;
                }
            }

        }

        for (int col = 0; col <= 7; col++)
        {
            for (int row = 0; row <= 7; row++)
            {
                int length = 0;

                while (row <= 7 && matrix[row, col] == 1)
                {
                    row++;
                    length++;
                }
                if (length == maxLength)
                {
                    count++;
                }
                if (length > maxLength)
                {
                    maxLength = length;
                    count = 1;
                }
            }
        }
        if (maxLength == 1)
        {
            count /= 2;
        }
        Console.WriteLine(maxLength);
        Console.WriteLine(count);
    }
}
