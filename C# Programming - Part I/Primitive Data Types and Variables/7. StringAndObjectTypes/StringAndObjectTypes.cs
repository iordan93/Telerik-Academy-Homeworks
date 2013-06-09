using System;

    class StringAndObjectTypes
    {
        static void Main()
        {
            string hello = "Hello";
            string world = "World";
            object helloWorld = hello + " " + world;
            Console.WriteLine("Object: {0}", helloWorld);
            string helloWorldString = (string)helloWorld;
            Console.WriteLine("String: {0}", helloWorldString);
        }
    }