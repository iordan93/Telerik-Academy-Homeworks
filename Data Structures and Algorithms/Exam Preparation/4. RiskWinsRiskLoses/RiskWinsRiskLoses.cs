namespace _4.RiskWinsRiskLoses
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class RiskWinsRiskLoses
    {
        public static void Main()
        {
#if DEBUG
            Console.SetIn(new System.IO.StreamReader("../../input.txt"));
#endif
            string startCombination = Console.ReadLine();
            string endCombination = Console.ReadLine();

            int forbiddenCombinationsCount = int.Parse(Console.ReadLine());

            HashSet<string> visited = new HashSet<string>();
            for (int i = 0; i < forbiddenCombinationsCount; i++)
            {
                visited.Add(Console.ReadLine());
            }

            Queue<Tuple<string, int>> queue = new Queue<Tuple<string, int>>();
            queue.Enqueue(Tuple.Create<string, int>(startCombination, 0));
            visited.Add(startCombination);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                if (current.Item1 == endCombination)
                {
                    Console.WriteLine(current.Item2);
                    return;
                }

                StringBuilder next = new StringBuilder(current.Item1);
                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit++;
                    if (digit == 10)
                    {
                        digit = 0;
                    }

                    next[i] = (char)(digit + '0');
                    string newCombination = next.ToString();
                    if (!visited.Contains(newCombination))
                    {
                        visited.Add(newCombination);
                        queue.Enqueue(Tuple.Create<string, int>(newCombination, current.Item2 + 1));
                    }

                    next[i] = current.Item1[i];
                }

                for (int i = 0; i < 5; i++)
                {
                    int digit = current.Item1[i] - '0';
                    digit--;
                    if (digit == -1)
                    {
                        digit = 9;
                    }

                    next[i] = (char)(digit + '0');
                    string newCombination = next.ToString();
                    if (!visited.Contains(newCombination))
                    {
                        visited.Add(newCombination);
                        queue.Enqueue(Tuple.Create<string, int>(newCombination, current.Item2 + 1));
                    }

                    next[i] = current.Item1[i];
                }
            }

            Console.WriteLine(-1);
        }
    }
}