using System;
using System.IO;

public class PointInsideTriangle
{
    public static void Main()
    {
        StreamReader input = new StreamReader("../../input.txt");
        Console.SetIn(input);

        Point[] points = new Point[4];
        for (int i = 0; i < points.Length; i++)
        {
            string[] pointInfo = Console.ReadLine().Split(' ');
            points[i] = new Point(double.Parse(pointInfo[0]), double.Parse(pointInfo[1]), 0);
        }

        Vector sideA = new Vector(points[0]);
        Vector sideB = new Vector(points[1]);
        Vector sideC = new Vector(points[2]);
        Vector point = new Vector(points[3]);

        bool result = IsInTriangle(point, sideA, sideB, sideC);

        Console.WriteLine("The point {0} within the triangle.", result ? "is" : "is not");
    }

    private static bool AreInSameHalfPlane(Vector point, Vector sideA, Vector sideB, Vector sideC)
    {
        // If a point is in the same half-plane with three other points,
        // the scalar product of their vector products is nonnegative
        Vector firstVectorProduct = Vector.VectorProduct(sideB - sideA, point - sideA);
        Vector secondVectorProduct = Vector.VectorProduct(sideB - sideA, sideC - sideA);
        double result = Vector.ScalarProduct(firstVectorProduct, secondVectorProduct);

        return result >= 0;
    }

    private static bool IsInTriangle(Vector point, Vector sideA, Vector sideB, Vector sideC)
    {
        // A point is in triangle, if viewed from any point, A, B, and C,
        // the four points are in the same half-plane
        return AreInSameHalfPlane(point, sideA, sideB, sideC) &&
            AreInSameHalfPlane(point, sideB, sideC, sideA) &&
            AreInSameHalfPlane(point, sideC, sideA, sideB);
    }
}