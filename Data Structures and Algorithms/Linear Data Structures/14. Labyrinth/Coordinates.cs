namespace Labyrinth
{
    using System;

    public class Coordinates
    {
        public Coordinates(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
