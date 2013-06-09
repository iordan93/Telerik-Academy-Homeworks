using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Person
{
    class Person
    {
        // The Student class may inherit from the Person class but it is not stated in the problem's description, 
        // so I am making it a completely new class
        // Private fields
        private string name;
        private int? age;

        // Public properties to encapsulate the fields
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int? Age
        {
            get
            {
                return this.age;
            }
            private set
            {
                this.age = value;
            }
        }

        // Constructor
        public Person(string name, int? age = null)
        {
            this.Name = name;
            this.Age = age;
        }

        // Methods
        public override string ToString()
        {
            StringBuilder person = new StringBuilder();
            person.AppendFormat("Name: {0}\r\n", this.Name);
            person.Append("Age: ");
            if (this.Age != null)
            {
                person.AppendFormat("{0}", this.Age);
            }
            else
            {
                person.AppendFormat("unspecified");
            }
            person.AppendLine();
            return person.ToString();
        }
    }
}
