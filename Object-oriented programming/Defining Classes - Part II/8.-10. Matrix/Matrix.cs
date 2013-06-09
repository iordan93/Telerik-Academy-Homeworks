using System;
using System.Collections;
using System.Text;
namespace _8._10.Matrix
{
    public class Matrix<T> : IEquatable<Matrix<T>>
    {
        // Initialize the basic fields - number of rows, number  of columns and inner array
        private int rows = 0;
        private int cols = 0;
        private readonly T[,] matrix = null;

        // Rows property with input checker
        public int Rows
        {
            get
            {
                return this.rows;
            }
            private set
            {
                if (value >= 0)
                {
                    this.rows = value;
                }
                else
                {
                    throw new ArgumentException("The number of rows in the matrix must be a nonnegative number.");
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
            private set
            {
                if (value >= 0)
                {
                    this.cols = value;
                }
                else
                {
                    throw new ArgumentException("The number of columns in the matrix must be a nonnegative number.");
                }
            }
        }

        // Constructors
        // Empty constructor - initalize a zero by zero matrix
        public Matrix()
            : this(0, 0)
        {
        }

        // Constructor with given dimensions
        public Matrix(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
            this.matrix = new T[Rows, Cols];
        }

        // Indexer
        public dynamic this[int row, int col]
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
        public static Matrix<T> operator +(Matrix<T> m1, Matrix<T> m2)
        {
            if ((m1.Rows != m2.Rows) || (m2.Cols != m2.Cols))
            {
                throw new ArgumentException("To sum two matrices, they must have equal dimensions.");
            }
            else
            {
                Matrix<T> sum = new Matrix<T>(m1.Rows, m1.Cols);
                for (int row = 0; row < m1.Rows; row++)
                {
                    for (int col = 0; col < m1.Cols; col++)
                    {
                        sum[row, col] = m1[row, col] + m2[row, col];
                    }
                }
                return sum;
            }
        }

        // Sum of a matrix with any other number is not defined. Since sum is commutative, there are two methods
        public static object operator +(Matrix<T> m1, double number)
        {
            throw new ArgumentException("Matrix sum is defined only between two matrices.");
        }

        public static object operator +(double number, Matrix<T> m1)
        {
            throw new ArgumentException("Matrix sum is defined only between two matrices.");
        }

        // Multiplication of a matrix A = (a_ij)(mxn) with the real number n we define as the matrix M
        // M = (m_ij)(mxn), where m_ij = n * a_ij.
        // Multiplication in this case is commutative, so there are two methods to do it.
        public static Matrix<T> operator *(double number, Matrix<T> m)
        {
            Matrix<T> multiplication = new Matrix<T>(m.Rows, m.Cols);
            for (int row = 0; row < m.Rows; row++)
            {
                for (int col = 0; col < m.Cols; col++)
                {
                    multiplication[row, col] = number * m[row, col];
                }
            }
            return multiplication;
        }

        public static Matrix<T> operator *(Matrix<T> m, T number)
        {
            Matrix<T> multiplication = new Matrix<T>(m.Rows, m.Cols);
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
        public static Matrix<T> operator *(Matrix<T> m1, Matrix<T> m2)
        {
            if (m1.Cols != m2.Rows)
            {
                throw new ArgumentException("To multiply two matrices, the number of columns of the first must be equal to the number of rows of the second.");
            }
            else
            {
                Matrix<T> multiplication = new Matrix<T>(m1.Rows, m2.Cols);
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

        // Boolean true and false operators
        // Return true if at least one element is not zero
        public static bool operator true(Matrix<T> m)
        {
            foreach (T item in m.matrix)
            {
                if ((dynamic)item != 0)
                {
                    return true;
                }
            }
            return false;

        }

        public static bool operator false(Matrix<T> m)
        {
            // False returns "true" if the condition is false and vice versa :)
            // In this case, if there are zero elements, "false" returns true (and "true" returns false :))
            foreach (T item in m.matrix)
            {
                if ((dynamic)item == 0)
                {
                    return true;
                }
            }
            return false;
        }

        // The ToString() method returns the matrix as a string (for example to write it to the console)
        ///<note>If the matrix members do not fit in ten spaces, you can edit the string.Format</note>
        // TODO: Format the spaces using Math.Log10() 
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    builder.AppendFormat("{0, 10}", this[row, col]);
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        public bool Equals(Matrix<T> other)
        {
            if (!(this.Rows == other.Rows && this.Cols == other.Cols))
                return false;

            for (int row = 0; row < this.Rows; row++)
            {
                for (int col = 0; col < this.Cols; col++)
                {
                    if (this[row,col]!=other[row,col])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}