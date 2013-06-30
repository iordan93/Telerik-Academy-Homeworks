using System;

public class BiDictionary
{
    public static void Main()
    {
        BiDictionary<string, int, string> trainers = new BiDictionary<string, int, string>(true);

        trainers.Add("Data Structures and Algorithms", 6, "Nikolay Kostov");
        trainers.Add("JavaScript Applications", 6, "Doncho Minkov");

        Console.WriteLine("Count:");
        Console.WriteLine(trainers.Count);

        Console.WriteLine("Adding:");
        Console.WriteLine(string.Join(Environment.NewLine, trainers.GetByFirstKey("JavaScript Applications")));
        Console.WriteLine(string.Join(Environment.NewLine, trainers.GetBySecondKey(6)));

        Console.WriteLine("Removing:");
        trainers.RemoveBySecondKey(6);
        Console.WriteLine(trainers.Count);
    }
}
