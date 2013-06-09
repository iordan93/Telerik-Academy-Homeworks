using System;
using System.Threading;
using System.Globalization;

class ArrayOfBits8x8
{
    static void Main(string[] args)
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        //Create matrix
        int[,] matrix = new int[8, 8];
        for (int row = 0; row <= 7; row++)
        {
            byte bits = byte.Parse(Console.ReadLine());
            for (int col = 0; col <= 7; col++)
           //for (int col = 7; col >= 0; col--) //Reversed matrix
            {
                matrix[row, col] = (bits >> (7-col)) & 1;
            }
        }

        //Print matrix to the console
        for (int row = 0; row <= 7; row++)
        {
            for (int col = 0; col <= 7; col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }

        //Transpose matrix
        int[,] newMatrix=new int[8,8];
        for (int row = 0; row <= 7; row++)
        {
            for (int col = 0; col <= 7; col++)
            {
                newMatrix[col, row] = matrix[row, col];
            }
        }
    }
}