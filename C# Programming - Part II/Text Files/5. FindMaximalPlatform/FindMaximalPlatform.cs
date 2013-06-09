using System;
using System.Globalization;
using System.IO;
using System.Text;
using System.Threading;

class FindMaximalPlatform
{
    // Read the file and produce a string with the matrix contents
    static string ReadFile()
    {
        Console.Write("Enter the path to the file: ");
        string path = Console.ReadLine();
        StreamReader reader = new StreamReader(path);
        StringBuilder builder = new StringBuilder();
        using (reader)
        {
            int rows = int.Parse(reader.ReadLine());
            for (int i = 0; i < rows; i++)
            {
                builder.AppendLine(reader.ReadLine());
            }
        }
        return builder.ToString();
    }

    // Split the string by new lines to take each row.
    // For each row, split the string by spaces to take each element.
    // Parse each element as double to get the matrix
    static double[,] ConvertFileToMatrix(string file)
    {
        string[] line = file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        double[,] matrix = new double[line.Length, line.Length];
        for (int rows = 0; rows < line.Length; rows++)
        {
            string[] lineSplit = line[rows].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            for (int cols = 0; cols < lineSplit.Length; cols++)
            {
                matrix[rows, cols] = double.Parse(lineSplit[cols]);
            }
        }
        return matrix;
    }

    static void FindMaxPlatform(double[,] matrix, out int startRow, out int startCol)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        double currentSum = 0;
        double bestSum = double.MinValue;
        startRow = 0;
        startCol = 0;
        // Find the maximal sum and remember the row and column of the starting member of the matrix
        for (int row = 0; row < rows - 1; row++)
        {
            for (int col = 0; col < cols - 1; col++)
            {
                currentSum = matrix[row, col] + matrix[row, col + 1] +
                             matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (currentSum > bestSum)
                {
                    bestSum = currentSum;
                    startRow = row;
                    startCol = col;
                }
            }
        }
    }

    // Run a loop from the best start row and best start column to show the maximal 2 x 2 platform
    private static void PrintMaxPlatform(int startRow, int startCol, double[,] matrix)
    {
        for (int row = startRow; row <= startRow + 1; row++)
        {
            for (int col = startCol; col <= startCol + 1; col++)
            {
                Console.Write(matrix[row, col] + " ");
            }
            Console.WriteLine();
        }
    }

    static void Main()
    {
        // If the numbers are double, process decimal separators without throwing an exception
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.WriteLine("This program will find the maximal platform in a matrix, read as a file.");
        string file = ReadFile();
        double[,] matrix = ConvertFileToMatrix(file);
        int startRow = -1;
        int startCol = -1;
        FindMaxPlatform(matrix, out startRow, out startCol);

        // Output
        Console.WriteLine("The maximal platform is");
        PrintMaxPlatform(startRow, startCol, matrix);
    } 
}