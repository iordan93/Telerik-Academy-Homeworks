namespace _1.Methods
{
    using System;

    public class StatisticsUtilities
    {
        public static int FindMax(params int[] elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException("elements");
            }

            if (elements.Length == 0)
            {
                throw new ArgumentException("There are no input elements.");
            }

            int max = int.MinValue;
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }
    }
}
