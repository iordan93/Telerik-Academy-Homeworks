namespace StudentsModels
{
    using System;
    using System.Collections.Generic;

    public class SchoolModel
    {
        public SchoolModel()
        {
            this.Students = new HashSet<StudentModel>();
        }

        public string Name { get; set; }

        public string Location { get; set; }

        public ICollection<StudentModel> Students { get; set; }
    }
}
