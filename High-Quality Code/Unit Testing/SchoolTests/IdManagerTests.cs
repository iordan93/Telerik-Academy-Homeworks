namespace SchoolTests
{
    using System;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class IdManagerTests
    {
        [TestInitialize]
        public void ResetStudentIdCounter()
        {
            FieldInfo reset = typeof(IdManager).GetField("currentStudentId", BindingFlags.NonPublic | BindingFlags.Static);
            reset.SetValue(null, IdManager.MinStudentId);
        }

        [TestMethod]
        public void StudentIdCounterTest()
        {
            Student student = new Student("Sophie", "Norman");
            int increment = 10;

            // Create different instances and show the last Student ID
            for (int i = 0; i < increment; i++)
            {
                student = new Student("Sophie", "Norman");
            }

            Assert.AreEqual(IdManager.MinStudentId + increment, student.Id);
        }

        [TestMethod]
        public void StudentMaxIdTest()
        {
            Student student = new Student("Sophie", "Norman");
            int increment = IdManager.MaxStudentId - IdManager.MinStudentId;

            for (int i = 0; i < increment; i++)
            {
                student = new Student("Sophie", "Norman");
            }

            Assert.AreEqual(IdManager.MinStudentId + increment, student.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentIdOverflowTopTest()
        {
            Student student = new Student("Sophie", "Norman");
            int increment = IdManager.MaxStudentId - IdManager.MinStudentId + 1;

            for (int i = 0; i < increment; i++)
            {
                student = new Student("Sophie", "Norman");
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void StudentIdOverflowBottomTest()
        {
            // Change the value of the ID counter to be lower than the allowed minimum
            FieldInfo reset = typeof(IdManager).GetField("currentStudentId", BindingFlags.NonPublic | BindingFlags.Static);
            reset.SetValue(null, 1000);

            Student student = new Student("Sophie", "Norman");
        }
    }
}
