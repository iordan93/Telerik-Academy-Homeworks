using System;
using System.Collections;
using System.Text;

class Matrix
{
    // Initialize the basic fields - number of rows, number  of columns and inner array
    private int rows = 0;
    private int cols = 0;
    private readonly double[,] matrix;

    // Rows property with input checker
    public int Rows
    {
        get
        {
            return this.rows;
        }
        set
        {
            if (value >= 0)
            {
                this.rows = value;
            }
            else
            {
                throw new ArgumentException("The number of rows in the matrix must be a non-negative number.");
            }
        }
    }

    // Columns property with input checker
    public int Cols
    {
        get
        {
            return this.cols;
        }
        set
        {
            if (value >= 0)
            {
                this.cols = value;
            }
            else
            {
                throw new ArgumentException("The number of columns in the matrix must be a non-negative number.");
            }
        }
    }

    // Empty constructor - initalize a zero by zero matrix
    public Matrix()
    {
        this.Rows = 0;
        this.Cols = 0;
        this.matrix = new double[Rows, Cols];
    }

    // Constructor with given dimensions - initialize a matrix with the given dimensions
    public Matrix(int rows, int cols)
    {
        this.Rows = rows;
        this.Cols = cols;
        this.matrix = new double[Rows, Cols];
    }

    // Indexer - gives indices to the elements of the matrix
    public double this[int row, int col]
    {
        get
        {
            return this.matrix[row, col];
        }
        set
        {
            this.matrix[row, col] = value;
        }
    }

    // Sum of two matrices A = (a_ij)(mxn) and B = (b_ij)(mxn) we define as the matrix S
    // S = (s_ij)(mxn), where s_ij = a_ij + b_ij.
    // If A and B have different dimensions, S is not defined.
    public static Matrix operator +(Matrix m1, Matrix m2)
    {
        Matrix sum = new Matrix(m1.Rows, m1.Cols);
        if ((m1.Rows != m2.Rows) || (m1.Cols != m2.Cols))
        {
            throw new ArgumentException("To sum two matrices, they must have equal dimensions.");
        }
        else
        {
            for (int row = 0; row < m1.Rows; row++)
            {
                for (int col = 0; col < m1.Cols; col++)
                {
                    sum[row, col] = m1[row, col] + m2[row, col];
                }
            }
        }
        return sum;
    }

    // Sum of a matrix with any other number is not defined. Since sum is commutative, there are two methods
    public static object operator +(Matrix m1, double number)
    {
        throw new ArgumentException("Matrix sum is defined only between two matrices.");
    }

    public static object operator +(double number, Matrix m1)
    {
        throw new ArgumentException("Matrix sum is defined only between two matrices.");
    }

    // Multiplication of a matrix A = (a_ij)(mxn) with the real number n we define as the matrix M
    // M = (m_ij)(mxn), where m_ij = n * a_ij.
    // Multiplication in this case is commutative, so there are two methods to do it.
    public static Matrix operator *(double number, Matrix m)
    {
        Matrix multiplication = new Matrix(m.Rows, m.Cols);
        for (int row = 0; row < m.Rows; row++)
        {
            for (int col = 0; col < m.Cols; col++)
            {
                multiplication[row, col] = number * m[row, col];
            }
        }
        return multiplication;
    }

    public static Matrix operator *(Matrix m, double number)
    {
        Matrix multiplication = new Matrix(m.Rows, m.Cols);
        for (int row = 0; row < m.Rows; row++)
        {
            for (int col = 0; col < m.Cols; col++)
            {
                multiplication[row, col] = number * m[row, col];
            }
        }
        return multiplication;
    }

    // Multiplication between two matrices A = (a_ij)(mxn) and B = (b_ij)(nxm) we define as the matrix M
    // M = (m_ij)(nxn), where m_ij = Σ(a_ik)*(b_kj).
    public static Matrix operator *(Matrix m1, Matrix m2)
    {
        if (m1.Cols != m2.Rows)
        {
            throw new ArgumentException("To multiply two matrices, the number of columns of the first must be equal to the number of rows of the second.");
        }
        else
        {
            Matrix multiplication = new Matrix(m1.Rows, m2.Cols);
            for (int i = 0; i < multiplication.Rows; i++)
            {
                for (int j = 0; j < multiplication.Cols; j++)
                {
                    multiplication[i, j] = 0;
                    for (int k = 0; k < m1.Cols; k++)
                    {
                        multiplication[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }
            return multiplication;
        }
    }

    // The ToString() method returns the matrix as a string (for example to write it to the console)
    ///<note>If the matrix members do not fit in four spaces, you can edit the string.Format</note>
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        for (int row = 0; row < this.Rows; row++)
        {
            for (int col = 0; col < this.Cols; col++)
            {
                sb.Append(string.Format("{0, 4}", matrix[row, col]));
            }
            sb.AppendLine();
        }
        return sb.ToString();
    }
}

class MatrixTest
{
    static void Main()
    {
        // Test the Matrix class
        // To show both sum and multiplication of matrices, I am using square matrices, but the operators work on any matrix
        Matrix matrix1 = new Matrix(3, 3);
        for (int i = 0; i < matrix1.Rows; i++)
        {
            for (int j = 0; j < matrix1.Cols; j++)
            {
                matrix1[i, j] = i + j;
            }
        }
        Matrix matrix2 = new Matrix(3, 3);
        for (int i = 0; i < matrix2.Rows; i++)
        {
            for (int j = 0; j < matrix2.Cols; j++)
            {
                matrix2[i, j] = 2 * i - 3 * j;
            }
        }
        Console.WriteLine("Matrix A = (a_ij):");
        Console.WriteLine(matrix1);
        Console.WriteLine("Matrix B = (b_ij):");
        Console.WriteLine(matrix2);
        Console.WriteLine("Matrix 1 + Matrix 2:");
        Console.WriteLine(matrix1 + matrix2);
        Console.WriteLine("2 * Matrix 1:");
        Console.WriteLine(2 * matrix1);
        Console.WriteLine("Matrix 1 * Matrix 2:");
        Console.WriteLine(matrix1 * matrix2);
    }
}