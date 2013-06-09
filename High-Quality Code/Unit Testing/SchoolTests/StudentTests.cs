namespace SchoolTests
{
    using System;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class StudentTests
    {
        [TestInitialize]
        public void ResetStudentIdCounter()
        {
            FieldInfo reset = typeof(IdManager).GetField("currentStudentId", BindingFlags.NonPublic | BindingFlags.Static);
            reset.SetValue(null, 10000);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentConstructorEmptyNameTest()
        {
            Student student = new Student(string.Empty, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentConstructorWhiteSpaceNameTest()
        {
            Student student = new Student("             ", "        ");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentFirstNameWhiteSpaceTest()
        {
            Student student = new Student("        ", "Johns");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void StudentLastNameWhiteSpaceTest()
        {
            Student student = new Student("John", "     ");
        }

        [TestMethod]
        public void StudentNormalTest()
        {
            string firstName = "Stephen";
            string lastName = "Roberts";
            Student student = new Student(firstName, lastName);
            
            Assert.IsTrue(firstName == student.FirstName && lastName == student.LastName);
        }

        [TestMethod]
        public void StudentEqualsTest()
        {
            Student firstStudent = new Student("Peter", "Stephens");

            // Reset the counter to ensure the two IDs will be equal
            this.ResetStudentIdCounter();
            Student secondStudent = new Student("Peter", "Stephens");

            Assert.IsTrue(firstStudent.Equals(secondStudent));
        }

        [TestMethod]
        public void StudentDoesNotEqualTest()
        {
            Student firstStudent = new Student("Peter", "Anderson");
            Student secondStudent = new Student("Maria", "Sanchez");
            Assert.IsFalse(firstStudent.Equals(secondStudent));
        }

        [TestMethod]
        public void StudentDoesNotEqualOtherObjectTest()
        {
            Student peter = new Student("Peter", "Anderson");
            Course myCourse = new Course("My course", peter);

            Assert.IsFalse(peter.Equals(myCourse));
        }
    }
}
