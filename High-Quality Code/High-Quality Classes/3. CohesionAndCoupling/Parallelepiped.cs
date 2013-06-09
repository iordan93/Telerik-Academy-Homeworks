namespace CohesionAndCoupling
{
    using System;

    public class Parallelepiped
    {
        private double width;
        private double height;
        private double depth;

        public Parallelepiped(double width, double height, double depth)
        {
            this.Width = width;
            this.Height = height;
            this.Depth = depth;
        }

        public Parallelepiped()
            : this(0, 0, 0)
        {
        }

        public double Width
        {
            get
            {
                return this.width;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The width of the parallelepiped must be nonnegative.");
                }

                this.width = value;
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
                if (value < 0)
                {
                    throw new ArgumentException("The height of the parallelepiped must be nonnegative.");
                }

                this.height = value;
            }
        }

        public double Depth
        {
            get
            {
                return this.depth;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("The depth of the parallelepiped must be nonnegative.");
                }

                this.depth = value;
            }
        }

        public double CalculateMainDiagonal()
        {
            double diagonal = GeometryUtilities.CalculateDistanceToOrigin3D(this.Width, this.Height, this.Depth);
            return diagonal;
        }

        public double CalculateDiagonalXY()
        {
            double diagonal = GeometryUtilities.CalculateDistanceToOrigin2D(this.Width, this.Height);
            return diagonal;
        }

        public double CalculateDiagonalXZ()
        {
            double diagonal = GeometryUtilities.CalculateDistanceToOrigin2D(this.Width, this.Depth);
            return diagonal;
        }

        public double CalculateDiagonalYZ()
        {
            double diagonal = GeometryUtilities.CalculateDistanceToOrigin2D(this.Height, this.Depth);
            return diagonal;
        }

        public double CalculateVolume()
        {
            double volume = this.Width * this.Height * this.Depth;
            return volume;
        }
    }
}
