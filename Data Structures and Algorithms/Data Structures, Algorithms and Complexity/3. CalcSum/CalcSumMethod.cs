using System;

public class CalcSumMethod
{
    public static void Main(string[] args)
    {
        int[,] inputMatrix = new int[,] 
            {
                { 2, 5, -1, 2, 0 },
                { 2, 1, 4, -3, 2 },
                { 1, 2, -6, 4, 3 }
            };

        long sum = CalcSum(inputMatrix, 0);
        Console.WriteLine(sum);
    }

    // Since the ranks of the matrix are wrong, the algorithm only works on matrices 
    // whose rows count is more than or equal to their columns count.
    // Also, the recursion is unnecessary and can be avoided although this will not make the algorithm faster
    // in terms of asymptotic notation.
    // Analysis:
    // Given a matrix of size n* m, the algorithm first makes O(n) steps to sum the elements in the current row.
    // Then it takes between 0 and m steps, depending on the starting row, calling itself recursively.
    // Since in asymptotic notation, the exact number of steps between 0 and m is not important, 
    // the running time is O(n * m)
    public static long CalcSum(int[,] matrix, int row)
    {
        long sum = 0;
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            sum += matrix[row, col];
        }

        if (row + 1 < matrix.GetLength(0))
        {
            sum += CalcSum(matrix, row + 1);
        }

        return sum;
    }
}
