namespace StudentsData
{
    using System;
    using System.Data.Entity;
    using StudentsModels;

    public class StudentsContext : DbContext
    {
        public StudentsContext()
            : base("StudentsContext")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Student> Students { get; set; }

        public DbSet<School> Schools { get; set; }
        
        public DbSet<Mark> Marks { get; set; }   
    }
}
