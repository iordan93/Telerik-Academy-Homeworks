using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    public abstract class Shape
    {
        // Private fields
        private double width;
        private double height;
        
        // Public properties to encapsulate the fields
        public double Width
        {
            get
            {
                return this.width;
            }
            protected set
            {
                this.width = value;
            }
        }

        public double Height
        {
            get
            {
                return this.height;
            }
            protected set
            {
                this.height = value;
            }
        }

        // Constructor
        public Shape(double width, double height) 
        {
            this.Width = width;
            this.Height = height;
        }

        // Abstract mettod (which will be overridden later) to calculate the surface of the shape
        public abstract double CalculateSurface();
    }
}
