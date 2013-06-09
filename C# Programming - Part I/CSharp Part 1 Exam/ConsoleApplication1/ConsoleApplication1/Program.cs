using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Globalization;

namespace BitBall
{
    class BitBall
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            //Create matrix
            int[,] matrixTop = new int[8, 8];
            for (int row = 0; row <= 7; row++)
            {
                byte bits = byte.Parse(Console.ReadLine());
                for (int col = 0; col <= 7; col++)
                {
                    matrixTop[row, col] = (bits >> (7 - col)) & 1;
                }
            }
            int[,] matrixBottom = new int[8, 8];
            for (int row = 0; row <= 7; row++)
            {
                byte bits = byte.Parse(Console.ReadLine());
                for (int col = 0; col <= 7; col++)
                {
                    matrixBottom[row, col] = (bits >> (7 - col)) & 1;
                }
            }
            int[,] matrixFinal = new int[8, 8];
            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 7; col++)
                {
                    if ((matrixTop[row, col] == 1) && (matrixBottom[row, col] == 0))
                    {
                        matrixFinal[row, col] = 1;
                    }
                    if ((matrixTop[row, col] == 0) && (matrixBottom[row, col] == 1))
                    {
                        matrixFinal[row, col] = -1;
                    }
                }
            }

            int counterTop = 0;
            int counterBottom = 0;

            for (int col = 7; col >= 0; col--)
            {
                for (int row = 0; row <= 7; row++)
                {
                    if (matrixFinal[row,col] != 0)
                    {
                        if (matrixFinal[row,col] == -1)
                        {
                            counterBottom++;
                        }
                        break;
                    }
                }
            }
            for (int col = 7; col >= 0; col--)
            {
                for (int row = 7; row >= 0; row--)
                {
                    if (matrixFinal[row, col] != 0)
                    {
                        if (matrixFinal[row, col] == 1)
                        {
                            counterTop++;
                        }
                        break;
                    }
                }
            }
            //for (int row = 0; row <= 7; row++)
            //{
            //    for (int col = 0; col <= 7; col++)
            //    {
            //        Console.Write("{0,3}", matrixFinal[row, 7 - col]);
            //    }
            //    Console.WriteLine();
            //}
            Console.WriteLine("{0}:{1}", counterTop, counterBottom);
        }
    }
}