namespace StudentsTests.RepositoryTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentsModels;
    using StudentsRepositories;
    using Telerik.JustMock;

    [TestClass]
    public class StudentsRepositoryTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void TestGetAllNoItems()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>();
            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());

            Assert.IsNotNull(studentsRepository);
            Assert.AreEqual(0, studentsRepository.GetAll().Count());
        }

        [TestMethod]
        public void TestGetAllOneItem()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>() { new Student() };
            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());

            Assert.AreEqual(1, studentsRepository.GetAll().Count());
        }

        [TestMethod]
        public void TestGetAllManyItems()
        {
            const int MaxCount = 10;
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>();
            for (int i = 0; i < MaxCount; i++)
            {
                students.Add(new Student()
                {
                    FirstName = "Michael",
                    LastName = "Peterson",
                    Age = 15,
                    Grade = 9,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "Maths",
                            Value = 6.00
                        },
                        new Mark()
                        {
                            Subject = "Physics",
                            Value = 5.99
                        }
                    },
                    School = new School()
                    {
                        Name = "School",
                        Location = "Location"
                    }
                });
            }

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());

            Assert.AreEqual(10, studentsRepository.GetAll().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestGetSingleNoValues()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>();
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).MustBeCalled();
            Mock.Arrange(() => studentsRepository.GetSingle(1)).Returns(students[0]);
        }

        [TestMethod]
        public void TestGetSingleOneValue()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    FirstName = "Michael",
                    LastName = "Peterson"
                }
            };
            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).MustBeCalled();
            Mock.Arrange(() => studentsRepository.GetSingle(1)).Returns(students[0]);

            var actual = studentsRepository.GetSingle(1);
            Assert.AreEqual("Michael", actual.FirstName);
            Assert.AreEqual("Peterson", actual.LastName);
        }

        [TestMethod]
        public void TestGetSingleManyValues()
        {
            const int MaxCount = 10;
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>();
            for (int i = 0; i < MaxCount; i++)
            {
                students.Add(new Student()
                {
                    FirstName = "Michael",
                    LastName = "Peterson",
                    Age = 15,
                    Grade = 9,
                    Marks = new List<Mark>()
                    {
                        new Mark()
                        {
                            Subject = "Maths",
                            Value = 6.00
                        },
                        new Mark()
                        {
                            Subject = "Physics",
                            Value = 5.99
                        }
                    },
                    School = new School()
                    {
                        Name = "School",
                        Location = "Location"
                    }
                });
            }

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).MustBeCalled();
            Mock.Arrange(() => studentsRepository.GetSingle(1)).Returns(students[0]);
            Mock.Arrange(() => studentsRepository.GetSingle(5)).Returns(students[4]);
            Mock.Arrange(() => studentsRepository.GetSingle(7)).Returns(students[6]);
            Mock.Arrange(() => studentsRepository.GetSingle(10)).Returns(students[9]);

            var actualFirst = studentsRepository.GetSingle(1);
            var actualMiddle = studentsRepository.GetSingle(5);
            var actulAnotherMiddle = studentsRepository.GetSingle(7);
            var actualLast = studentsRepository.GetSingle(10);

            Assert.IsNotNull(actualFirst);
            Assert.IsInstanceOfType(actualFirst, typeof(Student));
            Assert.IsNotNull(actualMiddle);
            Assert.IsInstanceOfType(actualMiddle, typeof(Student));
            Assert.IsNotNull(actulAnotherMiddle);
            Assert.IsInstanceOfType(actulAnotherMiddle, typeof(Student));
            Assert.IsNotNull(actualLast);
            Assert.IsInstanceOfType(actualLast, typeof(Student));
        }

        [TestMethod]
        public void TestCreateSingleItem()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>();

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).MustBeCalled();
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).DoInstead((Student s) => { students.Add(s); });

            studentsRepository.Create(new Student() { });

            Assert.AreEqual(1, studentsRepository.GetAll().Count());
        }

        [TestMethod]
        public void TestCreateManyItems()
        {
            const int MaxCount = 10;
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>();

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).MustBeCalled();
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).DoInstead((Student s) => { students.Add(s); });

            for (int i = 0; i < MaxCount; i++)
            {
                studentsRepository.Create(new Student() { });
            }

            Assert.AreEqual(10, studentsRepository.GetAll().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestCreateNullItem()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>();

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).MustBeCalled();
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).DoInstead((Student s) => { students.Add(s); });
            Mock.Arrange(() => studentsRepository.Create(Arg.IsNull<Student>())).Throws<ArgumentNullException>();
            studentsRepository.Create(null);

        }

        [TestMethod]
        public void TestUpdateItem()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>() { new Student() { FirstName = "Michael" } };

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>())).MustBeCalled();
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>()))
                .DoInstead((int i, Student s) => { students[i - 1] = s; });
            studentsRepository.Update(1, new Student()
            {
                FirstName = "Peter"
            });

            Assert.AreEqual("Peter", studentsRepository.GetAll().First().FirstName);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUpdateWithNoItems()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>();

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>())).MustBeCalled();
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>()))
                .DoInstead((int i, Student s) => { students[i - 1] = s; });
            studentsRepository.Update(5, new Student()
            {
                FirstName = "Peter"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestUpdateItemOutOfRange()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>() { new Student(), new Student() };

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>())).MustBeCalled();
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>()))
                .DoInstead((int i, Student s) => { students[i - 1] = s; });
            studentsRepository.Update(5, new Student()
            {
                FirstName = "Peter"
            });
        }

        [TestMethod]
        public void TestDeleteItem()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>() { new Student() { FirstName = "Michael" } };

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Delete(Arg.AnyInt)).MustBeCalled();
            Mock.Arrange(() => studentsRepository.Delete(Arg.AnyInt))
                .DoInstead((int i) => { students.RemoveAt(i - 1); });

            Assert.AreEqual(1, studentsRepository.GetAll().Count());
            
            studentsRepository.Delete(1);

            Assert.AreEqual(0, studentsRepository.GetAll().Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDeleteWithNoItems()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>();

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>())).MustBeCalled();
            Mock.Arrange(() => studentsRepository.Delete(Arg.AnyInt))
                .DoInstead((int i) => { students.RemoveAt(i - 1); }); 
            studentsRepository.Delete(5);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void TestDeleteItemOutOfRange()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();

            List<Student> students = new List<Student>() { new Student(), new Student() };

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>())).MustBeCalled();
            Mock.Arrange(() => studentsRepository.Delete(Arg.AnyInt))
                .DoInstead((int i) => { students.RemoveAt(i - 1); });
            studentsRepository.Delete(5);
        }
    }
}