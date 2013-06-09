namespace _3.CompareBasicMathFunctions
{
    using System;

    internal class SineTests
    {
        internal static void FloatSineTest(int repetitions)
        {
            float result;
            for (int i = 0; i < repetitions; i++)
            {
                result = (float)Math.Sin(0.75);
            }
        }

        internal static void DoubleSineTest(int repetitions)
        {
            double result;
            for (int i = 0; i < repetitions; i++)
            {
                result = Math.Sin(0.75);
            }
        }

        internal static void DecimalSineTest(int repetitions)
        {
            decimal result;
            for (int i = 0; i < repetitions; i++)
            {
                result = (decimal)Math.Log(0.75);
            }
        }
    }
}
