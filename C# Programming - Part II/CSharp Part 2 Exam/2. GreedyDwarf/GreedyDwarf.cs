using System;
class GreedyDwarf
{
    static void Main()
    {
        #region Read and prepare input
        string[] valleyStr = Console.ReadLine().Split(new char[] { ',', ' ', }, StringSplitOptions.RemoveEmptyEntries);
        short[] valley = new short[valleyStr.Length];
        for (int i = 0; i < valleyStr.Length; i++)
        {
            valley[i] = short.Parse(valleyStr[i]);
        }
        int M = int.Parse(Console.ReadLine());
        short[][] patterns = new short[M][];
        for (int i = 0; i < M; i++)
        {
            string[] split = (Console.ReadLine().Split(new char[] { ',', ' ', }, StringSplitOptions.RemoveEmptyEntries));
            patterns[i] = new short[split.Length];
            for (int j = 0; j < split.Length; j++)
            {
                patterns[i][j] = short.Parse(split[j]);
            }
        }
        #endregion

        int bestPatternSum = int.MinValue;
        for (int patternNumber = 0; patternNumber < M; patternNumber++)
        {
            bool[] isVisited = new bool[valley.Length];
            int sum = 0;
            int position = 0;
            int nextPosition = 0;

            sum = valley[0];
            bool escape = false;
            int counter = 1;
            for (int index = 0; index <= patterns[patternNumber].Length; index++)
            {
                if ((!escape) && (index == patterns[patternNumber].Length))
                {
                    index = 0; // Loop
                }
                //if (index < patterns[patternNumber].Length)
                //{
                nextPosition = patterns[patternNumber][index];
                position += nextPosition;

                if ((position >= 0) && (position < valley.Length))
                {
                    if ((isVisited[position]))
                    {
                        escape = true;
                        if (bestPatternSum < sum)
                        {
                            bestPatternSum = sum;
                        }
                        break;// Middle - if visited

                    }
                    if (position == valley.Length - 1)
                    {
                        sum += valley[position];
                        escape = true;
                        if (bestPatternSum < sum)
                        {
                            bestPatternSum = sum;
                        }
                        break;// Right
                    }
                    else if ((position == 0) && (counter > 1))
                    {
                        escape = true;
                        if (bestPatternSum < sum)
                        {
                            bestPatternSum = sum;
                        }
                        break;//Left, after at least one loop
                    }
                    //if (escape)
                    //{
                    //    if (bestPatternSum < sum)
                    //    {
                    //        bestPatternSum = sum;
                    //    }
                    //    break;
                    //}
                    counter++;
                    sum += valley[position];

                    isVisited[position] = true;
                }
                else
                {
                    escape = true;
                    if (escape)
                    {
                        if (bestPatternSum < sum)
                        {
                            bestPatternSum = sum;
                        }
                        break;
                    }
                }

            }

        }
        Console.WriteLine(bestPatternSum);
    }
}
