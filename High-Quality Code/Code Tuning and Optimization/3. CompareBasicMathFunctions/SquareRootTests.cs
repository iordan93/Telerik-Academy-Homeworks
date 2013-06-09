namespace _3.CompareBasicMathFunctions
{
    using System;

    internal class SquareRootTests
    {
        internal static void FloatSquareRootTest(int repetitions)
        {
            float result;
            for (int i = 0; i < repetitions; i++)
            {
                result = (float)Math.Sqrt(2500);
            }
        }

        internal static void DoubleSquareRootTest(int repetitions)
        {
            double result;
            for (int i = 0; i < repetitions; i++)
            {
                result = Math.Sqrt(2500);
            }
        }

        internal static void DecimalSquareRootTest(int repetitions)
        {
            decimal result;
            for (int i = 0; i < repetitions; i++)
            {
                result = (decimal)Math.Sqrt(2500);
            }
        }
    }
}
