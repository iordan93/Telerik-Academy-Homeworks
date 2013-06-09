using System;
class _3DMaxWalk
{
    static void Main()
    {
        string whd = Console.ReadLine();
        string[] dimensions = whd.Split(' ');
        int width = int.Parse(dimensions[0]);
        int height = int.Parse(dimensions[1]);
        int depth = int.Parse(dimensions[2]);
        int[, ,] arr = new int[width, height, depth];
        for (int h = 0; h < height; h++)
        {
            string line = Console.ReadLine();
            string[] sequences = line.Split('|');
            for (int d = 0; d < depth; d++)
            {
                string[] numbers = sequences[d].Split(
                    new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                for (int w = 0; w < width; w++)
                {
                    short cubeValue = short.Parse(numbers[w]);
                    arr[w, h, d] = cubeValue;
                }
            }
        }


    }
}