namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Course
    {
        public const int MaxStudents = 30;

        private List<Student> students = new List<Student>();
        private string name = null;

        public Course(string name)
        {
            this.Name = name;
        }

        public Course(string name, params Student[] students)
            : this(name)
        {
            this.Students.AddRange(students);
        }

        public string Name
        {
            get
            {
                return this.name;
            }

            private set
            {
                // Trimming the value to exclude the case of names containing only spaces
                value = value.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("CourseName", "The name of a course cannot be null, empty, or whitespace.");
                }

                this.name = value;
            }
        }

        public List<Student> Students
        {
            get
            {
                return this.students;
            }
        }

        public void AddStudent(Student student)
        {
            if (this.StudentAlreadyExists(student))
            {
                throw new ArgumentException("The student already exists in this school.");
            }

            if (this.Students.Count >= MaxStudents)
            {
                throw new ArgumentException(string.Format("No more than {0} students are allowed in this course", MaxStudents));
            }

            this.Students.Add(student);
        }

        public void RemoveStudent(Student student)
        {
            bool studentIsFound = false;

            for (int i = 0; i < this.Students.Count; i++)
            {
                if (this.Students[i] == student)
                {
                    studentIsFound = true;
                    this.Students.Remove(student);
                }
            }

            if (!studentIsFound)
            {
                throw new ArgumentException("The student cannot be removed from the course because it does not exist.");
            }
        }

        public override bool Equals(object obj)
        {
            var course = obj as Course;
            if (course != null)
            {
                return this.Name == course.Name;
            }

            return false;
        }

        private bool StudentAlreadyExists(Student student)
        {
            return this.Students.Any(x => x.Equals(student));
        }
    }
}
