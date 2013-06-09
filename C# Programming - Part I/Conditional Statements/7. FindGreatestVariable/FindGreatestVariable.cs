using System;
    class FindGreatestVariable
    {
        static void Main()
        {
            Console.WriteLine("Enter five numbers:");
            double firstNumber = double.Parse(Console.ReadLine());
            double secondNumber = double.Parse(Console.ReadLine());
            double thirdNumber = double.Parse(Console.ReadLine());
            double fourthNumber = double.Parse(Console.ReadLine());
            double fifthNumber = double.Parse(Console.ReadLine());
            double max12 = Math.Max(firstNumber, secondNumber);
            double max34 = Math.Max(thirdNumber, fourthNumber);
            if (max12 < max34)
            {
                if (max34 < fifthNumber)
                {
                    Console.WriteLine(fifthNumber);
                }
                else
                {
                    Console.WriteLine(max34);
                }
            }
            else
            {
                if (max12 < fifthNumber)
                {
                    Console.WriteLine(fifthNumber);
                }
                else
                {
                    Console.WriteLine(max12);
                }
            }
        }
    }
