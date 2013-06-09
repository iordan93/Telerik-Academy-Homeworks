using System;
using System.Threading;
using System.Globalization;
class Pillars
{
    static void Main()
    {
        int[,] matrix = new int[8, 8];
        for (int row = 0; row <= 7; row++)
        {
            byte bits = byte.Parse(Console.ReadLine());
            for (int col = 0; col <= 7; col++)
            {
                matrix[row, col] = (bits >> (7-col)) & 1;

            }
        }

        //Check each column of the matrix, from 7 to 0
        for (int column = 0; column <= 7; column++)
        {
            int left = 0;
            int right = 0;
            for (int row = 0; row <= 7; row++)
            {
                for (int col = 7; col >= 0; col--)
                {
                    if (col > column)
                    {
                        left += matrix[row, col];
                    }
                    if (col < column)
                    {
                        right += matrix[row, col];
                    }
                }
            }

            //If the sums are equal, the problem is solved
            if (left == right)
            {
                Console.WriteLine(7-column);
                Console.WriteLine(left);
                return;
            }
        }

        //If there's no solution, write "No"
        Console.WriteLine("No");
    }
}
