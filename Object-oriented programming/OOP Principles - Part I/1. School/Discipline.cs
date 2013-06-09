using System;
using System.Text;


namespace _1.School
{
    public class Discipline : ICommentable
    {
        // Private fields
        private string name = string.Empty;
        private int numberOfLectures;
        private int numberOfExercises;
        private string comment;

        // Public properties to encapsulate the fields
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
                else throw new ArgumentNullException("The name of a discipline must not be empty.");
            }
        }

        public int NumberOfLectures
        {
            get
            {
                return this.numberOfLectures;
            }
            set
            {
                if (value >= 0)
                {
                    this.numberOfLectures = value;
                }

                else throw new ArgumentException("The number of lectures in a discipline must be nonnegative.");
            }
        }

        public int NumberOfExercises
        {
            get
            {
                return this.numberOfExercises;
            }
            set
            {
                if (value >= 0)
                {
                    this.numberOfExercises = value;
                }
                else throw new ArgumentException("The number of exercises in a discipline must be nonnegative.");

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

        // Constructor - all fields are required (name is required, the two numbers must be >= 0)
        public Discipline(string name, int numberOfLectures = 0, int numberOfExercises = 0)
        {
            this.Name = name;
            this.NumberOfLectures = numberOfLectures;
            this.NumberOfExercises = numberOfExercises;
        }

        // Required by the ICommentable interface
        public void AddComment(string comment)
        {
            this.Comment = comment;
        }

        // Display information about the discipline
        public override string ToString()
        {
            StringBuilder discipline = new StringBuilder();
            discipline.AppendFormat("{0} {1} {0}\n", new string('=', 10), this.Name);
            discipline.AppendFormat("Number of lectures: {0}\r\nNumber of exercises: {1}", this.NumberOfLectures, this.NumberOfExercises);
            discipline.AppendFormat("Comment: {0}", this.Comment);
            return discipline.ToString();
        }
    }
}
