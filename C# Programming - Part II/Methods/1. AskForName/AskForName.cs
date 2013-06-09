using System;
class AskForName
{
    static string AskUserForName()
    {
        Console.Write("What is your name? ");
        string name = Console.ReadLine();
        return name;
    }

    static void Main(string[] args)
    {
        Console.WriteLine("This program will ask the user for his or her name and will print a welcome message.");
        string name = AskUserForName();
        Console.WriteLine("Hello, {0}!", name);
    }
}