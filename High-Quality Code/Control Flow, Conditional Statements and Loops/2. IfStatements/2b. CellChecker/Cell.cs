using System;

public class Cell
{
    private int x;
    private int y;

    public Cell()
        : this(0, 0)
    {
    }

    public Cell(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }

    public int X
    {
        get
        {
            return this.x;
        }

        set
        {
            this.x = value;
        }
    }

    public int Y
    {
        get
        {
            return this.y;
        }

        set
        {
            this.y = value;
        }
    }
}
