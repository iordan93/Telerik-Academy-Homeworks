namespace _3.CompareBasicMathFunctions
{
    using System;

    internal class NaturalLogarithmTests
    {
        internal static void FloatNaturalLogarithmTest(int repetitions)
        {
            float result;
            for (int i = 0; i < repetitions; i++)
            {
                result = (float)Math.Log(200);
            }
        }

        internal static void DoubleNaturalLogarithmTest(int repetitions)
        {
            double result;
            for (int i = 0; i < repetitions; i++)
            {
                result = Math.Log(200);
            }
        }

        internal static void DecimalNaturalLogarithmTest(int repetitions)
        {
            decimal result;
            for (int i = 0; i < repetitions; i++)
            {
                result = (decimal)Math.Log(200);
            }
        }
    }
}
