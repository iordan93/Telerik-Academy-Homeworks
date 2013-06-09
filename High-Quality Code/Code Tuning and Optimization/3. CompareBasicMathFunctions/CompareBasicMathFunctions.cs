namespace _3.CompareBasicMathFunctions
{
    using System;
    using System.Diagnostics;

    internal class CompareBasicMathFunctions
    {
        internal static void Main()
        {
            // Unlike data types, testing functions requires equal starting conditions, 
            // so it is best to run a single function many times
            Console.WriteLine("{0} 10 million iterations: {0}\r\n", new string('=', 10));
            RunSquareRootTests();
            Console.WriteLine();
            RunNaturalLogarithmTests();
            Console.WriteLine();
            RunSineTests();
        }

        private static void DisplayPerformanceTests(Action method, string testName)
        {
            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            method();
            stopwatch.Stop();

            Console.WriteLine("{0} -> {1}ms", testName, stopwatch.ElapsedMilliseconds);
        }

        private static void RunSquareRootTests()
        {
            DisplayPerformanceTests(() => SquareRootTests.FloatSquareRootTest(10000000), "Float square root");
            DisplayPerformanceTests(() => SquareRootTests.DoubleSquareRootTest(10000000), "Double square root");
            DisplayPerformanceTests(() => SquareRootTests.DecimalSquareRootTest(10000000), "Decimal square root");
        }

        private static void RunNaturalLogarithmTests()
        {
            DisplayPerformanceTests(() => NaturalLogarithmTests.FloatNaturalLogarithmTest(10000000), "Float natural logarithm");
            DisplayPerformanceTests(() => NaturalLogarithmTests.DoubleNaturalLogarithmTest(10000000), "Double natural logarithm");
            DisplayPerformanceTests(() => NaturalLogarithmTests.DecimalNaturalLogarithmTest(10000000), "Decimal natural logarithm");
        }

        private static void RunSineTests()
        {
            DisplayPerformanceTests(() => SineTests.FloatSineTest(10000000), "Float sine");
            DisplayPerformanceTests(() => SineTests.DoubleSineTest(10000000), "Double sine");
            DisplayPerformanceTests(() => SineTests.DecimalSineTest(10000000), "Decimal sine");
        }
    }
}
