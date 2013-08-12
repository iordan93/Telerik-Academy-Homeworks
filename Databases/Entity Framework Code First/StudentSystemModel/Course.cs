namespace StudentSystemModel
{
    using System;
    using System.Collections.Generic;

    public class Course
    {
        private ICollection<CourseMaterial> materials;

        private ICollection<Student> students;

        public Course()
        {
            this.materials = new HashSet<CourseMaterial>();
            this.students = new HashSet<Student>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<CourseMaterial> Materials
        {
            get
            {
                return this.materials;
            }

            set
            {
                this.materials = value;
            }
        }

        public virtual ICollection<Student> Students
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
    }
}
