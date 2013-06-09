namespace CohesionAndCoupling
{
    using System;

    public static class GeometryUtilities
    {
        public static double CalculateDistance2D(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
            return distance;
        }

        public static double CalculateDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            double distance = Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2) + Math.Pow(z2 - z1, 2));
            return distance;
        }

        public static double CalculateDistanceToOrigin2D(double x, double y)
        {
            return CalculateDistance2D(0, 0, x, y);
        }

        public static double CalculateDistanceToOrigin3D(double x, double y, double z)
        {
            return CalculateDistance3D(0, 0, 0, x, y, z);
        }
    }
}
