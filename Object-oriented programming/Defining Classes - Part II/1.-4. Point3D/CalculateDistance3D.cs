using System;

namespace _1._4.Point3D
{
    public static class CalculateDistance3D
    {
        public static double CalculateDistance(Point3D p1, Point3D p2)
        {
            // Eucledian (standard) distance between two points A(a1, a2, a3) and B(b1, b2, b3):
            // d = sqrt((b1 - a1)^2 + (b2 - a2)^2 + (b3 - a3)^2)
            double firstMember = Math.Pow(p2.X - p1.X, 2);
            double secondMember = Math.Pow(p2.Y - p1.Y, 2);
            double thirdMember = Math.Pow(p2.Z - p1.Z, 2);

            return Math.Sqrt(firstMember + secondMember + thirdMember);
        }
    }
}
