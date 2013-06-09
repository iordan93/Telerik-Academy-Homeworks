namespace _2.CompareBasicMathOperations
{
    using System;

    internal class SubtractionTests
    {
        internal static void IntSubtractionTest(int start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start -= 1;
            }
        }

        internal static void LongSubtractionTest(long start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start -= 1L;
            }
        }

        internal static void FloatSubtractionTest(float start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start -= 1.0f;
            }
        }

        internal static void DoubleSubtractionTest(double start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start -= 1.0;
            }
        }

        internal static void DecimalSubtractionTest(decimal start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start -= 1.0m;
            }
        }
    }
}
