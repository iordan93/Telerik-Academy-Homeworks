namespace SchoolTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstructorEmptyNameTest()
        {
            Course course = new Course(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstructorWhiteSpaceNameTest()
        {
            Course course = new Course("                     ");
        }

        [TestMethod]
        public void CourseConstructorNameOnlyTest()
        {
            string courseName = "My long long long long and very very long course name going on and on forever";            
            
            Course course = new Course("My long long long long and very very long course name going on and on forever");
            
            Assert.AreEqual(courseName, course.Name);
        }

        [TestMethod]
        public void CourseConstructorAllParametersTest()
        {
            Student lily = new Student("Lily", "Peters");
            Student michelle = new Student("Michelle", "Brown");
            
            Course course = new Course("My new course", lily, michelle, new Student("John", "O'Sullivan"));
            
            Assert.AreEqual(3, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CourseConstructorInvalidStudentTest()
        {
            Student lily = new Student("Lily", "Peters");
            Student michelle = new Student("Michelle", "Brown");

            Course course = new Course("My new course", lily, michelle, new Student(string.Empty, string.Empty));
        }

        [TestMethod]
        public void AddStudentTest()
        {
            Student lily = new Student("Lily", "Peters");
            Student michelle = new Student("Michelle", "Brown");
            Course course = new Course("My course name", lily);

            course.AddStudent(michelle);

            Assert.IsTrue(course.Students.Contains(michelle));
            Assert.AreEqual(2, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingStudentTest()
        {
            Course course = new Course("My course name");
            Student peter = new Student("Peter", "Ronalds");

            course.AddStudent(peter);
            course.AddStudent(peter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddTooManyStudentsTest()
        {
            Course course = new Course("My course name");
            Student peter = new Student("Peter", "Ronalds");

            for (int i = 0; i < 31; i++)
            {
                course.AddStudent(peter);
            }
        }

        [TestMethod]
        public void RemoveStudentTest()
        {
            Course course = new Course("My course name");
            Student daniel = new Student("Daniel", "Johns");

            course.AddStudent(daniel);
            course.AddStudent(new Student("Peter", "Nicholas"));
            course.RemoveStudent(daniel);

            Assert.IsFalse(course.Students.Contains(daniel));
            Assert.AreEqual(1, course.Students.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RemoveNonExistingStudentTest()
        {
            Course course = new Course("My course name");
            Student daniel = new Student("Daniel", "Johns");
            
            course.RemoveStudent(daniel);
        }

        [TestMethod]
        public void CourseEqualsTest()
        {
            Student peter = new Student("Peter", "Anderson");
            Course firstCourse = new Course("My course", peter);
            Course secondCourse = new Course("My course");

            Assert.IsTrue(firstCourse.Equals(secondCourse));
        }

        [TestMethod]
        public void CourseDoesNotEqualTest()
        {
            Student peter = new Student("Peter", "Anderson");
            Course firstCourse = new Course("My course", peter);
            Course secondCourse = new Course("My other course", peter);

            Assert.IsFalse(firstCourse.Equals(secondCourse));
        }

        [TestMethod]
        public void CourseDoesNotEqualOtherObjectTest()
        {
            Student peter = new Student("Peter", "Anderson");
            Course firstCourse = new Course("My course", peter);

            Assert.IsFalse(firstCourse.Equals(peter));
        }
    }
}