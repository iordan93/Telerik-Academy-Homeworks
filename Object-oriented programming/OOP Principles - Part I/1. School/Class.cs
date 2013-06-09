using System;
using System.Collections.Generic;
using System.Text;

namespace _1.School
{
    public class Class : ICommentable
    {
        // Private fields
        private string identifier = string.Empty;
        private string comment;
        private List<Student> students = new List<Student>();
        private List<Teacher> teachers = new List<Teacher>();

        // Public properties to encapsulate the fields
        public string Identifier
        {
            get
            {
                return this.identifier;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.identifier = value;
                }
                else throw new ArgumentException("The identifier of a class must not be empty.");
            }
        }

        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
            set
            {
                this.students = value;
            }
        }

        public List<Teacher> Teachers
        {
            get
            {
                return this.teachers;
            }
            set
            {
                this.teachers = value;
            }
        }

        // Constructor - identifier is required
        public Class(string identifier)
        {
            this.Identifier = identifier;
        }

        // Methods
        // Add a single teacher
        public void AddTeacher(Teacher teacher)
        {
            this.Teachers.Add(teacher);
        }

        // Add many teachers
        public void AddTeachers(params Teacher[] teachers)
        {
            this.Teachers.AddRange(teachers);
        }

        // Remove a teacher
        public void RemoveTeacher(Teacher teacher)
        {
            this.Teachers.Remove(teacher);
        }

        // Add a single student
        public void AddStudent(Student student)
        {
            this.Students.Add(student);
        }

        // Add many students
        public void AddStudents(params Student[] students)
        {
            this.Students.AddRange(students);
        }

        // Remove a student
        public void RemoveStudent(Student student)
        {
            this.Students.Remove(student);
        }

        // Required by ICommentable interface
        public void AddComment(string comment)
        {
            this.Comment = comment;
        }

        // Display information about the class
        public override string ToString()
        {
            StringBuilder classToString = new StringBuilder();
            classToString.AppendFormat("{0} {1} {0}\n", new string('=', 10), this.Identifier);
            classToString.AppendLine("Teachers:");
            foreach (var teacher in this.Teachers)
            {
                classToString.AppendFormat("{0} {1}\n", teacher.FirstName, teacher.LastName);
            }
            classToString.AppendLine("Students:");
            foreach (var student in this.Students)
            {
                classToString.AppendFormat("{0} {1}\n", student.FirstName, student.LastName);
            }
            classToString.AppendFormat("Comment: {0}", this.Comment);
            return classToString.ToString();
        }
    }
}
