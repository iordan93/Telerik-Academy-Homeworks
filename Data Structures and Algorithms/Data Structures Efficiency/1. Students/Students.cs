namespace _1.Students
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class Students
    {
        private static readonly OrderedMultiDictionary<string, Student> studentsByCourse = new OrderedMultiDictionary<string, Student>(true);

        public static void Main()
        {
            StreamReader inputFile = new StreamReader("../../students.txt");
            Console.SetIn(inputFile);

            string line = Console.ReadLine();
            while (line != null)
            {
                string[] parts = line.Split('|').Select(part => part.Trim()).ToArray();

                AddStudent(parts[0], parts[1], parts[2]);
                line = Console.ReadLine();
            }

            foreach (var course in studentsByCourse.Keys)
            {
                Console.WriteLine("{0}: {1}", course, FindStudentsByCourse(course));
            }
        }

        private static void AddStudent(string firstName, string lastName, string course)
        {
            Student newStudent = new Student(firstName, lastName);
            studentsByCourse[course].Add(newStudent);
        }

        private static string FindStudentsByCourse(string course)
        {
            ICollection<Student> found = studentsByCourse[course];

            if (found.Count == 0)
            {
                throw new ArgumentException("There are no students in this course.");
            }

            return string.Join(", ", found);
        }
    }
}