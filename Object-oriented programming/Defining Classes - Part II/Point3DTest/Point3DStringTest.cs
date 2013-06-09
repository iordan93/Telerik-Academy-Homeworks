using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._4.Point3D;

namespace Point3DTest
{
    [TestClass]
    public class Point3DStringTest
    {
        [TestMethod]
        public void EmptyConstructorString()
        {
            Point3D point = new Point3D();

            Assert.AreEqual(point.ToString(), "(0; 0; 0)");
        }

        [TestMethod]
        public void FullConstructorString()
        {
            double x = 5.5412348964564216;
            double y = 54512.54685642154;
            double z = 15656.4565486451231215462131;
            Point3D point = new Point3D(x, y, z);

            Assert.AreEqual(point.ToString(), String.Format("({0}; {1}; {2})", x, y, z));
        }

        [TestMethod]
        public void PartialConstructorString(string d)
        {
            double x = 5.5412348964564216;
            double z = 15656.4565486451231215462131;
            Point3D point = new Point3D(x, z: z);

            Assert.AreEqual(point.ToString(), String.Format("({0}; 0; {1})", x, z));
        }

        [TestMethod]
        public void OriginString()
        {
            Point3D origin = Point3D.Origin;

            Assert.AreEqual(origin.ToString(), "(0; 0; 0)");
        }
    }
}
