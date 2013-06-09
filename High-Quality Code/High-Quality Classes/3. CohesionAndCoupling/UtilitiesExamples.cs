namespace CohesionAndCoupling
{
    using System;

    public class UtilitiesExamples
    {
        internal static void Main()
        {
            Console.WriteLine(FileUtilities.GetFileExtension("example"));
            Console.WriteLine(FileUtilities.GetFileExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileExtension("example.new.pdf"));

            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.pdf"));
            Console.WriteLine(FileUtilities.GetFileNameWithoutExtension("example.new.pdf"));

            Console.WriteLine(
                "Distance in the 2D space = {0:f2}",
                GeometryUtilities.CalculateDistance2D(1, -2, 3, 4));
            Console.WriteLine(
                "Distance in the 3D space = {0:f2}",
                GeometryUtilities.CalculateDistance3D(5, 2, -1, 3, -6, 4));

            Parallelepiped parallelepiped = new Parallelepiped(3, 4, 5);
            Console.WriteLine("Volume = {0:f2}", parallelepiped.CalculateVolume());
            Console.WriteLine("Diagonal XYZ = {0:f2}", parallelepiped.CalculateMainDiagonal());
            Console.WriteLine("Diagonal XY = {0:f2}", parallelepiped.CalculateDiagonalXY());
            Console.WriteLine("Diagonal XZ = {0:f2}", parallelepiped.CalculateDiagonalXZ());
            Console.WriteLine("Diagonal YZ = {0:f2}", parallelepiped.CalculateDiagonalYZ());
        }
    }
}
