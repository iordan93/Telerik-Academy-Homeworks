namespace StudentsTests.IntegrationTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentsModels;
    using StudentsRepositories;
    using StudentsServices.Controllers;
    using Telerik.JustMock;

    [TestClass]
    public class StudentsControllerIntegrationTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            var type = typeof(StudentsController);
        }

        [TestMethod]
        public void TestGetAllStudents()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();
            var students = new List<Student>();
            students.Add(new Student()
            {
                FirstName = "Michael"
            });

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(() => students.AsQueryable());

            var server = new InMemoryHttpServer<Student>("http://localhost/", studentsRepository);

            var response = server.CreateGetRequest("api/students");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestGetExistingStudents()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();
            var students = new List<Student>();
            students.Add(new Student()
            {
                Id = 1,
                FirstName = "Michael"
            });
            students.Add(new Student()
            {
                Id = 2,
                FirstName = "Peter"
            });

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(() => students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).Returns((int i) => students[i - 1]);

            var server = new InMemoryHttpServer<Student>("http://localhost/", studentsRepository);

            var firstResponse = server.CreateGetRequest("api/students/1");
            var secondResponse = server.CreateGetRequest("api/students/2");

            Assert.AreEqual(HttpStatusCode.OK, firstResponse.StatusCode);
            Assert.IsNotNull(firstResponse.Content);
            Assert.AreEqual(HttpStatusCode.OK, secondResponse.StatusCode);
            Assert.IsNotNull(secondResponse.Content);
        }

        [TestMethod]
        public void TestGetNonexistingStudent()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();
            var students = new List<Student>();
            students.Add(new Student()
            {
                Id = 1,
                FirstName = "Michael"
            });
            students.Add(new Student()
            {
                Id = 2,
                FirstName = "Peter"
            });

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(() => students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).Returns((int i) => students[i - 1]);

            var server = new InMemoryHttpServer<Student>("http://localhost/", studentsRepository);

            var response = server.CreateGetRequest("api/students/5");

            Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
            Assert.IsNull(response.Content);
        }

        [TestMethod]
        public void TestGetStudentBySubjectAndMark()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();
            var students = new List<Student>();
            students.Add(new Student()
            {
                Id = 1,
                FirstName = "Michael",
                LastName = "Michaelson",
                Age = 15,
                Grade = 9,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subject = "Maths",
                        Value = 5
                    },
                    new Mark()
                    {
                        Subject = "Physics",
                        Value = 5
                    }
                }
            });
            students.Add(new Student()
            {
                Id = 2,
                FirstName = "Peter",
                LastName = "Peterson",
                Age = 15,
                Grade = 9,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subject = "Maths",
                        Value = 3
                    },
                    new Mark()
                    {
                        Subject = "Physics",
                        Value = 4
                    }
                }
            });

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(() => students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).Returns((int i) => students[i - 1]);

            var server = new InMemoryHttpServer<Student>("http://localhost/", studentsRepository);

            var response = server.CreateGetRequest("api/students?subject=maths&value=5.00");
            Console.WriteLine(response.Content.ReadAsStringAsync().Result);
            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsNotNull(response.Content);
        }

        [TestMethod]
        public void TestPostStudent()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();
            var students = new List<Student>();
            students.Add(new Student()
            {
                FirstName = "Michael"
            });

            Mock.Arrange(() => studentsRepository.GetAll()).Returns(() => students.AsQueryable());
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).DoInstead((Student s) => { students.Add(s); });

            var server = new InMemoryHttpServer<Student>("http://localhost/", studentsRepository);

            var response = server.CreatePostRequest("api/students", new Student() { FirstName = "Michael", LastName = "Peterson" });

            Assert.AreEqual(HttpStatusCode.Created, response.StatusCode);
            Assert.IsNotNull(response.Content);
            Assert.AreEqual(2, studentsRepository.GetAll().Count());
        }
    }
}