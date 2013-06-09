namespace SchoolSystem
{
    using System;

    public class Student
    {
        private string firstName = null;
        private string lastName = null;
        private int id = 0;

        public Student(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = IdManager.CurrentStudentId;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }

            private set
            {
                // Trimming the value to exclude the case of names containing only spaces
                value = value.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("FirstName", "The first name of a student cannot be null, empty, or whitespace.");
                }

                this.firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return this.lastName;
            }

            private set
            {
                // Trimming the value to exclude the case of names containing only spaces
                value = value.Trim();

                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("LastName", "The last name of a student cannot be null, empty, or whitespace.");
                }

                this.lastName = value;
            }
        }

        public int Id
        {
            get
            {
                return this.id;
            }

            private set
            {
                this.id = value;
            }
        }

        public override bool Equals(object obj)
        {
            Student student = obj as Student;
            if (student != null)
            {
                return this.Id == student.Id;
            }

            return false;
        }
    }
}