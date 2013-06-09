using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSMData;

namespace GSMUnitTests
{
    // Test the constructors of the Battery class
    [TestClass]
    public class BatteryConstructorsTest
    {
        [TestMethod]
        public void BatteryFull()
        {
            string model="Nokia";
            ushort hoursIdle=3000;
            ushort hoursTalk=48;
            BatteryType type= BatteryType.LiIon;
            Battery battery = new GSMData.Battery(model, hoursIdle, hoursTalk, type);
            Assert.AreEqual(battery.Model, model);
            Assert.AreEqual(battery.HoursIdle, hoursIdle);
            Assert.AreEqual(battery.HoursTalk, hoursTalk);
            Assert.AreEqual(battery.BatType, BatteryType.LiIon);
        }

        [TestMethod]
        public void BatteryOnlyModel()
        {
            string model = "Nokia";
            GSMData.Battery battery = new GSMData.Battery(model);
            Assert.AreEqual(battery.Model, model);
            Assert.AreEqual(battery.HoursIdle, null);
            Assert.AreEqual(battery.HoursTalk, null);
        }

        [TestMethod]
        public void BatteryOptionalParameter()
        {
            string model = "Nokia";
            ushort hoursTalk = 48000;
            GSMData.Battery battery = new GSMData.Battery(model, hoursTalk:hoursTalk);
            Assert.AreEqual(battery.Model, model);
            Assert.AreEqual(battery.HoursIdle, null);
            Assert.AreEqual(battery.HoursTalk, hoursTalk);
        }

        [TestMethod]
        public void BatteryEmpty()
        {
            GSMData.Battery battery = new GSMData.Battery();
            Assert.AreEqual(battery.Model, "");
            Assert.AreEqual(battery.HoursIdle, null);
            Assert.AreEqual(battery.HoursTalk, null);
            Assert.AreEqual(battery.BatType, BatteryType.None);
        }
    }
}
