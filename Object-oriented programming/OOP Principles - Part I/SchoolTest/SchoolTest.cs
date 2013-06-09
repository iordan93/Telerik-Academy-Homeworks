using System;
using _1.School;

namespace SchoolTest
{
    class SchoolTest
    {
        static void Main()
        {
            // Create some testing variables - a school, some teachers and students
            School mySchool = new School("High School \"Gorno Nanadolnishte\"");

            Teacher ivan = new Teacher("Ivan", "Ivanov");
            ivan.AddDisciplines(new Discipline("Physics", 2, 2), new Discipline("Mathematics", 3, 2));
            ivan.AddComment("A very nice teacher!");
            Teacher stoyan = new Teacher("Stoyan", "Stoyanov");
            stoyan.AddDisciplines(new Discipline("Information technologies", 2, 2), new Discipline("Mathematics", 3, 2), new Discipline("Chemistry", 2, 2));
            stoyan.RemoveDiscipline(new Discipline("Chemistry", 2, 2));
            Teacher nikola = new Teacher("Nikola", "Nikolov");
            nikola.AddDisciplines(new Discipline("History", 2, 0), new Discipline("Literature", 2, 0));
            Teacher hristo = new Teacher("Hristo", "Hristov");
            hristo.AddDiscipline(new Discipline("Physical education", 0, 2));

            Student georgi = new Student("Georgi", "Petkanov", 15);
            georgi.AddComment("Our best student");
            Student drago = new Student("Drago", "Stoyanov", 10);
            Student petko = new Student("Petko", "Mladenov", 21);
            Student  krasimir = new Student("Krasimir", "Vasilev", 11);
            krasimir.AddComment("Fights in class every day!");

            Class seventhA = new Class("7A");
            seventhA.AddStudents(georgi, drago);
            seventhA.AddTeachers(ivan, hristo);

            Class eightA = new Class("8A");
            eightA.AddTeachers(ivan, nikola, hristo);
            eightA.AddStudents(petko, krasimir);
            eightA.AddComment("A good class!");

            // Display information about the school, two classes, a teacher, and two students 
            Console.WriteLine(mySchool);
            Console.WriteLine(seventhA);
            Console.WriteLine(eightA);
            Console.WriteLine();
            Console.WriteLine(ivan);
            Console.WriteLine();
            Console.WriteLine(georgi);
            Console.WriteLine(krasimir);
        }
    }
}
