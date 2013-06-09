using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSMData;

namespace GSMUnitTests
{
    [TestClass]
    public class CallConstructorsTest
    {
        [TestMethod]
        public void CallFull()
        {
            DateTime dateAndTime = new DateTime(2005, 9, 13);
            string dialedNumber = "0878234410";
            TimeSpan duration = new TimeSpan(0, 10, 35);
            Call call = new Call(dateAndTime, dialedNumber, duration);
            Assert.AreEqual(call.DateAndTime, dateAndTime);
            Assert.AreEqual(call.DialedNumber, dialedNumber);
            Assert.AreEqual(call.Duration, duration);
        }

        [TestMethod]
        public void CallEmpty()
        {
            Call call = new Call();
            Assert.AreEqual(call.DateAndTime, new DateTime());
            Assert.AreEqual(call.DialedNumber, null);
            Assert.AreEqual(call.Duration, null);
        }
    }
}
