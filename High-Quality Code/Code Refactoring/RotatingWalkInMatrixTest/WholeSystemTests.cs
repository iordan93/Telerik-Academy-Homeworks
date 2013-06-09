namespace RotatingWalkInMatrixTest
{
    using System;
    using System.IO;
    using System.Text;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WholeSystemTests
    {
        [TestMethod]
        public void TestProgramWithMatrixSize1()
        {
            StreamReader consoleIn = new StreamReader("../../TestFiles/test.size1.in.txt");
            Console.SetIn(consoleIn);
            StreamWriter consoleOut = new StreamWriter("../../TestFiles/test.size1.out.txt");
            Console.SetOut(consoleOut);
            RotatingWalkInMatrix.RotatingWalkInMatrix.Main();
            consoleIn.Close();
            consoleOut.Close();

            StreamReader outputStream = new StreamReader("../../TestFiles/test.size1.out.txt");
            string actualMatrix = string.Empty;
            using (outputStream)
            {
                actualMatrix = outputStream.ReadToEnd();
            }

            StringBuilder expectedMatrix = new StringBuilder();
            string beginningOfOutput = "Enter a positive number ";
            expectedMatrix.AppendLine(beginningOfOutput);
            expectedMatrix.AppendLine("   1");

            Assert.AreEqual(actualMatrix, expectedMatrix.ToString());
        }

        [TestMethod]
        public void TestProgramWithMatrixSize5()
        {
            StreamReader consoleIn = new StreamReader("../../TestFiles/test.size6.in.txt");
            Console.SetIn(consoleIn);
            StreamWriter consoleOut = new StreamWriter("../../TestFiles/test.size6.out.txt");
            Console.SetOut(consoleOut);
            RotatingWalkInMatrix.RotatingWalkInMatrix.Main();
            consoleIn.Close();
            consoleOut.Close();

            StreamReader outputStream = new StreamReader("../../TestFiles/test.size6.out.txt");
            string actualMatrix = string.Empty;
            using (outputStream)
            {
                actualMatrix = outputStream.ReadToEnd();
            }

            StringBuilder expectedMatrix = new StringBuilder();
            string beginningOfOutput = "Enter a positive number ";
            expectedMatrix.AppendLine(beginningOfOutput);
            expectedMatrix.AppendLine("   1  16  17  18  19  20");
            expectedMatrix.AppendLine("  15   2  27  28  29  21");
            expectedMatrix.AppendLine("  14  31   3  26  30  22");
            expectedMatrix.AppendLine("  13  36  32   4  25  23");
            expectedMatrix.AppendLine("  12  35  34  33   5  24");
            expectedMatrix.AppendLine("  11  10   9   8   7   6");

            Assert.AreEqual(actualMatrix, expectedMatrix.ToString());
        }

        [TestMethod]
        public void TestProgramWithMatrixSize10()
        {
            StreamReader consoleIn = new StreamReader("../../TestFiles/test.size10.in.txt");
            Console.SetIn(consoleIn);
            StreamWriter consoleOut = new StreamWriter("../../TestFiles/test.size10.out.txt");
            Console.SetOut(consoleOut);
            RotatingWalkInMatrix.RotatingWalkInMatrix.Main();
            consoleIn.Close();
            consoleOut.Close();

            StreamReader outputStream = new StreamReader("../../TestFiles/test.size10.out.txt");
            string actualMatrix = string.Empty;
            using (outputStream)
            {
                actualMatrix = outputStream.ReadToEnd();
            }

            StringBuilder expectedMatrix = new StringBuilder();
            string beginningOfOutput = "Enter a positive number ";
            expectedMatrix.AppendLine(beginningOfOutput);
            expectedMatrix.AppendLine("   1  28  29  30  31  32  33  34  35  36");
            expectedMatrix.AppendLine("  27   2  51  52  53  54  55  56  57  37");
            expectedMatrix.AppendLine("  26  73   3  50  66  67  68  69  58  38");
            expectedMatrix.AppendLine("  25  90  74   4  49  65  72  70  59  39");
            expectedMatrix.AppendLine("  24  89  91  75   5  48  64  71  60  40");
            expectedMatrix.AppendLine("  23  88  99  92  76   6  47  63  61  41");
            expectedMatrix.AppendLine("  22  87  98 100  93  77   7  46  62  42");
            expectedMatrix.AppendLine("  21  86  97  96  95  94  78   8  45  43");
            expectedMatrix.AppendLine("  20  85  84  83  82  81  80  79   9  44");
            expectedMatrix.AppendLine("  19  18  17  16  15  14  13  12  11  10");

            Assert.AreEqual(actualMatrix, expectedMatrix.ToString());
        }        
    }
}
