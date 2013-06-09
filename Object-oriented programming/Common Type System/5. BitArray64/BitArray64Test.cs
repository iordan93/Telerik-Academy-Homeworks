using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5.BitArray64
{
    class BitArray64Test
    {
        static void Main()
        {
            BitArray64 array = new BitArray64(64);
            array[0] = 1;
            array[5] = 1;
            array[10] = 1;
            Console.WriteLine(array);
        }
    }
}
