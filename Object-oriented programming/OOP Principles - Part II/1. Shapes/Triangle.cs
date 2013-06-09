using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    public class Triangle : Shape
    {
        // Constructor, inheriting from the base constructor
        public Triangle(double baseSide, double height)
            : base(baseSide, height)
        {
        }

        public override double CalculateSurface()
        {
            return 0.5 * this.Width * this.Height;
        }
    }
}
