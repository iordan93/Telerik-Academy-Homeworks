using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using StudentsModels;
using StudentsData;
using StudentsRepositories;

namespace StudentsServices.Controllers
{
    public class StudentsController : ApiController
    {
        private readonly IRepository<Student> studentsRepository;

        public StudentsController(IRepository<Student> studentsRepository)
        {
            this.studentsRepository = studentsRepository;
        }

        // GET api/Students
        public IEnumerable<StudentModel> GetStudents()
        {
            var students = this.studentsRepository.GetAll()
                             .Include(s => s.Marks)
                             .ToList();
            List<StudentModel> studentModels = new List<StudentModel>();
            foreach (var student in students)
            {
                studentModels.Add(ModelConverter.ConvertStudent(student));
            }

            return studentModels;
        }

        // GET api/Students/5
        public StudentModel GetStudent(int id)
        {
            Student student = this.studentsRepository.GetAll()
                                .Include(s => s.Marks)
                                .FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return ModelConverter.ConvertStudent(student);
        }

        // GET api/students?subject=math&value=5.00
        public IEnumerable<StudentModel> GetStudentBySubjectAndMark(string subject, double value)
        {
            var students = this.studentsRepository.GetAll()
                             .SelectMany(s => s.Marks)
                             .Where(m => m.Subject == subject &&
                                         m.Value > value)
                             .Select(m => m.Student)
                             .Include(s => s.Marks);

            List<StudentModel> studentModels = new List<StudentModel>();
            foreach (var student in students)
            {
                studentModels.Add(ModelConverter.ConvertStudent(student));
            }

            return studentModels;
        }

        // POST api/Students
        public HttpResponseMessage PostStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                StudentModel studentModel;
                Student repositoryStudent = this.studentsRepository.GetAll()
                                              .FirstOrDefault(s => s.FirstName == student.FirstName &&
                                                                   s.LastName == student.LastName &&
                                                                   s.Grade == student.Grade &&
                                                                   s.Age == student.Age &&
                                                                   s.School.Name == student.School.Name);
                if (repositoryStudent != null)
                {
                    studentModel = ModelConverter.ConvertStudent(repositoryStudent);
                }
                else
                {
                    this.studentsRepository.Create(student);
                    studentModel = ModelConverter.ConvertStudent(student);
                }

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, studentModel);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = student.Id }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }
    }
}