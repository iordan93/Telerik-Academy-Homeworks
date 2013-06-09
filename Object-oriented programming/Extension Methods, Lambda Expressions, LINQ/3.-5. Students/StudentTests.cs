using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._5.Students
{
    class StudentTests
    {
        static void Main()
        {
            // Create a list of students
            List<Student> students = new List<Student>();
            students.Add(new Student("Stoyan", "Ivanov", 15));
            students.Add(new Student("Stoyan", "Petrov", 18));
            students.Add(new Student("Boris", "Iliev", 20));
            students.Add(new Student("Mariya", "Nikolova", 24));
            students.Add(new Student("Kosta", "Valentinov", 30));
            students.Add(new Student("Petar", "Lyubomirov", 47));

            var sortedStudents = FirstBeforeLastName(students);
            PrintStudents(sortedStudents);

            Console.WriteLine(new string('-', 20));

            var ageBetween18And24 = AgeBetween18And24(students);
            PrintStudents(ageBetween18And24);

            Console.WriteLine(new string('-', 20));

            var sortedByNames = SortByNamesLambdaExpression(students);
            PrintStudents(sortedByNames);

            Console.WriteLine(new string('-', 20));

            var sortedByNamesLINQ = SortByNamesLINQ(students);
            PrintStudents(sortedByNamesLINQ);
        }

        // The methods work with IEnumerable<Student> because this is the LINQ returned type
        private static void PrintStudents(IEnumerable<Student> sortedStudents)
        {
            // Print each selected student to the console
            Console.WriteLine("Sorted students:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }

        private static IEnumerable<Student> AgeBetween18And24(List<Student> students)
        {
            // Select all students whose age is between 18 and 24
            var ageBetween18And24 =
                                   from student in students
                                   where (student.Age >= 18) && (student.Age <= 24)
                                   select student;
            return ageBetween18And24;
        }

        private static IEnumerable<Student> FirstBeforeLastName(List<Student> students)
        {
            // Select all students whose first name is before their last name, 
            // i. e. the compare function returns -1 and return the student's name
            var sortedStudents =
                                from student in students
                                where student.FirstName.CompareTo(student.LastName) == -1
                                select student;
            return sortedStudents;
        }

        private static IOrderedEnumerable<Student> SortByNamesLambdaExpression(List<Student> students)
        {
            // Order by first name descending then by second name descending
            var sortedByNames = students.OrderByDescending(x => x.FirstName).ThenByDescending(x => x.LastName);
            return sortedByNames;
        }

        private static IOrderedEnumerable<Student> SortByNamesLINQ(List<Student> students)
        {
            var sortedByNames =
                           from student in students
                           orderby student.FirstName descending, student.LastName descending
                           select student;
            return sortedByNames;
        }

    }
}
