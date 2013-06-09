using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3.Student
{
    class StudentTest
    {
        static void Main()
        {
            Student student = new Student("Ivan", "Petrov", "Stoyanov",
                                          "9008152548", "Sofia", "0877888555", "someone@example.com",
                                          3, University.SU, Faculty.Mathematics, Speciality.Computers);
            Console.WriteLine(student);
            Console.WriteLine("Hashcode: {0}", student.GetHashCode());

            Student otherStudent = new Student("Ivan", "Petrov", "Stoyanov",
                                          "9008152548", "Sofia", "0877888555", "someone@example.com",
                                          3, University.TU, Faculty.Mathematics, Speciality.Computers);
            Console.WriteLine(otherStudent);
            Console.WriteLine();
            // The same person can study in two universities
            Console.WriteLine(student.Equals(otherStudent) ? "The two students are the same." : "The two students are not the same.");
            Console.WriteLine("Result of the comparison: {0}",student.CompareTo(otherStudent));
        }
    }
}
