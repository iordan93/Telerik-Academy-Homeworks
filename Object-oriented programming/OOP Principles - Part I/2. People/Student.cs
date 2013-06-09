using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2.People
{
    public class Student : Human
    {
        // Private fields - firstName and lastName are inherited from Human
        public double grade;

        // Public properties to encapsulate the fields - FirstName and LastName are inherited from Human
        public double Grade
        {
            get
            {
                return this.grade;
            }
            set
            {
                if (value >= 2 && value <= 6)
                {
                    this.grade = value;
                }
                else throw new ArgumentException("The grade must be a real number between 2 and 6.");
            }
        }

        // Constructor - name is required, grade is not, and it is set to a default value of 2
        public Student(string firstName, string lastName, double grade = 2)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.grade = grade;
        }

        // Write the student in a human-readable way
        public override string ToString()
        {
            StringBuilder student = new StringBuilder();
            student.AppendFormat("{0} Student {0}\r\n",new string('=', 5));
            student.AppendFormat("Name: {0} {1}\r\nGrade: {2}", this.FirstName,this.LastName, this.Grade);
            return student.ToString();
        }
    }
}
