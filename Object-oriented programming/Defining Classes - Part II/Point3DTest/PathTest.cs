using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._4.Point3D;

namespace Point3DTest
{
    [TestClass]
    public class PathTest
    {
        [TestMethod]
        public void PathEmptyConstructor()
        {
            Path path = new Path();
            Assert.AreEqual(path.Length, 0);
        }

        [TestMethod]
        public void PathAdd()
        {
            Path path = new Path(3);
            path.Add(new Point3D());
            path.Add(new Point3D(1, 2, 3));
            path.Add(Point3D.Origin);
            
            for (int i = 0; i < path.Length; i++)
            {
                Console.WriteLine(path.SequenceOfPoints[i]);
            }
            Assert.AreEqual(path.Length, 3);
        }

        [TestMethod]
        public void PathRemove()
        {
            Path path = new Path(3);
            path.Add(new Point3D());
            path.Add(new Point3D(1, 2, 3));
            path.Add(Point3D.Origin);

            path.Remove(new Point3D(1, 2, 3));
            
            for (int i = 0; i < path.Length; i++)
            {
                Console.WriteLine(path.SequenceOfPoints[i]);
            }
            Assert.AreEqual(path.Length, 2);
        }

        [TestMethod]
        public void PathClear()
        {
            Path path = new Path(3);
            path.Add(new Point3D());
            path.Add(new Point3D(1, 2, 3));
            path.Add(Point3D.Origin);

            path.Clear();

            Assert.AreEqual(path.Length, 0);
        }
    }
}
