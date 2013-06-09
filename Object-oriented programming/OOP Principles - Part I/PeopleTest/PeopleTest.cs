using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2.People;

namespace PeopleTest
{
    class PeopleTest
    {
        static void Main()
        {
            // Create a list of students
            List<Student> students = new List<Student>();
            students.Add(new Student("Ivan", "Ivanov", 6));
            students.Add(new Student("Stoyan", "Stoyanov", 3));
            students.Add(new Student("Ivanka", "Ivanova", 2));
            students.Add(new Student("Mariya", "Nikolova", 5));
            students.Add(new Student("Petar", "Petrov", 4));
            students.Add(new Student("Kamen", "Aleksiev", 6));
            students.Add(new Student("Petya", "Marinova", 2));
            students.Add(new Student("Dimitar", "Dimitrov", 4));
            students.Add(new Student("Rumen", "Petrov", 5));
            students.Add(new Student("Aleksandar", "Doychinov", 6));

            // Order the students by grade in ascending order
            var orderedStudents = students.OrderBy(x => x.Grade);
            foreach (var item in orderedStudents)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            // Create a list of workers
            List<Worker> workers = new List<Worker>();
            workers.Add(new Worker("Ivan", "Ivanov", 100, 8));
            workers.Add(new Worker("Stoyan", "Stoyanov", 300, 5));
            workers.Add(new Worker("Ivanka", "Ivanova", 150, 10));
            workers.Add(new Worker("Mariya", "Nikolova", 80, 2));
            workers.Add(new Worker("Petar", "Petrov", 380, 12));
            workers.Add(new Worker("Kamen", "Aleksiev", 500, 12));
            workers.Add(new Worker("Petya", "Marinova", 200, 3));
            workers.Add(new Worker("Dimitar", "Dimitrov", 250, 5));
            workers.Add(new Worker("Rumen", "Petrov", 190, 4));
            workers.Add(new Worker("Aleksandar", "Doychinov", 500, 12));
            //foreach (var item in workers)
            //{
            //    Console.WriteLine("{0} {1} - {2:F2}", item.FirstName, item.LastName, item.MoneyPerHour());

            //}
            Console.WriteLine();
            // Order the workers by money per hour in descending order
            var orderedWorkers = workers.OrderByDescending(x => x.MoneyPerHour());
            foreach (var item in orderedWorkers)
            {
                Console.WriteLine(item);
            }

            // Merge the two lists
            List<Human> merged = new List<Human>();
            merged.AddRange(students);
            merged.AddRange(workers);

            // Order the merged list
            var orderedMerged = merged.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
            foreach (var item in orderedMerged)
            {
                Console.WriteLine(item);
            }
        }
    }
}
