namespace _2.CompareBasicMathOperations
{
    using System;

    internal class MultiplicationTests
    {
        internal static void IntMultiplicationTest(int start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start *= 1;
            }
        }

        internal static void LongMultiplicationTest(long start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start *= 1L;
            }
        }

        internal static void FloatMultiplicationTest(float start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start *= 1.0f;
            }
        }

        internal static void DoubleMultiplicationTest(double start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start *= 1.0;
            }
        }

        internal static void DecimalMultiplicationTest(decimal start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start *= 1.0m;
            }
        }
    }
}
