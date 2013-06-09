using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1.School
{
    public class Teacher : Person, ICommentable
    {
        // Private fields
        private List<Discipline> disciplines=new List<Discipline>();
        private string comment = string.Empty;

        // Public properties to encapsulate the fields
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

        public List<Discipline> Disciplines
        {
            get
            {
                return this.disciplines;
            }
            private set
            {
                this.disciplines = value;
            }
        }

        // Constructors - FirstName and LastName are inherited from Person
        public Teacher(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        // Methods
        // Add a discipline
        public void AddDiscipline(Discipline discipline)
        {
            this.Disciplines.Add(discipline);
        }

        // Add multiple disciplines
        public void AddDisciplines(params Discipline[] disciplines)
        {
            this.Disciplines.AddRange(disciplines);
        }

        // Remove a discipline
        public void RemoveDiscipline(Discipline discipline)
        {
            this.Disciplines.Remove(discipline);
        }

        // Functionality required by ICommentable
        public void AddComment(string comment)
        {
            this.Comment = comment;
        }

        // Display information about the teacher
        public override string ToString()
        {
            StringBuilder teacher = new StringBuilder();
            teacher.AppendFormat("{0} {1} {2} {0}\n", new string('=',10), this.FirstName, this.LastName);
            teacher.AppendLine("Disciplines:");
            foreach (var discipline in this.Disciplines)
            {
                teacher.AppendFormat("{0}\t Lectures: {1}\t Exercises: {2}\n", discipline.Name, discipline.NumberOfLectures, discipline.NumberOfExercises);
            }
            teacher.AppendFormat("Comment: {0}", this.Comment);
            return teacher.ToString();
        }
    }
}
