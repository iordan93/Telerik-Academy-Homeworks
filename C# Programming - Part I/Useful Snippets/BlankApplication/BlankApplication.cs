using System;
using System.Threading;
using System.Globalization;
class BlankApplication
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        
    }
}