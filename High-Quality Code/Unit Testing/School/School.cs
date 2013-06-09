namespace SchoolSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class School
    {   
        private readonly List<Course> courses = new List<Course>();

        private string name = null;

        public School(string name)
        {
            this.Name = name;
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
                    throw new ArgumentNullException("Name", "The name of a school cannot be null, empty, or whitespace.");
                }

                this.name = value;
            }
        }

        public List<Course> Courses
        {
            get
            {
                return this.courses;
            }
        }

        public void AddCourse(Course course)
        {
            if (this.CourseAlreadyExists(course))
            {
                throw new ArgumentException("The course already exists in this school.");
            }

            this.Courses.Add(course);
        }

        public void RemoveCourse(Course course)
        {
            bool courseIsFound = false;

            for (int i = 0; i < this.Courses.Count; i++)
            {
                if (this.Courses[i] == course)
                {
                    courseIsFound = true;
                    this.Courses.Remove(course);
                }
            }

            if (!courseIsFound)
            {
                throw new ArgumentException("The course cannot be removed from the school because it does not exist.");
            }
        }

        private bool CourseAlreadyExists(Course course)
        {
            return this.Courses.Any(x => x.Equals(course));
        }
    }
}