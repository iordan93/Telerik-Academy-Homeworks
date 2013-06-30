using System;

public class FindAllAreasOfEmptyCells
{
    private static readonly string[,] matrix = 
    {
        { " ", " ", " ", "*", " ", " ", " " },
        { " ", " ", " ", "*", " ", " ", " " },
        { " ", " ", " ", "*", "*", "*", "*" },
        { "*", "*", "*", "*", " ", " ", " " },
        { "*", " ", " ", "*", " ", " ", " " },
    };

    private static readonly Tuple<int, int>[] directions = 
    {
        new Tuple<int, int>(1, 0),
        new Tuple<int, int>(0, 1),
        new Tuple<int, int>(-1, 0),
        new Tuple<int, int>(0, -1)
    };

    private static int currentCount = 0;

    private static int maximalCount = 0;

    public static void Main()
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                if (IsAllowedToPass(row, col))
                {
                    GetLargestArea(row, col);
                    if (currentCount > maximalCount)
                    {
                        maximalCount = currentCount;
                    }

                    Console.WriteLine("Area: {0} elements", maximalCount);
                    maximalCount = 0;
                    currentCount = 0;
                }
            }
        }
    }

    private static void GetLargestArea(int row, int col)
    {
        if (!IsAllowedToPass(row, col))
        {
            return;
        }
        else
        {
            matrix[row, col] = "@";
            currentCount++;

            foreach (var direction in directions)
            {
                if (IsAllowedToPass(row + direction.Item1, col + direction.Item2))
                {
                    int futureRow = row + direction.Item1;
                    int futureCol = col + direction.Item2;
                    GetLargestArea(futureRow, futureCol);
                }
            }
        }
    }

    private static bool IsAllowedToPass(int row, int col)
    {
        if (row < 0 || row >= matrix.GetLength(0))
        {
            return false;
        }

        if (col < 0 || col >= matrix.GetLength(1))
        {
            return false;
        }

        if (matrix[row, col] != " ")
        {
            return false;
        }

        return true;
    }

    private static void PrintLabyrinth()
    {
        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write("{0,2}", matrix[i, j]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }
}