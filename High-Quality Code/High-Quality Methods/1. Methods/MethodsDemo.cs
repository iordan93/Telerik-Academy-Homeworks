namespace _1.Methods
{
    using System;

    internal class MethodsDemo
    {
        internal static void Main()
        {
            Console.WriteLine(GeometryUtilities.CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(NumberUtilities.NumberToDigit(5));

            Console.WriteLine(StatisticsUtilities.FindMax(5, -1, 3, 2, 14, 2, 3));

            NumberUtilities.PrintAsNumber(1.3, "f");
            NumberUtilities.PrintAsNumber(0.75, "%");
            NumberUtilities.PrintAsNumber(2.30, "r");

            Console.WriteLine(GeometryUtilities.CalculateDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + GeometryUtilities.IsHorizontalLine(3, -1, 3, 2.5));
            Console.WriteLine("Vertical? " + GeometryUtilities.IsVerticalLine(3, -1, 3, 2.5));

            Student peter = new Student() { FirstName = "Peter", LastName = "Ivanov", DateOfBirth = new DateTime(1992, 3, 17) };
            peter.OtherInfo = "From Sofia";

            Student stella = new Student() { FirstName = "Stella", LastName = "Markova", DateOfBirth = new DateTime(1993, 11, 3) };
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
