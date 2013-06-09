using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._4.Point3D;
namespace Point3DTest
{
    [TestClass]
    public class Point3DConstructorsTest
    {
        [TestMethod]
        public void EmptyConstructor()
        {
            Point3D point = new Point3D();
            
            Assert.AreEqual(point.X, 0);
            Assert.AreEqual(point.Y, 0);
            Assert.AreEqual(point.Z, 0);
        }

        [TestMethod]
        public void FullConstructor()
        {
            double x = 5.5412348964564216;
            double y = 54512.54685642154;
            double z = 15656.4565486451231215462131;
            Point3D point = new Point3D(x, y, z);
            
            Assert.AreEqual(point.X, x);
            Assert.AreEqual(point.Y, y);
            Assert.AreEqual(point.Z, z);
        }

        [TestMethod]
        public void PartialConstructor()
        {
            double x = 5.5412348964564216;
            double z = 15656.4565486451231215462131;
            Point3D point = new Point3D(x, z: z);
            
            Assert.AreEqual(point.X, x);
            Assert.AreEqual(point.Y, 0);
            Assert.AreEqual(point.Z, z);
        }

        [TestMethod]
        public void Origin()
        {
            Point3D origin = Point3D.Origin;

            Assert.AreEqual(origin.X, 0);
            Assert.AreEqual(origin.Y, 0);
            Assert.AreEqual(origin.Z, 0);
        }
    }
}
