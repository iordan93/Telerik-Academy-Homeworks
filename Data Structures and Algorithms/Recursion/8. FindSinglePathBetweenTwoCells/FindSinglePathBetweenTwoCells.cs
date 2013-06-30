using System;

public class FindSinglePathBetweenTwoCells
{
    private static readonly string[,] labyrinth = 
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

    private static bool solutionFound = false;

    public static void Main()
    {
        SetEndPoint(2, 6);

        // (0; 2) - chosen starting point
        GetAllPaths(0, 0);
    }

    private static void GetAllPaths(int row, int col)
    {
        if (solutionFound)
        {
            return;
        }
        else
        {
            if (!IsAllowedToPass(row, col))
            {
                return;
            }
            else if (labyrinth[row, col] == "e")
            {
                PrintLabyrinth();
                solutionFound = true;
                return;
            }
            else
            {
                labyrinth[row, col] = "@";

                foreach (var direction in directions)
                {
                    if (IsAllowedToPass(row + direction.Item1, col + direction.Item2))
                    {
                        int futureRow = row + direction.Item1;
                        int futureCol = col + direction.Item2;
                        GetAllPaths(futureRow, futureCol);
                    }
                }

                labyrinth[row, col] = " ";
            }
        }
    }

    private static void SetEndPoint(int row, int col)
    {
        labyrinth[row, col] = "e";
    }

    private static bool IsAllowedToPass(int row, int col)
    {
        if (row < 0 || row >= labyrinth.GetLength(0))
        {
            return false;
        }

        if (col < 0 || col >= labyrinth.GetLength(1))
        {
            return false;
        }

        if (labyrinth[row, col] != " " && labyrinth[row, col] != "e")
        {
            return false;
        }

        return true;
    }

    private static void PrintLabyrinth()
    {
        for (int i = 0; i < labyrinth.GetLength(0); i++)
        {
            for (int j = 0; j < labyrinth.GetLength(1); j++)
            {
                Console.Write("{0,2}", labyrinth[i, j]);
            }

            Console.WriteLine();
        }

        Console.WriteLine(new string('-', 15));
    }
}