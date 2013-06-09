using System;

namespace _3._5.Students
{
    class Student
    {
        // Private fields
        private string firstName;
        private string lastName;
        private uint age;

        // Public properties to encapsulate the fields
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
            }
        }
        
        public uint Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value > 0)
                {
                    this.age = value;
                }
                else throw new ArgumentException("The age of a student must be greater than or equal to zero");
            }
        }

        // Constructors
        // Empty constructor
        public Student()
            : this(null, null, 0)
        {
        }

        // Constructor with first and last name
        public Student(string firstName, string lastName) : this(firstName, lastName, 0) 
        {
        }

        // Constructor with first name, last name and age
        public Student(string firstName, string lastName, uint age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
        }

        // Write the student as string
        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}