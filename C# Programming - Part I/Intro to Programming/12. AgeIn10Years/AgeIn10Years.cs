using System;

    class AgeIn10Years
    {
        static void Main()
        {
            Console.WriteLine("What is your age now?");
            int age = Int32.Parse(Console.ReadLine());
            Console.WriteLine("When is your birthday?");
            DateTime birthday = DateTime.Parse(Console.ReadLine());
            int ageIn10Years;
            if (birthday < DateTime.Now)
            {
                ageIn10Years = age + 10;
            }
            else
            {
                ageIn10Years = age + 11;
            }
            Console.WriteLine("\r\nIn ten years, you will be {0} years old.", ageIn10Years);
        }
    }