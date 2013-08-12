namespace StudentSystemData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using StudentSystemModel;

    public sealed class Configuration : DbMigrationsConfiguration<StudentSystemContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(StudentSystemContext studentSystem)
        {
            var michael = new Student() { FirstName = "Michael", LastName = "James", FacultyNumber = 50000 };
            var stephanie = new Student() { FirstName = "Stephanie", LastName = "Sevenson", FacultyNumber = 15866 };
            studentSystem.Students.AddOrUpdate(michael);
            studentSystem.Students.AddOrUpdate(stephanie);

            var maths = new Course() { Name = "Maths", Description = "Mathematics course" };
            var physics = new Course() { Name = "Physics", Description = "Physics course" };
            maths.Students.Add(michael);
            maths.Students.Add(stephanie);
            physics.Students.Add(michael);
            var materials = new CourseMaterial[] 
            {
                new CourseMaterial() { Title = "Math 101", Content = "http://math101.com" },
                new CourseMaterial() { Title = "Physics 200", Content = "http://physics200.com" }
            };
            maths.Materials.Add(materials[0]);
            physics.Materials.Add(materials[1]);
            studentSystem.Courses.AddOrUpdate(maths);
            studentSystem.Courses.AddOrUpdate(physics);

            var mathsHomework = new Homework()
            {
                Course = maths,
                Content = new HomeworkContent() 
                {
                    Heading = "First homework",
                    Content = "No content here"
                },
                Student = stephanie, 
                TimeSent = new DateTime(2013, 3, 8)
            };
            studentSystem.Homeworks.AddOrUpdate(mathsHomework);

            studentSystem.SaveChanges();
        }
    }
}