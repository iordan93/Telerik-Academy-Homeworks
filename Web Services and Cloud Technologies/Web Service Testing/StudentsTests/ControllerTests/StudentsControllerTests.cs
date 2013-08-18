namespace StudentsTests.ControllerTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Web;
    using System.Web.Http;
    using System.Web.Http.Controllers;
    using System.Web.Http.Hosting;
    using System.Web.Http.Routing;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using StudentsModels;
    using StudentsRepositories;
    using StudentsServices.Controllers;
    using Telerik.JustMock;

    [TestClass]
    public class StudentsControllerTests
    {
        [TestInitialize]
        public void InitializeTest()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        }

        [TestMethod]
        public void TestGetAllStudentsWithNoStudents()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();
            List<Student> students = new List<Student>();
            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).Returns((int i) => students[i]);
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).DoInstead((Student s) => { students.Add(s); });
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>()))
                            .DoInstead((int i, Student s) => { students[i - 1] = s; });
            Mock.Arrange(() => studentsRepository.Delete(Arg.AnyInt))
                .DoInstead((int i) => { students.RemoveAt(i - 1); });

            StudentsController studentsController = new StudentsController(studentsRepository);
            var allStudents = studentsController.GetStudents();

            Assert.IsNotNull(allStudents);
            Assert.AreEqual(0, allStudents.Count());
        }

        [TestMethod]
        public void TestGetAllStudentsWithSomeStudents()
        {
            const int MaxCount = 5;

            var studentsRepository = Mock.Create<IRepository<Student>>();
            List<Student> students = new List<Student>();
            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).Returns((int i) => students[i]);
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).DoInstead((Student s) => { students.Add(s); });
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>()))
                            .DoInstead((int i, Student s) => { students[i - 1] = s; });
            Mock.Arrange(() => studentsRepository.Delete(Arg.AnyInt))
                .DoInstead((int i) => { students.RemoveAt(i - 1); });

            StudentsController studentsController = new StudentsController(studentsRepository);
            for (int i = 0; i < MaxCount; i++)
            {
                studentsRepository.Create(new Student());
            }

            var allStudents = studentsController.GetStudents();

            Assert.IsNotNull(allStudents);
            Assert.AreEqual(5, allStudents.Count());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void TestGetSingleStudentsWithNoStudents()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();
            List<Student> students = new List<Student>();
            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).Returns((int i) => students[i]);
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).DoInstead((Student s) => { students.Add(s); });
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>()))
                            .DoInstead((int i, Student s) => { students[i - 1] = s; });
            Mock.Arrange(() => studentsRepository.Delete(Arg.AnyInt))
                .DoInstead((int i) => { students.RemoveAt(i - 1); });

            StudentsController studentsController = new StudentsController(studentsRepository);

            studentsController.GetStudent(1);
        }

        [TestMethod]
        [ExpectedException(typeof(HttpResponseException))]
        public void TestGetSingleStudentsWithSomeStudents()
        {
            const int MaxCount = 5;

            var studentsRepository = Mock.Create<IRepository<Student>>();
            List<Student> students = new List<Student>();
            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).Returns((int i) => students[i]);
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).DoInstead((Student s) => { students.Add(s); });
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>()))
                            .DoInstead((int i, Student s) => { students[i - 1] = s; });
            Mock.Arrange(() => studentsRepository.Delete(Arg.AnyInt))
                .DoInstead((int i) => { students.RemoveAt(i - 1); });

            StudentsController studentsController = new StudentsController(studentsRepository);
            this.SetupController(studentsController);

            for (int i = 0; i < MaxCount; i++)
            {
                studentsRepository.Create(new Student());
            }

            var middleStudent = studentsController.GetStudent(3);

            Assert.IsNotNull(middleStudent);
        }

        [TestMethod]
        public void TestPostStudent()
        {
            var studentsRepository = Mock.Create<IRepository<Student>>();
            List<Student> students = new List<Student>();
            Mock.Arrange(() => studentsRepository.GetAll()).Returns(students.AsQueryable());
            Mock.Arrange(() => studentsRepository.GetSingle(Arg.AnyInt)).Returns((int i) => students[i]);
            Mock.Arrange(() => studentsRepository.Create(Arg.IsAny<Student>())).DoInstead((Student s) => { students.Add(s); });
            Mock.Arrange(() => studentsRepository.Update(Arg.AnyInt, Arg.IsAny<Student>()))
                            .DoInstead((int i, Student s) => { students[i - 1] = s; });
            Mock.Arrange(() => studentsRepository.Delete(Arg.AnyInt))
                .DoInstead((int i) => { students.RemoveAt(i - 1); });

            StudentsController studentsController = new StudentsController(studentsRepository);
            this.SetupController(studentsController);

            HttpResponseMessage message = studentsController.PostStudent(new Student());

            Assert.AreEqual(HttpStatusCode.Created, message.StatusCode);
            Assert.IsNotNull(message.Content.ReadAsStringAsync().Result);
        }

        private void SetupController(ApiController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost/api/students");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "categories");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }
    }
}
