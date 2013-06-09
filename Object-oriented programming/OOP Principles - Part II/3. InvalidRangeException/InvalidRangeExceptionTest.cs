using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.InvalidRangeException
{
    class InvalidRangeExceptionTest
    {
        static void Main()
        {
            // Test for integer type
            Console.Write("Please enter a number in the range [0; 100]: ");
            int number = int.Parse(Console.ReadLine());
            if (number < 0 || number > 100)
            {
                throw new InvalidRangeException<int>(0, 100);
            }
            else
                Console.WriteLine("The integer you entered is valid.");

            // Test for DateTime type
            Console.Write("Please enter a date between 1.1.1980 and 31.12.2013: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            if (date < new DateTime(1980, 1, 1) || date > new DateTime(2013, 12, 31))
            {
                throw new InvalidRangeException<DateTime>(new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
            }
            else
                Console.WriteLine("The date you entered is valid.");
        }
    }
}
