using System;
class SnakeMatrix
{
    static void Main()
    {
        Console.WriteLine("This program will print a square matrix of a given size and fill it with numbers in columns in a way that resembles a snake.");

        // Read the input
        int length = 0;
        while (length <= 0)
        {
            Console.Write("The printed matrix will be N x N. Enter N: ");
            length = int.Parse(Console.ReadLine());
        }

        // Initialize and fill the matrix
        int[,] matrix = new int[length, length];
        int currentNumber = 1;
        for (int col = 0; col < length; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < length; row++)
                {
                    matrix[row, col] = currentNumber;
                    currentNumber++;
                }
            }
            else
            {
                for (int row = length - 1; row >= 0; row--)
                {
                    matrix[row, col] = currentNumber;
                    currentNumber++;
                }
            }
        }

        // Print the matrix
        for (int row = 0; row < length; row++)
        {
            for (int col = 0; col < length; col++)
            {
                Console.Write("{0, 4}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}