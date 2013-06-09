using System;

public class CSharpExam : Exam
{
    private const int MinScore = 0;
    private const int MaxScore = 100;
    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (this.Score < MinScore || this.Score > MaxScore)
            {
                throw new ArgumentOutOfRangeException("Score");
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        if (this.Score < MinScore || this.Score > MaxScore)
        {
            throw new ArgumentOutOfRangeException("Score");
        }
        else
        {
            return new ExamResult(this.Score, MinScore, MaxScore, "Exam results calculated by score.");
        }
    }
}
