namespace StudentsModels
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    [KnownType(typeof(Student))]
    public class School
    {
        public School()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Location { get; set; }

        public ICollection<Student> Students { get; set; }
    }
}