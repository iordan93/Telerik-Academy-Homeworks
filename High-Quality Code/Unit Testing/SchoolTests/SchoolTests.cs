namespace SchoolTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SchoolSystem;

    [TestClass]
    public class SchoolTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolConstructorEmptyNameTest()
        {
            School school = new School(string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SchoolConstructorWhiteSpaceNameTest()
        {
            School school = new School("       ");
        }

        [TestMethod]
        public void SchoolConstructorTest()
        {
            School school = new School("My school");
            string expectedSchoolName = "My school";
            Assert.AreEqual(expectedSchoolName, school.Name);
        }

        [TestMethod]
        public void AddCourseWithNameOnlyTest()
        {
            School school = new School("My school");
            Course course = new Course("My course name");
            
            school.AddCourse(course);
            
            Assert.IsTrue(school.Courses.Contains(course));
        }

        [TestMethod]
        public void AddFullCourseInfoTest()
        {
            School school = new School("My school");
            Student student1 = new Student("John", "Johnson");
            Student student2 = new Student("David", "Michaels");
            Course course = new Course("My course name", student1, student2);
            
            school.AddCourse(course);

            Assert.IsTrue(school.Courses[0].Students.Contains(student1));
            Assert.IsTrue(school.Courses[0].Students.Contains(student2));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingCourseTest()
        {
            School school = new School("My school");
            Course course = new Course("My course name");

            school.AddCourse(course);
            school.AddCourse(course);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AddExistingCourseByValueTest()
        {
            School school = new School("My school");
            Course course = new Course("My course name");

            school.AddCourse(course);
            school.AddCourse(new Course("My course name"));
        }

        [TestMethod]
        public void RemoveCourseTest()
        {
            School school = new School("My school");
            Course course = new Course("My course name");

            school.AddCourse(course);
            school.RemoveCourse(course);
            Assert.AreEqual(0, school.Courses.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]        
        public void RemoveNonExistingCourseTest()
        {
            School school = new School("My school");
            Course course = new Course("My course name");
            Course nonExistingCourse = new Course("Not existing course");

            school.AddCourse(course);
            school.RemoveCourse(nonExistingCourse);
        }
    }
}