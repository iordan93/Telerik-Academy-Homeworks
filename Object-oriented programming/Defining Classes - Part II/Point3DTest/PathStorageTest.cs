using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using System.Globalization;
using _1._4.Point3D;

namespace Point3DTest
{
    [TestClass]
    public class PathStorageTest
    {
        /// <note>To pass this unit test, change the visibility of the Parse() method to 'public'</note>
        // TODO: Learn how to test private methods
        //[TestMethod]
        //public void Parse()
        //{
        //    Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        //    Point3D point = PathStorage.Parse("1, 2, 3");
        //    Console.WriteLine(point);
        //    point = PathStorage.Parse("1.56123152, 2.5132542, 3.65451632134");
        //    Console.WriteLine(point);
        //    point = PathStorage.Parse("1.412345354353, 2.3135353863782135, 3.2138538535");
        //    Console.WriteLine(point);
        //}

        [TestMethod]
        public void AddPath()
        {
            Path path = PathStorage.LoadPathFromFile("..\\..\\points.txt");
            foreach (Point3D point in path.SequenceOfPoints)
            {
                Console.WriteLine(point);
            }
        }

        [TestMethod]
        public void SavePath()
        {
            Path path = new Path();
            path.Add(new Point3D(1, 1, 1));
            path.Add(new Point3D(2, 2, 2));
            path.Add(new Point3D(3, 3, 3));
            path.Add(new Point3D(4, 4, 4));
            path.Add(new Point3D(5, 5, 5));
            PathStorage.SavePathToFile(path, "..\\..\\savedPath.txt");
        }
    }
}
