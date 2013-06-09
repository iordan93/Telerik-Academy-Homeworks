using System;
using System.Threading;
using System.Globalization;

class PointsRelativeToARectangle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        //Coordinates of any two opposite corners of the rectangle
        int x1 = int.Parse(Console.ReadLine());
        int y1 = int.Parse(Console.ReadLine());
        int x2 = int.Parse(Console.ReadLine());
        int y2 = int.Parse(Console.ReadLine());

        //Coordinates of point we are looking for
        int x = 0;
        int y = 0;

        int minX = Math.Min(x1, x2);
        int maxX = Math.Max(x1, x2);
        int minY = Math.Min(y1, y2);
        int maxY = Math.Max(y1, y2);

        //Point P(x;y) is on a corner
        if (((x == minX) || (x == maxX))
                && ((y == minY) || (y == maxY)))
        {
            //statements
        }

        //Point P(x;y) is on a horizontal border
        if (((x > minX) && (x < maxX))
            && ((y == minY) || (y == maxY)))
        {
            //statements    
        }

        //Point P(x;y) is on a vertical border
        if (((x == minX) || (x == maxX))
            && ((y > minY) && (y < maxY)))
        {
           //statements
        }

        //Point P(x;y) is within rectangle
        if (((x > minX) && (x < maxX))
            && ((y > minY) && (y < maxY)))
        {
            //statements
        }
    }
}