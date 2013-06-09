using System;
class TenRandomNumbers
{
    static void Main()
    {
        Console.WriteLine("This program will print ten random numbers in the range [100; 200] to the console.");
        
        // We should use a single generator for the whole application in order to get different results
        Random random = new Random();

        for (int index = 1; index <= 10; index++)
        {
            // Random.Next returns a number within [100; 201), which means the program will return a number within [100; 200]
            int next=random.Next(100,201);
            Console.WriteLine(next);
        }
    }
}
