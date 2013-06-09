using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._3.Student
{
    class Student : ICloneable, IComparable<Student>
    {
        // Private fields
        private string firstName;
        private string middleName;
        private string lastName;
        private string ssn;
        private string permanentAddress;
        private string mobilePhone;
        private string email;
        private int? course;
        private University university;
        private Faculty faculty;
        private Speciality speciality;

        // Public properties to encapsulate the fields
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                this.firstName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return this.middleName;
            }
            private set
            {
                this.middleName = value;
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
                this.lastName = value;
            }
        }

        public string SSN
        {
            get
            {
                return this.ssn;
            }
            private set
            {
                this.ssn = value;
            }
        }

        public string PermanentAddress
        {
            get
            {
                return this.permanentAddress;
            }
            private set
            {
                this.permanentAddress = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return this.mobilePhone;
            }
            private set
            {
                this.mobilePhone = value;
            }
        }

        public string Email
        {
            get
            {
                return this.email;
            }
            private set
            {
                this.email = value;
            }
        }

        public int? Course
        {
            get
            {
                return this.course;
            }
            private set
            {
                this.course = value;
            }
        }

        public University University
        {
            get
            {
                return this.university;
            }
            private set
            {
                this.university = value;
            }
        }

        public Faculty Faculty
        {
            get
            {
                return this.faculty;
            }
            private set
            {
                this.faculty = value;
            }
        }

        public Speciality Speciality
        {
            get
            {
                return this.speciality;
            }
            private set
            {
                this.speciality = value;
            }
        }

        // Constructor - I assume that name and SSN are mandatory, the other fields are optional
        public Student(string firstName, string middleName, string lastName, string SSN = null, string permanentAddress = null, string mobilePhone = null,
            string email = null, int? course = null, University university = University.None, Faculty faculty = Faculty.None, Speciality speciality = Speciality.None)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = SSN;
            this.PermanentAddress = permanentAddress;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.Course = course;
            this.University = university;
            this.Faculty = faculty;
            this.Speciality = speciality;
        }

        // Methods
        public override bool Equals(object obj)
        {
            Student student = obj as Student;

            // If the casting to Student type is unsuccessfull, the variable student will be null
            if (student == null)
            {
                return false;
            }

            // Equality can be checked by SSN only but I am checking first and last name too.
            // If one of the values is not the same with the other, the method returns false, otherwise returns true
            if (!(this.FirstName == student.FirstName))
            {
                return false;
            }
            if (!(this.MiddleName == student.MiddleName))
            {
                return false;
            }
            if (!(this.LastName == student.LastName))
            {
                return false;
            }
            if (!(this.SSN == student.SSN))
            {
                return false;
            }

            return true;
        }

        // To get the hash code of a student, I use three XOR operations which (provided the SSN is unique) are enough to create a unique hash code
        public override int GetHashCode()
        {
            return (this.FirstName.GetHashCode() ^ this.LastName.GetHashCode()) ^ this.SSN.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder student = new StringBuilder();

            // The name and SSNshould always be full
            student.AppendFormat("{0} {1} {2} {3} {0}\r\n", new string('=', 10), this.FirstName, this.MiddleName, this.LastName);
            student.AppendFormat("SSN : {0}\r\n", this.SSN);

            // Add the other fields if they are not null or empty
            if (!String.IsNullOrEmpty(this.PermanentAddress))
            {
                student.AppendFormat("Permanent address: {0}\r\n", this.PermanentAddress);
            }
            if (!String.IsNullOrEmpty(this.MobilePhone))
            {
                student.AppendFormat("Mobile phone : {0}\r\n", this.MobilePhone);
            }
            if (!String.IsNullOrEmpty(this.Email))
            {
                student.AppendFormat("Email : {0}\r\n", this.Email);
            }
            if (this.Course != null)
            {
                student.AppendFormat("Course : {0}\r\n", this.Course);
            }

            // The enumerations cannot be null, add them without checking
            student.AppendFormat("University: {0}\r\n", this.University);
            student.AppendFormat("Faculty: {0}\r\n", this.Faculty);
            student.AppendFormat("Speciality: {0}\r\n", this.Speciality);

            return student.ToString();
        }

        // The operators == and != execute the Equals() method to check equality (or inequality, respectively)
        public static bool operator ==(Student student1, Student student2)
        {
            return Student.Equals(student1, student2);
        }

        public static bool operator !=(Student student1, Student student2)
        {
            return !(Student.Equals(student1, student2));
        }

        // Implementation of ICloneable - return a new student with the same characteristics as the old one
        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName,
                               this.SSN, this.PermanentAddress, this.MobilePhone, this.Email,
                               this.Course, this.University, this.Faculty, this.Speciality);
        }

        // Implementation of IComparable<Student>
        public int CompareTo(Student other)
        {
            int result = this.FirstName.CompareTo(other.FirstName);

            if (result != 0)
            {
                return result;
            }

            result = this.MiddleName.CompareTo(other.MiddleName);
            if (result != 0)
            {
                return result;
            }

            result = this.LastName.CompareTo(other.LastName);
            if (result != 0)
            {
                return result;
            }

            return 0;
        }
    }
}
