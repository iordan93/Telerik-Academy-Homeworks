using System;
using System.Text;

namespace _1.School
{
    public class School
    {
        // Private field
        private string name;

        // Public property to encapsulate the field
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (!String.IsNullOrEmpty(value))
                {
                    this.name = value;
                }
                else throw new ArgumentNullException("The name of the school must not be empty.");
            }
        }

        // Constructor - name is obligatory
        public School(string name) 
        {
            this.Name = name;
        }

        // Display information about the school
        public override string ToString()
        {
            StringBuilder school = new StringBuilder();
            school.AppendLine(String.Format("{0} {1} {0}", new string('=', 10), this.Name));
            return school.ToString();
        }
    }
}
