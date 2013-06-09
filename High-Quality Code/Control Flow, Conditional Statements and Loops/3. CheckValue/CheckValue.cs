using System;

public class CheckValue
{
    public static void Main()
    {
        int[] array = new int[15];
        array[10] = 666;
        int expectedValue = 666;
        bool valueFound = false;

        for (int i = 0; i < array.Length; i++)
        {
            Console.WriteLine(array[i]);
            if (i % 10 == 0)
            {
                if (array[i] == expectedValue)
                {
                    valueFound = true;
                    //// Do not break until the whole array has been printed
                }
            }
        }

        if (valueFound)
        {
            Console.WriteLine("Value Found");
        }
    }
}
