using System;

namespace _1.School
{
    public abstract class Person
    {
        // Private fields
        private string firstName;
        private string lastName;

        // Public properties to encapsulate the fields
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.firstName = value;
                }
                else throw new ArgumentNullException("The first name of a person must not be empty.");
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
                if (!String.IsNullOrEmpty(value))
                {
                    this.lastName = value;
                }
                else throw new ArgumentNullException("The last name of a person must not be empty.");

            }
        }
    }
}
