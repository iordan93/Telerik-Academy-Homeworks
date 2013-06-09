using System;
using System.Text;

namespace _1.School
{
    public class Student : Person, ICommentable
    {
        // Private fields - the class inherits firstName and lastName from Person, and includes a class number
        private int classNumber;
        private string comment = string.Empty;

        // Public properties to encapsulate the fields - once again, FirstName and LastName are inherited from the base class Person
        public int ClassNumber
        {
            get
            {
                return this.classNumber;
            }
            set
            {
                if (value > 0)
                {
                    this.classNumber = value;
                }
                else throw new ArgumentException("The class number must be greater than zero.");

            }
        }
        public string Comment
        {
            get
            {
                return this.comment;
            }
            set
            {
                this.comment = value;
            }
        }

        // Constructor - a student must have a name so an empty constructor is not needed
        public Student(string firstName, string lastName, int classNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.ClassNumber = classNumber;
        }

        // Comments functionality required by the ICommentable interface
        public void AddComment(string comment)
        {
            this.Comment = comment;
        }

        // Display information about the student
        public override string ToString()
        {
            StringBuilder student = new StringBuilder();
            student.AppendFormat("{0} {1} {2} {0}\n", new string('=', 10), this.FirstName, this.LastName);
            student.AppendFormat("Class number: {0}\n", this.ClassNumber);
            student.AppendFormat("Comment: {0}", this.Comment);
            return student.ToString();
        }
    }
}
