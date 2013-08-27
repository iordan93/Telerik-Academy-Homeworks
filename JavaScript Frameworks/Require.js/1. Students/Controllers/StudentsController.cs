using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using _1.Students.Models;

namespace _1.StudentsServices.Controllers
{
    public class StudentsController : ApiController
    {
        private static List<Student> students = new List<Student>()
        {
            new Student()
            {
                Id = 1,
                FirstName = "Doncho",
                LastName = "Minkov",
                Age = 16,
                Grade = 10,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subject = "Math",
                        Score = 4
                    },
                    new Mark()
                    {
                        Subject = "JavaScript",
                        Score = 6
                    }
                }
            },
            new Student()
            {
                Id = 2,
                FirstName = "Nikolay",
                LastName = "Kostov",
                Age = 18,
                Grade = 12,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subject = "MVC",
                        Score = 6
                    },
                    new Mark()
                    {
                        Subject = "JavaScript",
                        Score = 5
                    }
                }
            },
            new Student()
            {
                Id = 3,
                FirstName = "Ivaylo",
                LastName = "Kendov",
                Age = 15,
                Grade = 9,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subject = "OOP",
                        Score = 4
                    },
                    new Mark()
                    {
                        Subject = "C#",
                        Score = 6
                    }
                }
            },
            new Student()
            {
                Id = 4,
                FirstName = "Svetlin",
                LastName = "Nakov",
                Age = 17,
                Grade = 11,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subject = "Unit Testing",
                        Score = 5
                    },
                    new Mark()
                    {
                        Subject = "WPF",
                        Score = 6
                    }
                }
            },
            new Student()
            {
                Id = 5,
                FirstName = "Asya",
                LastName = "Georgieva",
                Age = 15,
                Grade = 9,
                Marks = new List<Mark>()
                {
                    new Mark()
                    {
                        Subject = "Automation Testing",
                        Score = 6
                    },
                    new Mark()
                    {
                        Subject = "Manual Testing",
                        Score = 4
                    }
                }
            },
            new Student()
            {
                Id = 6,
                FirstName = "Georgi",
                LastName = "Georgiev",
                Age = 14,
                Grade = 8
            }
        };

        public HttpResponseMessage GetAllStudents()
        {
            return this.Request.CreateResponse(HttpStatusCode.OK, students);
        }

        public HttpResponseMessage GetStudentMarks(int id)
        {
            try
            {
                return this.Request.CreateResponse(HttpStatusCode.OK, students[id - 1].Marks ?? new List<Mark>());
            }
            catch (Exception ex)
            {
                return this.Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no student with the given ID.");
            }
        }
    }
}