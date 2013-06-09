using System;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
class FighterAttack
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        //Read input
        int px1 = int.Parse(Console.ReadLine());
        int py1 = int.Parse(Console.ReadLine());
        int px2 = int.Parse(Console.ReadLine());
        int py2 = int.Parse(Console.ReadLine());
        int fx = int.Parse(Console.ReadLine());
        int fy = int.Parse(Console.ReadLine());
        int d = int.Parse(Console.ReadLine());
        int sum = 0;

        int maxDamageX = fx + d;
        int maxDamageY = fy;
        int halfDamageY1 = fy - 1;
        int halfDamageY2 = fy + 1;
        int threeQuartersDamageX = maxDamageX + 1;
        int threeQuartersDamageY = fy;

        //100% damage is within the boundaries of P 
        if ((Math.Min(px1,px2) <= maxDamageX) && (Math.Max(px1,px2) >= maxDamageX) && (Math.Min(py1,py2) <= maxDamageY) && (Math.Max(py1,py2) >= maxDamageY))
        {
            sum += 100;
        }
        //50% damage (down) is within the boundaries of P
        if ((Math.Min(px1, px2) <= maxDamageX) && (Math.Max(px1,px2) >= maxDamageX) && (halfDamageY1 >= Math.Min(py1,py2)) && (halfDamageY1 <= Math.Max(py1,py2)))
        {
            sum += 50;
        }
        //50% damage (up) is within the boundaries of P
        if ((Math.Min(px1, px2) <= maxDamageX) && ((Math.Max(px1,px2) >= maxDamageX) && (halfDamageY2 >= Math.Min(py1,py2)) && (halfDamageY2 <= Math.Max(py1,py2))))
        {
            sum += 50;
        }
        //75% damage is within the boundaries of P
        if ((Math.Min(px1, px2) <= threeQuartersDamageX) && (threeQuartersDamageX <= (Math.Max(px1,px2)) && (threeQuartersDamageY >= Math.Min(py1,py2)) && (threeQuartersDamageY <= Math.Max(py1,py2))))
        {
            sum += 75;
        }
        Console.WriteLine("{0}%", sum);
    }
}