using System;

public class LargestAreaOfEmptyCells
{
    private static readonly string[,] matrix = 
    {
        { " ", " ", " ", "*", " ", " ", " " },
        { "*", "*", " ", "*", " ", "*", " " },
        { " ", " ", " ", " ", " ", " ", " " },
        { " ", "*", "*", "*", "*", "*", " " },
        { " ", " ", " ", " ", " ", " ", " " },
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

                    currentCount = 0;
                }
            }
        }

        Console.WriteLine("The maximal area consists of {0} elements.", maximalCount);
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
}