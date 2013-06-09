using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.TelerikLogo
{
    class Program
    {
        static void Main()
        {
            int x = int.Parse(Console.ReadLine());
            for (int row = 1; row <= x-1; row++)
            {
                string dotsBefore = new string('.', row - 1);
                string dotsAfter = new string('.', x- row - 1);
                string star = new string('*', 1);
                Console.WriteLine("{0}{1}{2}", dotsBefore,star,dotsAfter);
            }
            //string dots = new string('.', x);
            //string stars = new string('*', 1);
            //Console.WriteLine("{0}{1}{2}", dots, stars, dots);
            //for (int row = 2; row < x; row++)
            //{
            //    string dotsAfter = new string('.', row - 1);
            //    string dotsBefore = new string('.', x - row);
            //    string star = new string('*', 1);
            //    string dotsAfter2 = new string('.', row-1);

            //    Console.WriteLine("{0}{1}{2}",dotsBefore,star,dotsAfter);
            //    //Console.WriteLine("{0}{1}{2}", dotsAfter2, star, dotsBefore);
            //}
            //for (int row = x; row >= 2; row--)
            //{
            //    string dotsAfter = new string('.', row - 1);
            //    string dotsBefore = new string('.', x - row);
            //    string star = new string('*', 1);
            //    Console.WriteLine("{0}{1}{2}", dotsBefore, star, dotsAfter);
            //    //Console.WriteLine("{0}{1}{2}", dotsAfter, star, dotsBefore);
            //}
            //Console.WriteLine("{0}{1}{2}", dots, stars, dots);
        }
    }
}
