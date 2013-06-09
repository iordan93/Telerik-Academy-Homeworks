using System;

public class Potato : Vegetable
{
    private bool isRotten;
    private bool isPeeled;
    
    public bool IsRotten
    {
        get
        {
            return this.isRotten;
        }

        set
        {
            this.isRotten = value;
        }
    }

    public bool IsPeeled
    {
        get
        {
            return this.isPeeled;
        }

        set
        {
            this.isPeeled = value;
        }
    }
}