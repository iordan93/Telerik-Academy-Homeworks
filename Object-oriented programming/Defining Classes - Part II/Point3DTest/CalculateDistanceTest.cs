using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _1._4.Point3D;
using System.Threading;
using System.Globalization;

namespace Point3DTest
{
    [TestClass]
    public class CalculateDistanceTest
    {
        [TestMethod]
        public void CalculateDistance()
        {
            // Fix decimal point issues
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            Point3D point1 = new Point3D(1, 2, 3);
            Point3D point2 = new Point3D(4, 5, 6);
            double distance = CalculateDistance3D.CalculateDistance(point1, point2);
            Assert.AreEqual(Math.Round(distance, 13), 5.1961524227066);

            point1 = new Point3D(1, 2, 3);
            point2 = new Point3D(1, 2, 3);
            distance = CalculateDistance3D.CalculateDistance(point1, point2);
            Assert.AreEqual(distance, 0);
        }
    }
}
