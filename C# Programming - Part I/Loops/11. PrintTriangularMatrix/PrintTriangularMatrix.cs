using System;

class PrintTriangularMatrix
{
    static void Main()
    {
        Console.WriteLine("Enter N (1 < N < 100): ");
        int n = int.Parse(Console.ReadLine());
        for (int rows = 1; rows <= n; rows++)
        {
            for (int cols = rows; cols <= rows+n-1; cols++)
            {
                Console.Write("{0,3} ", cols);
            }
            Console.WriteLine();
        }
    }
}