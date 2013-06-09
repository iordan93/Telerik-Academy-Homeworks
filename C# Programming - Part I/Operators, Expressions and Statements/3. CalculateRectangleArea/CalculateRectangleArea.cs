using System;

    class CalculateRectangleArea
    {
        static void Main()
        {
            Console.WriteLine("Enter rectangle width: ");
            double width = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter rectangle height: ");
            double height = double.Parse(Console.ReadLine());
            double area = width * height;
            Console.WriteLine("The area of a rectangle with sides {0} and {1} is {2}.", width, height, area);
        }
    }
