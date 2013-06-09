using System;
using System.Threading;
using System.Globalization;
class PojntsRelativeToACircle
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        //Coordinates of point P(x;y)
        int x = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());

        //Circle k (O(Ox;Oy); r)
        int Ox = 0;
        int Oy = 0;
        int r = 5;

        //Point is inside the circle
        if (((x - Ox) * (x - Ox)) + ((y - Oy) * (y - Oy)) < r * r)
        {
            //statements
        }

        //Point is on the circumference of the circle
        if (((x - Ox) * (x - Ox)) + ((y - Oy) * (y - Oy)) == r * r)
        {
            //statements
        }

        //Point is outside the circle
        if (((x - Ox) * (x - Ox)) + ((y - Oy) * (y - Oy)) > r * r)
        {
            //statements
        }
    }
}