using System;
using System.Threading;
using System.Globalization;

    class SubsetSums
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            //Read input
            long sum = long.Parse(Console.ReadLine());
            int n = int.Parse(Console.ReadLine());
            long[] numbers = new long[n];
            for (int index = 0; index < n; index++)
            {
                numbers[index] = long.Parse(Console.ReadLine());
            }
            int subsetSum = 0;

            //Make all possible sums and check them
            for (int i = 1; i < ((int)Math.Pow(2,n)); i++)
            {
                long currentSum = 0;
                for (int j = 1; j <= n; j++)
                {
                    if (((i>>(j-1)) & 1) == 1)
                    {
                        currentSum += numbers[j-1];
                    }
                    
                }
                if (currentSum == sum)
                    {
                        subsetSum++;
                    }
            }
            Console.WriteLine(subsetSum);
        }
    }