namespace _2.AcademyTasks
{
    using System;
    using System.Collections.Generic;

    public class AcademyTasks
    {
        private static List<int> pleasantness = new List<int>();
        private static int variety;
        private static int bestSolution;
        private static int maxIndex;

        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            string[] pleasantnessAsString = Console.ReadLine().Split(new string[] { ", " }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var task in pleasantnessAsString)
            {
                pleasantness.Add(int.Parse(task));
            }

            variety = int.Parse(Console.ReadLine());

            bestSolution = pleasantness.Count;

            int currentMin = pleasantness[0];
            int currentMax = pleasantness[0];
            maxIndex = -1;

            for (int i = 0; i < pleasantness.Count; i++)
            {
                currentMin = Math.Min(currentMin, pleasantness[i]);
                currentMax = Math.Max(currentMax, pleasantness[i]);

                if (currentMax - currentMin >= variety)
                {
                    maxIndex = i;
                    break;
                }
            }

            if (maxIndex == -1)
            {
                Console.WriteLine(pleasantness.Count);
                return;
            }

            Solve(0, pleasantness[0], pleasantness[0], 1);
            Console.WriteLine(bestSolution);
        }

        private static void Solve(int currentIndex, int currentMin, int currentMax, int tasksSolved)
        {
            if (currentMax - currentMin >= variety)
            {
                bestSolution = Math.Min(bestSolution, tasksSolved);
                return;
            }

            if (currentIndex >= maxIndex)
            {
                return;
            }

            for (int i = 2; i >= 1; i--)
            {
                if (currentIndex + i < pleasantness.Count)
                {
                    Solve(
                        currentIndex + i,
                        Math.Min(currentMin, pleasantness[currentIndex + i]),
                        Math.Max(currentMax, pleasantness[currentIndex + i]),
                        tasksSolved + 1);

                    if (bestSolution != pleasantness.Count)
                    {
                        return;
                    }
                }
            }
        }
    }
}