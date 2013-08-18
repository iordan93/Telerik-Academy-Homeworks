namespace StudentsModels
{
    using System;
    using System.Collections.Generic;

    public static class ModelConverter
    {
        public static SchoolModel ConvertSchool(School school)
        {
            SchoolModel schoolModel = new SchoolModel()
            {
                Location = school.Location,
                Name = school.Name,
            };

            if (school.Students != null)
            {
                schoolModel.Students = new List<StudentModel>();
                foreach (var student in school.Students)
                {
                    schoolModel.Students.Add(ConvertStudent(student));
                }
            }

            return schoolModel;
        }

        public static StudentModel ConvertStudent(Student student)
        {
            StudentModel studentModel = new StudentModel()
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                Grade = student.Grade,
                Age = student.Age
            };

            if (student.Marks != null)
            {
                studentModel.Marks = new List<MarkModel>();
                foreach (var mark in student.Marks)
                {
                    studentModel.Marks.Add(ConvertMark(mark));
                }
            }

            return studentModel;
        }

        public static MarkModel ConvertMark(Mark mark)
        {
            MarkModel markModel = new MarkModel()
            {
                Subject = mark.Subject,
                Value = mark.Value
            };

            return markModel;
        }
    }
}
