namespace StudentsModels
{
    using System;
    using System.Collections.Generic;

    public class Student
    {
        public Student()
        {
            this.Marks = new HashSet<Mark>();
        }

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public ICollection<Mark> Marks { get; set; }

        public virtual School School { get; set; }
    }
}
