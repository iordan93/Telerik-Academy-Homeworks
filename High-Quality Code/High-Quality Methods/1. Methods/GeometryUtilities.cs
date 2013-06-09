namespace _1.Methods
{
    using System;

    public class GeometryUtilities
    {
        public static double CalculateTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("The input sides should be positive.");
            }

            if (!SegmentsFormTriangle(a, b, c))
            {
                throw new ArgumentException("The input sides do not form a triangle.");
            }

            double semiperimeter = (a + b + c) / 2;
            double area = Math.Sqrt(semiperimeter * (semiperimeter - a) * (semiperimeter - b) * (semiperimeter - c));
            return area;
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return distance;
        }

        public static bool IsHorizontalLine(double x1, double y1, double x2, double y2)
        {
            if (!IsValidLine(x1, y1, x2, y2))
            {
                throw new ArgumentException("The points do not form a valid line.");
            }

            return y1 == y2;
        }

        public static bool IsVerticalLine(double x1, double y1, double x2, double y2)
        {
            if (!IsValidLine(x1, y1, x2, y2))
            {
                throw new ArgumentException("The points do not form a valid line.");
            }

            return x1 == x2;
        }

        private static bool IsValidLine(double x1, double y1, double x2, double y2)
        {
            return x1 != x2 || y1 != y2;
        }

        private static bool SegmentsFormTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }
    }
}
