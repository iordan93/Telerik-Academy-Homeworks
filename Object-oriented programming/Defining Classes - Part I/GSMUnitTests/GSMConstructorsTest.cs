using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GSMData;

namespace GSMUnitTests
{
    // Test the constructors of the GSM class
    [TestClass]
    public class GSMConstructorsTest
    {
        [TestMethod]
        public void GSMFull()
        {
            string model = "3310";
            string manufacturer = "Nokia";
            decimal price = 220;
            string owner = "Pesho";
            GSM gsm = new GSMData.GSM(manufacturer, model, new Battery("Nokia", 3000, 20), new Display(5.5, 16000000), price, owner);
            Assert.AreEqual(gsm.Model, model);
            Assert.AreEqual(gsm.Manufacturer, manufacturer);
            Assert.AreEqual(gsm.Price, price);
            Assert.AreEqual(gsm.Owner, owner);
        }

        [TestMethod]
        public void GSMOnlyRequired()
        {
            string model = "Galaxy S3";
            string manufacturer = "Samsung";
            GSMData.GSM gsm = new GSMData.GSM(manufacturer, model, new Battery(), new Display());
            Assert.AreEqual(gsm.Model, model);
            Assert.AreEqual(gsm.Manufacturer, manufacturer);
            Assert.AreEqual(gsm.Price, 0.0M);
            Assert.AreEqual(gsm.Owner, null);
        }

        [TestMethod]
        public void GSMSomeFields()
        {
            string model = "This is a really long, long, long, long model name";
            string manufacturer = "This is a really long, long, long, long manufacturer name";
            decimal price = 220M;
            GSM gsm = new GSMData.GSM(manufacturer, model, price: price);
            Assert.AreEqual(gsm.Model, model);
            Assert.AreEqual(gsm.Manufacturer, manufacturer);
            Assert.AreEqual(gsm.Price, 220);
            Assert.AreEqual(gsm.Owner, null);

            GSM gsm2 = new GSMData.GSM(model, manufacturer, "Me");
            Assert.AreEqual(gsm2.Price, 0);
            Assert.AreEqual(gsm2.Owner, "Me");
        }

        [TestMethod]
        public void GSMEmpty()
        {

            GSM gsm = new GSMData.GSM();
            Assert.AreEqual(gsm.Model, "");
            Assert.AreEqual(gsm.Manufacturer, "");
            Assert.AreEqual(gsm.Battery, null);
            Assert.AreEqual(gsm.Price, 0);
            Assert.AreEqual(gsm.Owner, null);
        }
    }
}
