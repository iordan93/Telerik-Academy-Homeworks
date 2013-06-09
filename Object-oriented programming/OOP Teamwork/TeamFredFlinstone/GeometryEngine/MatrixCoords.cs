using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;
using CustomExceptions;
namespace GeometryEngine
{
    public class MatrixCoords
    {
        // Private fields
        private int rows = 0;
        private int cols = 0;

        // Public properties to encapsulate the fields
        public int Rows
        {
            get
            {
                return this.rows;
            }
            set
            {
                this.rows = value;   
            }
        }

        public int Cols
        {
            get
            {
                return this.cols;
            }
            set
            {
                    this.cols = value;
            }
        }

        // Constructors
        public MatrixCoords(int rows, int cols)
        {
            this.Rows = rows;
            this.Cols = cols;
        }

        // Operators + and -
        public static MatrixCoords operator +(MatrixCoords a, MatrixCoords b)
        {
            return new MatrixCoords(a.Rows + b.Rows, a.Cols + b.Cols);
        }

        public static MatrixCoords operator -(MatrixCoords a, MatrixCoords b)
        {
            return new MatrixCoords(a.Rows - b.Rows, a.Cols - b.Cols);
        }

        // Operator * (with a number)
        public static MatrixCoords operator *(int num, MatrixCoords a)
        {
            return new MatrixCoords(a.Rows * num, a.Cols * num);
        }
    }
}

