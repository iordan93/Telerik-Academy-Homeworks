using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1.Shapes
{
    class ShapesTest
    {
        static void Main()
        {
            Shape[] shapes = new Shape[3];
            shapes[0] = new Rectangle(5, 6);
            shapes[1] = new Triangle(3, 4);
            shapes[2] = new Circle(5);

            Console.WriteLine("Area of the rectangle: {0} square units.", shapes[0].CalculateSurface());
            Console.WriteLine("Area of the triangle: {0} square units.", shapes[1].CalculateSurface());
            Console.WriteLine("Area of the circle: {0} square units.", shapes[2].CalculateSurface());

        }
    }
}
