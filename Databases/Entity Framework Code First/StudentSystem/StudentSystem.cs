namespace StudentSystem
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using StudentSystemData;
    using StudentSystemData.Migrations;
    using StudentSystemModel;

    public class StudentSystem
    {
        public static void Main()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentSystemContext, Configuration>());

            using (var studentSystem = new StudentSystemContext())
            {
                Console.WriteLine("Inital seeding test:");
                Console.WriteLine(studentSystem.Students.First().FirstName);
                Console.WriteLine(studentSystem.Homeworks.First().Student.FacultyNumber);
                Console.WriteLine(studentSystem.Courses.First().Materials.First().Title);

                var peter = new Student() { FirstName = "Peter", LastName = "Peterson", FacultyNumber = 45678 };
                AddStudent(studentSystem, peter);
                Console.WriteLine("Adding new student test:");
                Console.WriteLine(studentSystem.Students.Where(s => s.FacultyNumber == 45678).First().FirstName);

                var electronics = new Course() { Name = "Electronics" };
                electronics.Students.Add(peter);
                AddCourse(studentSystem, electronics);
                Console.WriteLine("Adding new course test:");
                Console.WriteLine(studentSystem.Courses.Where(c => c.Name == "Electronics").First().Students.First().FirstName);

                AddHomework(
                    studentSystem,
                    new Homework()
                    {
                        Content = new HomeworkContent()
                        {
                            Heading = "Not found",
                            Content = "404 Homework Not Found"
                        },
                        Course = electronics,
                        Student = peter,
                        TimeSent = new DateTime(2013, 1, 1)
                    });
                Console.WriteLine("Adding new homework test:");
                Console.WriteLine(studentSystem.Homeworks.Where(h => h.Content.Heading == "Not found").First().Course.Name);

                RemoveCoursesByName(studentSystem, "Electronics");
                Console.WriteLine("Removing course (and cascade deleting) test:");
                Console.WriteLine(studentSystem.Courses.Where(c => c.Name == "Electronics").Count());
            }
        }

        public static void AddStudent(StudentSystemContext studentSystem, Student student)
        {
            studentSystem.Students.Add(student);
            studentSystem.SaveChanges();
        }

        public static void RemoveStudentById(StudentSystemContext studentSystem, int id)
        {
            var student = studentSystem.Students.Where(s => s.Id == id).First();

            studentSystem.Students.Remove(student);
            studentSystem.SaveChanges();
        }

        public static void RemoveStudentsByFacultyNumber(StudentSystemContext studentSystem, int facultyNumber)
        {
            var students = studentSystem.Students.Where(s => s.FacultyNumber == facultyNumber);

            foreach (var student in students)
            {
                studentSystem.Students.Remove(student);
            }

            studentSystem.SaveChanges();
        }

        public static void AddCourse(StudentSystemContext studentSystem, Course course)
        {
            studentSystem.Courses.Add(course);
            studentSystem.SaveChanges();
        }

        public static void RemoveCourseById(StudentSystemContext studentSystem, int id)
        {
            var course = studentSystem.Courses.Where(s => s.Id == id).First();

            studentSystem.Courses.Remove(course);
            studentSystem.SaveChanges();
        }

        public static void RemoveCoursesByName(StudentSystemContext studentSystem, string name)
        {
            var courses = studentSystem.Courses.Where(c => c.Name == name);

            foreach (var course in courses)
            {
                studentSystem.Courses.Remove(course);
            }

            studentSystem.SaveChanges();
        }

        public static void AddHomework(StudentSystemContext studentSystem, Homework homework)
        {
            studentSystem.Homeworks.Add(homework);
            studentSystem.SaveChanges();
        }

        public static void RemoveHomeworkById(StudentSystemContext studentSystem, int id)
        {
            var homework = studentSystem.Homeworks.Where(h => h.Id == id).First();

            studentSystem.Homeworks.Remove(homework);
            studentSystem.SaveChanges();
        }

        public static void RemoveHomeworksByStudentId(StudentSystemContext studentSystem, int studentId)
        {
            var homeworks = studentSystem.Homeworks.Where(h => h.Student.Id == studentId);

            foreach (var homework in homeworks)
            {
                studentSystem.Homeworks.Remove(homework);
            }

            studentSystem.SaveChanges();
        }
    }
}