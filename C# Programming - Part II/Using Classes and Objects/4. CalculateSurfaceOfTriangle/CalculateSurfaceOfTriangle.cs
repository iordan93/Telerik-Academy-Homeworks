using System;
class CalculateSurfaceOfTriangle
{
    static void ShowMenu()
    {
        Console.WriteLine("Press 1 to calculate the area by a side and altitude to it.");
        Console.WriteLine("Press 2 to calculate the area by three sides.");
        Console.WriteLine("Press 3 to calculate the area by two sides and an angle between them.");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                CalculateAreaBySideAndAltitude();
                break;
            case 2:
                CalculateAreaByThreeSides();
                break;
            case 3:
                CalculateAreaByTwoSidesAndAngle();
                break;
            default:
                Console.WriteLine("You have entered a wrong number. Try again.");
                ShowMenu();
                return;
        }
    }

    static void CalculateAreaBySideAndAltitude()
    {
        double side = 0;
        while (side <= 0)
        {
            Console.Write("Enter the length of the side: ");
            side = double.Parse(Console.ReadLine());
        }
        double alt = 0;
        while (alt <= 0)
        {
            Console.Write("Enter the length of the altitude to the side: ");
            alt = double.Parse(Console.ReadLine());
        }

        // The standard formula for triangle area
        double area = side * alt / 2;

        Console.WriteLine("The area is {0} square units.", area);
    }

    static void CalculateAreaByThreeSides()
    {
        double a = 0;
        while (a <= 0)
        {
            Console.Write("Enter the length of the side a: ");
            a = double.Parse(Console.ReadLine());
        }
        double b = 0;
        while (b <= 0)
        {
            Console.Write("Enter the length of the side b: ");
            b = double.Parse(Console.ReadLine());
        }
        double c = 0;
        while (c <= 0)
        {
            Console.Write("Enter the length of the side c: ");
            c = double.Parse(Console.ReadLine());
        }

        // The area should be calculated using Hero's formula
        double p = (a + b + c) / 2;
        double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

        Console.WriteLine("The area is {0} square units.", area);
    }

    static void CalculateAreaByTwoSidesAndAngle()
    {
        double a = 0;
        while (a <= 0)
        {
            Console.Write("Enter the length of the side a: ");
            a = double.Parse(Console.ReadLine());
        }
        double b = 0;
        while (b <= 0)
        {
            Console.Write("Enter the length of the side b: ");
            b = double.Parse(Console.ReadLine());
        }
        double angle = 0;
        while (angle <= 0)
        {
            Console.Write("Enter the angle between a and b in degrees: ");
            angle = double.Parse(Console.ReadLine());
        }

        // The area should be calculated using the standard formula
        // Math.Sin() works in radians, so we need to convert the angle to radians first
        angle *= Math.PI / 180;
        double area = a * b * Math.Sin(angle);

        Console.WriteLine("The area is {0} square units.", area);
    }

    static void Main()
    {
        Console.WriteLine("This program will calculate the area of a triangle.");

        ShowMenu();
    }
}
