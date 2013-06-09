using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GSMUnitTests
{
    // Test the constructors of the Battery class
    [TestClass]
    public class DisplayConstructorsTest
    {
        [TestMethod]
        public void DisplayFull()
        {
            double size = 5.5;
            int colours = 16000000;
            GSMData.Display display = new GSMData.Display(size, colours);
            Assert.AreEqual(display.Size, size);
            Assert.AreEqual(display.NumberOfColours, colours);
        }
        [TestMethod]
        public void DisplayPartial()
        {
            double size = 5.5;
            int colours = 16000000;
            GSMData.Display display1 = new GSMData.Display(size: size);
            Assert.AreEqual(display1.Size, size);
            Assert.AreEqual(display1.NumberOfColours, null);

            GSMData.Display display2 = new GSMData.Display(numberofColours: colours);
            Assert.AreEqual(display2.Size, null);
            Assert.AreEqual(display2.NumberOfColours, colours);
        }

        [TestMethod]
        public void DisplayEmpty()
        {
            GSMData.Display display = new GSMData.Display();
            Assert.AreEqual(display.Size, null);
            Assert.AreEqual(display.NumberOfColours, null);
        }
    }
}
