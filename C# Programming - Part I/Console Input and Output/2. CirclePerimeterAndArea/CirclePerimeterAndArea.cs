using System;

    class CirclePerimeterAndArea
    {
        static void Main()
        {
            Console.WriteLine("Enter circle radius r = ");
            double r = double.Parse(Console.ReadLine());
            double perimeter = 2 * Math.PI * r;
            double area = Math.PI * r * r;
            Console.WriteLine("The perimeter of a circle with radius {0} is {1:0.00} and the area is {2:0.00}.", r, perimeter, area);
        }
    }
