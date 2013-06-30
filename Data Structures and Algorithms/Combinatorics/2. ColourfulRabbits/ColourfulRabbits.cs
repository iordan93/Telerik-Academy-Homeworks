using System;
using System.Collections.Generic;

public class ColourfulRabbits
{
    public static void Main()
    {
        int askedRabbits = int.Parse(Console.ReadLine());
        int[] answers = new int[askedRabbits];
        for (int i = 0; i < askedRabbits; i++)
        {
            answers[i] = int.Parse(Console.ReadLine());
        }

        Dictionary<int, int> groups = new Dictionary<int, int>();
        for (int i = 0; i < askedRabbits; i++)
        {
            if (groups.ContainsKey(answers[i] + 1))
            {
                groups[answers[i] + 1]++;
            }
            else
            {
                groups[answers[i] + 1] = 1;
            }
        }

        int minRabbits = 0;
        foreach (var key in groups.Keys)
        {
            double averageRabitsPerGroup = (double)groups[key] / key;
            minRabbits += (int)Math.Ceiling(averageRabitsPerGroup) * key;
        }

        Console.WriteLine(minRabbits);
    }
}
