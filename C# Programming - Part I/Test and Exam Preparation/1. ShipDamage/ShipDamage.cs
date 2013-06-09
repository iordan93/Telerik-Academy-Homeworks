using System;
using System.Threading;
using System.Globalization;

class ShipDamage
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        int sx1=int.Parse(Console.ReadLine());
        int sy1 = int.Parse(Console.ReadLine());
        int sx2 = int.Parse(Console.ReadLine());
        int sy2 = int.Parse(Console.ReadLine());
        int h = int.Parse(Console.ReadLine());
        int cx1 = int.Parse(Console.ReadLine());
        int cy1 = int.Parse(Console.ReadLine());
        int cx2 = int.Parse(Console.ReadLine());
        int cy2 = int.Parse(Console.ReadLine());
        int cx3 = int.Parse(Console.ReadLine());
        int cy3 = int.Parse(Console.ReadLine());
        cy1 = 2 * h - cy1;
        cy2 = 2 * h - cy2;
        cy3 = 2 * h - cy3;
        int minX = Math.Min(sx1, sx2);
        int maxX = Math.Max(sx1, sx2);
        int minY = Math.Min(sy1, sy2);
        int maxY = Math.Max(sy1, sy2);
        int shipDamage = 0;

        //First shot
            //Strike in angle
            if (((cx1 == minX) || (cx1 == maxX)) 
                && ((cy1 == minY) || (cy1 == maxY)))
            {
                shipDamage += 25;
            }
            //Strike in border
            if (((cx1 > minX) && (cx1 < maxX))
                && ((cy1 == minY) || (cy1 == maxY)))
            {
                shipDamage += 50;
            }
            if (((cx1 == minX) || (cx1 == maxX))
                && ((cy1 > minY) && (cy1 < maxY)))
            {
                shipDamage += 50;
            }
            //Strike within ship
            if (((cx1 > minX) && (cx1 < maxX))
                && ((cy1 > minY) && (cy1 < maxY)))
            {
                shipDamage += 100;
            }

        //Second shot
            //Strike in angle
            if (((cx2 == minX) || (cx2 == maxX))
                && ((cy2 == minY) || (cy2 == maxY)))
            {
                shipDamage += 25;
            }
            //Strike in border
            if (((cx2 > minX) && (cx2 < maxX))
                && ((cy2 == minY) || (cy2 == maxY)))
            {
                shipDamage += 50;
            }
            if (((cx2 == minX) || (cx2 == maxX))
                && ((cy2 > minY) && (cy2 < maxY)))
            {
                shipDamage += 50;
            }
            //Strike within ship
            if (((cx2 > minX) && (cx2 < maxX))
                && ((cy2 > minY) && (cy2 < maxY)))
            {
                shipDamage += 100;
            }

        //Third shot
            //Strike in angle
            if (((cx3 == minX) || (cx3 == maxX))
                && ((cy3 == minY) || (cy3 == maxY)))
            {
                shipDamage += 25;
            }
            //Strike in border
            if (((cx3 > minX) && (cx3 < maxX))
                && ((cy3 == minY) || (cy3 == maxY)))
            {
                shipDamage += 50;
            }
            if (((cx3 == minX) || (cx3 == maxX))
                && ((cy3 > minY) && (cy3 < maxY)))
            {
                shipDamage += 50;
            }
            //Strike within ship
            if (((cx3 > minX) && (cx3 < maxX))
                && ((cy3 > minY) && (cy3 < maxY)))
            {
                shipDamage += 100;
            }
        Console.WriteLine("{0}%", shipDamage);
    }
}