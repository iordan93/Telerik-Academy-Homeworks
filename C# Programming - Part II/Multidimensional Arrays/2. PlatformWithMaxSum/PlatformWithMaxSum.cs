using System;
class PlatformWithMaxSum
{
    static void Main()
    {
        Console.WriteLine("This program will print the 3 x 3 platform with maximum sum in a matrix of integers.");
        // Read the input
        int rows = 0;
        int cols = 0;
        // The algorithm doesn't (and shouldn't) work on matrices smaller than 3 x 3
        while (rows < 3)
        {
            Console.Write("The printed matrix will be N x M. Enter N: ");
            rows = int.Parse(Console.ReadLine());
        }
        while (cols < 3)
        {
            Console.Write("Now enter M: ");
            cols = int.Parse(Console.ReadLine());
        }
        // Initialize and fill the matrix
        int[,] matrix = new int[rows, cols];
        Console.WriteLine("Enter the elements of the matrix one by one.");
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < cols; col++)
            {
                Console.Write("Row {0}, col {1}: ", row + 1, col + 1);
                int currentNumber = int.Parse(Console.ReadLine());
                matrix[row, col] = currentNumber;
            }
        }

        // Find the maximum 3 x 3 platform
        int currentSum = 0;
        int bestSum = int.MinValue;
        int startRow = 0;
        int startCol = 0;
        for (int row = 0; row < rows - 2; row++)
        {
            for (int col = 0; col < cols - 2; col++)
            {
                currentSum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                           + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                           + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    startRow = row;
                    startCol = col;
                }
            }
        }

        // Print the platform
        Console.WriteLine("The maximal platform is:");
        for (int row = startRow; row <= startRow + 2; row++)
        {
            for (int col = startCol; col <= startCol + 2; col++)
            {
                Console.Write("{0, 5}", matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}