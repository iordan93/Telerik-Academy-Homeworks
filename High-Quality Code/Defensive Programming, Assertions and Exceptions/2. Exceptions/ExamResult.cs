using System;

public class ExamResult
{
    private int grade;
    private int minGrade = 0;
    private int maxGrade;
    private string comments;

    public ExamResult(int grade, int minGrade, int maxGrade, string comments)
    {
        this.MinGrade = minGrade;
        this.MaxGrade = maxGrade;
        this.Grade = grade;

        this.Comments = comments;
    }

    public int Grade
    {
        get
        {
            return this.grade;
        }

        set
        {
            if (this.minGrade > value || this.MaxGrade < value)
            {
                throw new ArgumentOutOfRangeException("Grade");
            }

            this.grade = value;
        }
    }

    public int MinGrade
    {
        get
        {
            return this.minGrade;
        }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException("MinGrade");
            }

            this.minGrade = value;
        }
    }

    public int MaxGrade
    {
        get
        {
            return this.maxGrade;
        }

        set
        {
            if (value < this.MaxGrade)
            {
                throw new ArgumentOutOfRangeException("MaxGrade");
            }

            this.maxGrade = value;
        }
    }

    public string Comments
    {
        get
        {
            return this.comments;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("Comments");
            }

            this.comments = value;
        }
    }
}
