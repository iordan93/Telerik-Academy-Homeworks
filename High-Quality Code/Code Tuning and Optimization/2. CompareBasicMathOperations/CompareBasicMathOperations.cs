namespace _2.CompareBasicMathOperations
{
    using System;
    using System.Diagnostics;

    public class CompareBasicMathOperations
    {
        internal static void Main()
        {
            // To test different data types, it is best to test a range of numbers, not a single operation (e. g. 5 + 5) performed many times
            Console.WriteLine("{0} 10 million iterations: {0}\r\n", new string('=', 10));
            RunAdditionTests();
            Console.WriteLine();
            RunIncrementationTests();
            Console.WriteLine();
            RunSubtractionTests();
            Console.WriteLine();
            RunMultiplicationTests();
            Console.WriteLine();
            RunDivisionTests();
        }

        private static void RunAdditionTests()
        {
            DisplayPerformanceTests(() => AdditionTests.IntAditionTest(1, 10000000), "Integer addition");
            DisplayPerformanceTests(() => AdditionTests.LongAditionTest(1L, 10000000), "Long addition");
            DisplayPerformanceTests(() => AdditionTests.FloatAditionTest(1.5f, 10000000), "Float addition");
            DisplayPerformanceTests(() => AdditionTests.DoubleAditionTest(1.5, 10000000), "Double addition");
            DisplayPerformanceTests(() => AdditionTests.DecimalAditionTest(1.5m, 10000000), "Decimal addition");
        }

        private static void RunIncrementationTests()
        {
            DisplayPerformanceTests(() => IncrementationTests.IntIncrementationTest(1, 10000000), "Integer incrementation");
            DisplayPerformanceTests(() => IncrementationTests.LongIncrementationTest(1L, 10000000), "Long incrementation");
            DisplayPerformanceTests(() => IncrementationTests.FloatIncrementationTest(1.5f, 10000000), "Float incrementation");
            DisplayPerformanceTests(() => IncrementationTests.DoubleIncrementationTest(1.5, 10000000), "Double incrementation");
            DisplayPerformanceTests(() => IncrementationTests.DecimalIncrementationTest(1.5m, 10000000), "Decimal incrementation");
        }

        private static void RunSubtractionTests()
        {
            DisplayPerformanceTests(() => SubtractionTests.IntSubtractionTest(1, 10000000), "Integer subtraction");
            DisplayPerformanceTests(() => SubtractionTests.LongSubtractionTest(1L, 10000000), "Long subtraction");
            DisplayPerformanceTests(() => SubtractionTests.FloatSubtractionTest(1.5f, 10000000), "Float subtraction");
            DisplayPerformanceTests(() => SubtractionTests.DoubleSubtractionTest(1.5, 10000000), "Double subtraction");
            DisplayPerformanceTests(() => SubtractionTests.DecimalSubtractionTest(1.5m, 10000000), "Decimal subtraction");
        }

        private static void RunMultiplicationTests()
        {
            DisplayPerformanceTests(() => MultiplicationTests.IntMultiplicationTest(1, 10000000), "Integer multiplication");
            DisplayPerformanceTests(() => MultiplicationTests.LongMultiplicationTest(1L, 10000000), "Long multiplication");
            DisplayPerformanceTests(() => MultiplicationTests.FloatMultiplicationTest(1.5f, 10000000), "Float multiplication");
            DisplayPerformanceTests(() => MultiplicationTests.DoubleMultiplicationTest(1.5, 10000000), "Double multiplication");
            DisplayPerformanceTests(() => MultiplicationTests.DecimalMultiplicationTest(1.5m, 10000000), "Decimal multiplication");
        }

        private static void RunDivisionTests()
        {
            DisplayPerformanceTests(() => DivisionTests.IntDivisionTest(1, 10000000), "Integer division");
            DisplayPerformanceTests(() => DivisionTests.LongDivisionTest(1L, 10000000), "Long division");
            DisplayPerformanceTests(() => DivisionTests.FloatDivisionTest(1.5f, 10000000), "Float division");
            DisplayPerformanceTests(() => DivisionTests.DoubleDivisionTest(1.5, 10000000), "Double division");
            DisplayPerformanceTests(() => DivisionTests.DecimalDivisionTest(1.5m, 10000000), "Decimal division");
        }

        private static void DisplayPerformanceTests(Action method, string testName)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            method();
            stopwatch.Stop();

            Console.WriteLine("{0} -> {1}ms", testName, stopwatch.ElapsedMilliseconds);
        }
    }
}
