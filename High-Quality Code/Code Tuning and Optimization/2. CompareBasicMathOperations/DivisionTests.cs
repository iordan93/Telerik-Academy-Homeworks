namespace _2.CompareBasicMathOperations
{
    using System;

    internal class DivisionTests
    {
        internal static void IntDivisionTest(int start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start /= 1;
            }
        }

        internal static void LongDivisionTest(long start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start /= 1L;
            }
        }

        internal static void FloatDivisionTest(float start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start /= 1.0f;
            }
        }

        internal static void DoubleDivisionTest(double start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start /= 1.0;
            }
        }

        internal static void DecimalDivisionTest(decimal start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start /= 1.0m;
            }
        }
    }
}