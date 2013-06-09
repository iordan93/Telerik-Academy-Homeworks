using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _8._10.Matrix;

namespace MatrixTest
{
    [TestClass]
    public class MatrixTest
    {
        [TestMethod]
        public void ToStringAndOperatorsTest()
        {
            Matrix<double> matrix1 = new Matrix<double>(2, 2);
            matrix1[0, 0] = 1.56;
            matrix1[0, 1] = 5.32;
            matrix1[1, 0] = 1.54;
            matrix1[1, 1] = 2.46;
            Console.WriteLine(matrix1 + matrix1);
            Console.WriteLine(matrix1.Equals(2 * matrix1));
            Console.WriteLine(matrix1 * matrix1);

            Matrix<int> matrix2 = new Matrix<int>(2, 2);
            matrix2[0, 0] = 0;
            matrix2[0, 1] = 1;
            matrix2[1, 0] = 0;
            matrix2[1, 1] = 0;
            Console.WriteLine(matrix2 + matrix2);
            Console.WriteLine(matrix2 * matrix2);

            Matrix<float> matrix3 = new Matrix<float>();
            Console.WriteLine(matrix1 ? "Full matrix" : "Only zero elements");
            Console.WriteLine(matrix2 ? "Full matrix" : "Only zero elements");
            Console.WriteLine(matrix3 ? "Full matrix" : "Only zero elements");
        }

    }
}
