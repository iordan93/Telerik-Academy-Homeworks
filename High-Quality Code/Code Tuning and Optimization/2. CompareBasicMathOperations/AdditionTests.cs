namespace _2.CompareBasicMathOperations
{
    using System;

    internal class AdditionTests
    {
        internal static void IntAditionTest(int start, int repetitions) 
        {
            for (int i = 0; i < repetitions; i++)
            {
                start += 2;
            }
        }

        internal static void LongAditionTest(long start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start += 2L;
            }
        }

        internal static void FloatAditionTest(float start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start += 2.0f;
            }
        }

        internal static void DoubleAditionTest(double start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start += 2.0;
            }
        }

        internal static void DecimalAditionTest(decimal start, int repetitions)
        {
            for (int i = 0; i < repetitions; i++)
            {
                start += 2.0m;
            }
        }
    }
}
