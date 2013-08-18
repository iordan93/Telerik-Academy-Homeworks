namespace StudentsModels
{
    using System;
    using System.Collections.Generic;

    public class StudentModel
    {
        public StudentModel()
        {
            this.Marks = new HashSet<MarkModel>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int Age { get; set; }

        public int Grade { get; set; }

        public ICollection<MarkModel> Marks { get; set; }
    }
}
