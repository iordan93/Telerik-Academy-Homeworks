using System;

    class NullValues
    {
        static void Main()
        {
            int? nullInt = null;
            double? nullDouble = null;
            Console.WriteLine("Null integer: " + nullInt);
            Console.WriteLine("Null double: " + nullDouble);
            nullInt = nullInt + 2;
            Console.WriteLine("Null integer+ 2: {0}", nullInt + 2);
            Console.WriteLine("Null double + 10,5: {0}", nullDouble + 10,5);
            Console.WriteLine("Null integer + null double: {0}", nullInt + nullDouble);
        }
    }
