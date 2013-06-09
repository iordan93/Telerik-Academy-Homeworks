using System;

    class Program
    {
        static void Main()
        {
            Console.Write("Enter the point's x coordinate: ");
            double pointX = double.Parse(Console.ReadLine());
            Console.Write("Enter the point's y coordinate: ");
            double pointY = double.Parse(Console.ReadLine());
            if (pointX * pointX + pointY * pointY <= 25)
            {
                Console.WriteLine("The point is in the circle ((0,0),5)");
            }
            else
            {
                Console.WriteLine("The point is outside the circle ((0,0),5)");
            }
        }
    }