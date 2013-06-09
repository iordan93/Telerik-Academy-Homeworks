using System;

namespace _1._4.Point3D
{
    public struct Point3D
    {
        // Fields (private)
        private double x, y, z;

        // Origin of the coordinate system
        private static readonly Point3D origin = new Point3D(0, 0, 0);

        // Public properties to encapsulate the fields
        public double X
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

        public double Y
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

        public double Z
        {
            get
            {
                return this.z;
            }
            set
            {
                this.z = value;
            }
        }

        // Static properties
        // Origin has only getter because it cannot be written
        public static Point3D Origin
        {
            get
            {
                return origin;
            }
        }

        // Constructor
        // One parameter is compulsory, if the others are not defined, they are set to 0 by default
        public Point3D(double x, double y = 0, double z = 0)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        // Writing the point, for example to the console
        public override string ToString()
        {
            return String.Format("({0}; {1}; {2})",this.X,this.Y, this.Z);
        }
    }
}
