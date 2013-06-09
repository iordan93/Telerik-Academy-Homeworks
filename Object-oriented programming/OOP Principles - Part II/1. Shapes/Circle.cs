using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    public class Circle : Shape
    {
        // Constructor - the width and height of the circle are equal to the diameter
        public Circle(double radius)
            : base(2 * radius, 2 * radius)
        {
        }

        public override double CalculateSurface()
        {
            // Surface of a circle using diameter - S = pi * d^2 / 4
            return Math.PI * Math.Pow(this.Width, 2) / 4;
        }
    }
}
