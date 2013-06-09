using System;
class CalculateBonusScores
{
    static void Main()
    {
        Console.WriteLine("Enter score (between 1 and 9, inclusive): ");
        byte score = byte.Parse(Console.ReadLine());
        int finalScore = 0;
        switch (score)
        {
            case 1:
            case 2:
            case 3:
                finalScore = score * 10;
                Console.WriteLine("The final score is {0}", finalScore);
                break;
            case 4:
            case 5:
            case 6:
                finalScore = score * 100;
                Console.WriteLine("The final score is {0}", finalScore);
                break;
            case 7:
            case 8:
            case 9:
                finalScore = score * 1000;
                Console.WriteLine("The final score is {0}", finalScore);
                break;
            default:
                Console.WriteLine("You entered a wrong number.");
                break;
        }
    }
}
