namespace RotatingWalkInMatrix
{
    using System;

    public class RotatingWalkInMatrix
    {
        private const int DirectionsCount = 8;
        private static readonly int[] directionVectorX = { 1, 1, 1, 0, -1, -1, -1, 0 };
        private static readonly int[] directionVectorY = { 1, 0, -1, -1, -1, 0, 1, 1 };

        public static void Main()
        {
            int size = ReadMatrixSize();

            int[,] matrix = FillRotatingWalkMatrix(size);

            PrintMatrix(matrix);
        }

        public static int[,] FillRotatingWalkMatrix(int size)
        {
            int[,] matrix = new int[size, size];
            int currentNumber = 1;
            int currentRow = 0;
            int currentColumn = 0;
            int directionRow = 1;
            int directionColumn = 1;

            FillNextValue(matrix, ref currentNumber, ref directionRow, ref directionColumn, ref currentRow, ref currentColumn);

            GetFirstEmptyCell(matrix, out currentRow, out currentColumn);

            currentNumber++;
            if (currentRow != 0 && currentColumn != 0)
            {
                directionRow = 1;
                directionColumn = 1;

                FillNextValue(matrix, ref currentNumber, ref directionRow, ref directionColumn, ref currentRow, ref currentColumn);
            }

            return matrix;
        }

        private static void ChangeDirection(ref int directionX, ref int directionY)
        {
            int currentDirectionIndex = 0;
            for (int count = 0; count < DirectionsCount; count++)
            {
                if (directionVectorX[count] == directionX && directionVectorY[count] == directionY)
                {
                    currentDirectionIndex = count;
                    break;
                }
            }

            if (currentDirectionIndex == 7)
            {
                directionX = directionVectorX[0];
                directionY = directionVectorY[0];
                return;
            }

            directionX = directionVectorX[currentDirectionIndex + 1];
            directionY = directionVectorY[currentDirectionIndex + 1];
        }

        private static bool CheckFreeNeighbourCells(int[,] matrix, int row, int col)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);
            for (int i = 0; i < DirectionsCount; i++)
            {
                bool isValidRow = 0 <= row + directionVectorX[i] &&
                    row + directionVectorX[i] < rows;
                bool isValidColumn = 0 <= col + directionVectorY[i] &&
                    col + directionVectorY[i] < cols;

                int currentDirectionX = directionVectorX[i];
                int currentDirectionY = directionVectorY[i];

                if (!isValidRow)
                {
                    currentDirectionX = 0;
                }

                if (!isValidColumn)
                {
                    currentDirectionY = 0;
                }

                if (matrix[row + currentDirectionX, col + currentDirectionY] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private static void GetFirstEmptyCell(int[,] matrix, out int row, out int column)
        {
            int rows = matrix.GetLength(0);
            int cols = matrix.GetLength(1);

            row = 0;
            column = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        column = j;
                        return;
                    }
                }
            }
        }

        private static int ReadMatrixSize()
        {
            Console.WriteLine("Enter a positive number ");
            string input = Console.ReadLine();
            const int MinSize = 0;
            const int MaxSize = 100;
            int size = 0;

            while (!int.TryParse(input, out size) || size < MinSize || size > MaxSize)
            {
                Console.WriteLine("You haven't entered a correct positive number. It must be in the range [{0}; {1}]", MinSize, MaxSize);
                input = Console.ReadLine();
            }

            return size;
        }

        private static void PrintMatrix(int[,] matrix)
        { 
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write("{0,4}", matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private static void FillNextValue(int[,] matrix, ref int currentNumber, ref int directionRow, ref int directionColumn, ref int currentRow, ref int currentColumn)
        {
            int size = matrix.GetLength(0);
            matrix[currentRow, currentColumn] = currentNumber;

            while (CheckFreeNeighbourCells(matrix, currentRow, currentColumn))
            {
                while (currentRow + directionRow < 0 || currentRow + directionRow >= size ||
                    currentColumn + directionColumn < 0 || currentColumn + directionColumn >= size ||
                    matrix[currentRow + directionRow, currentColumn + directionColumn] != 0)
                {
                    ChangeDirection(ref directionRow, ref directionColumn);
                }

                currentRow += directionRow;
                currentColumn += directionColumn;
                currentNumber++;
                matrix[currentRow, currentColumn] = currentNumber;
            }
        }
    }
}