using System;
class SequencesInAMatrix
{
    static int rows = 0;
    static int cols = 0;
    static int bestLength = 0;

    static void Main()
    {
        Console.WriteLine("This program will find the longest subsequence in a matrix of strings.");
        // Read the input
        string[,] matrix = ReadInput();

        // Find the longest subsequence in the matrix
        // Check horizontal sequences (rowStep = 0, colStep = 1)
        for (int i = 0; i < rows; i++)
        {
            CheckCurrentSequence(matrix, i, 0, 0, 1);
        }
        // Check vertical sequences (rowStep = 1, colStep = 0)
        for (int i = 0; i < cols; i++)
        {
            CheckCurrentSequence(matrix, 0, i, 1, 0);
        }

        CheckPrimaryDiagonals(matrix);

        CheckSecondaryDiagonals(matrix);

        // Print the sequence
        Console.WriteLine("The longest sequence is {0} elements.", bestLength);   
    }
  
    static string[,] ReadInput()
    {
        // Read the input
        while (rows <= 0)
        {
            Console.Write("The matrix will be N x M. Enter N: ");
            rows = int.Parse(Console.ReadLine());
        }
        while (cols <= 0)
        {
            Console.Write("Now enter M: ");
            cols = int.Parse(Console.ReadLine());
        }
        // Initialize and fill the matrix
        string[,] matrix = new string[rows, cols];
        Console.WriteLine("Enter the elements of the matrix one by one.");
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("Row {0}, col {1}: ", row + 1, col + 1);
                matrix[row, col] = Console.ReadLine();
            }
        }
        return matrix;
    }
  
    static void CheckPrimaryDiagonals(string[,] matrix)
    {
        // Check primary diagonals (rowStep = 1, colStep = 1)
        // We need two loops to try all possibilities
        // The first loop starts at (i, 0) and the second starts at (0, i) 
        for (int i = rows - 1; i >= 0; i--)
        {
            CheckCurrentSequence(matrix, i, 0, 1, 1);
        }
        for (int i = 0; i < cols; i++)
        {
            CheckCurrentSequence(matrix, 0, i, 1, 1);
        }
    }
  
    static void CheckSecondaryDiagonals(string[,] matrix)
    {
        // Check secondary diagonals (rowStep = -1, colStep = 1)
        // We need two loops to try all possibilities
        // The first loop starts at (i, 0) and the second starts at (m - 1, i)
        for (int i = 0; i < rows; i++)
        {
            CheckCurrentSequence(matrix, i, 0, -1, 1);
        }
        for (int i = 0; i < cols; i++)
        {
            CheckCurrentSequence(matrix, rows - 1, i, -1, 1);
        }
    }

    static void CheckCurrentSequence(string[,] matrix, int currentRow, int currentCol, int rowsStep, int colsStep)
    {
        int currentLength = 1;
        string key = matrix[currentRow, currentCol];
        // The loop ends after the program goes outside the matrix
        while (true)
        {
            // Change the current cell
            currentRow += rowsStep;
            currentCol += colsStep;
            if ((currentRow < 0) ||
                (currentRow >= rows) ||
                currentCol < 0 ||
                currentCol >= cols)
            {
                break;
            }

            // If the key is equal to the key, continue the sequence. Else, start a new sequence
            if (matrix[currentRow, currentCol] == key)
            {
                currentLength++;
                }
            else
            {
                if (currentLength > bestLength)
                {
                    bestLength = currentLength;
                }
                currentLength = 1;
            }
        }

        // If the sequence is longer than the longest found up to now, update the length of the longest sequence
        if (currentLength > bestLength)
        {
            bestLength = currentLength;
        }
    }
}