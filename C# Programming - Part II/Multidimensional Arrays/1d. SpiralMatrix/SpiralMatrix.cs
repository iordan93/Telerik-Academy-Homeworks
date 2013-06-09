using System;
class MatrixColumns
{
    static void Main()
    {
        Console.WriteLine("This program will print a square matrix of a given size and fill it with numbers spirally.");

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
        int row = 0;
        int column = 0;
        int maxRow = length - 1;
        int maxColumn = length - 1;
        do
        {
            // Direction: up -> right -> down -> left
            // The next four sections can be rearranged to specify a different direction
            // Move up
            for (int i = maxRow; i >= row; i--)
            {
                matrix[i, column] = currentNumber;
                currentNumber++;
            }
            column++;
           
            // Move right
            for (int i = column; i <= maxColumn; i++)
            {
                matrix[row, i] = currentNumber;
                currentNumber++;
            }
            row++;

            // Move down
            for (int i = row; i <= maxRow; i++)
            {
                matrix[i, maxColumn] = currentNumber;
                currentNumber++;
            }
            maxColumn--;

            // Move left
            for (int i = maxColumn; i >= column; i--)
            {
                matrix[maxRow, i] = currentNumber;
                currentNumber++;
            }
            maxRow--;
            
        } while (currentNumber <= length * length);

        // Print the matrix
        for (int rows = 0; rows < length; rows++)
        {
            for (int cols = 0; cols < length; cols++)
            {
                Console.Write("{0, 4}", matrix[rows, cols]);
            }
            Console.WriteLine();
        }
    }
}