using System;

public class EightQueensPuzzle
{
    private const int BoardSize = 5;

    public static void Main()
    {
        int solutionCount = 0;
        int[,] board = new int[BoardSize, BoardSize];

        // The indices and values keep the column and row of the queen respectively
        int[] queens = new int[BoardSize];
        for (int i = 0; i < BoardSize; i++)
        {
            queens[i] = -1;
        }

        // Implementation of the backtracking algorithm
        int column = 0;
        while (column != -1)
        {
            queens[column]++;

            // Reset and move one column back 
            if (queens[column] == BoardSize)
            {
                board[queens[column] - 1, column] = 0;
                queens[column] = -1;
                column--;
            }
            else
            {
                board[queens[column], column] = 1;
                if (queens[column] != 0)
                {
                    board[queens[column] - 1, column] = 0;
                }

                if (IsValidPosition(board))
                {
                    column++;

                    if (column == BoardSize)
                    {
                        column--;
                        solutionCount++;

                        PrintBoard(solutionCount, board);
                    }
                }
            }
        }
    }

    private static void PrintBoard(int solutionCount, int[,] board)
    {
        Console.WriteLine("Solution {0}:", solutionCount);
        for (int row = 0; row < BoardSize; row++)
        {
            for (int col = 0; col < BoardSize; col++)
            {
                Console.Write(board[row, col] == 1 ? '@' : '.');
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static bool IsValidPosition(int[,] board)
    {
        // No need to check the columns because there can be only one queen per column
        // and this is provided by the algorithm itself
        if (IsValidRow(board) && 
            IsValidMainDiagonal(board) && 
            IsValidSecondaryDiagonal(board)) 
        {
            return true;
        }

        return false;
    }
  
    private static bool IsValidSecondaryDiagonal(int[,] board)
    {
        for (int row = 0, col = 1; col < BoardSize; col++)
        {
            int sum = 0;
            for (int p = row, q = col; q >= 0; p++, q--)
            {
                sum = sum + board[p, q];
            }

            if (sum > 1)
            {
                return false;
            }
        }

        // Below
        for (int row = 1, col = BoardSize - 1; row < BoardSize - 1; row++)
        {
            int sum = 0;
            for (int p = row, q = col; p < BoardSize; p++, q--)
            {
                sum = sum + board[p, q];
            }

            if (sum > 1)
            {
                return false;
            }
        }

        return true;
    }
  
    private static bool IsValidMainDiagonal(int[,] board)
    {
        for (int row = 0, col = BoardSize - 2; col >= 0; col--)
        {
            int sum = 0;
            for (int p = row, q = col; q < BoardSize; p++, q++)
            {
                sum = sum + board[p, q];
            }

            if (sum > 1)
            {
                return false;
            }
        }

        // Below
        for (int i = 1, j = 0; i < BoardSize - 1; i++)
        {
            int sum = 0;
            for (int p = i, q = j; p < BoardSize; p++, q++)
            {
                sum = sum + board[p, q];
            }

            if (sum > 1)
            {
                return false;
            }
        }

        return true;
    }
  
    private static bool IsValidRow(int[,] board)
    {
        for (int row = 0; row < BoardSize; row++)
        {
            int sum = 0;
            for (int col = 0; col < BoardSize; col++)
            {
                sum = sum + board[row, col];
            }

            if (sum > 1)
            {
                return false;
            }
        }

        return true;
    }
}