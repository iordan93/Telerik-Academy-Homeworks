namespace StudentSystemData
{
    using System;
    using System.Data.Entity;
    using StudentSystemData.Migrations;
    using StudentSystemModel;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
            : base("StudentSystem")
        {
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Homework> Homeworks { get; set; }
    }
}
