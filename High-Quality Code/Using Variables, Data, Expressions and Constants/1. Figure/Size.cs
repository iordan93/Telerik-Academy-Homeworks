namespace Figure
{
    using System;

    public class Size
    {
        private double width = 0;
        private double height = 0;

        public Size(double width, double height)
        {
            this.width = width;
            this.height = height;
        }

        public double Width
        {
            get
            { 
                return this.width;
            }

            set
            {
                if (value > 0)
                {
                    this.width = value;
                }
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }

            set
            {
                if (value > 0)
                {
                    this.height = value;
                }
            }
        }
    }
}