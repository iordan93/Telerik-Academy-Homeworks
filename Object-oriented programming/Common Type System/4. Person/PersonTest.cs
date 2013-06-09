using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4.Person
{
    class PersonTest
    {
        static void Main()
        {
            Person person = new Person("Ivan Ivanov", 43);
            Person otherPerson = new Person("Vasil Nikolov");

            Console.WriteLine(person);
            Console.WriteLine();
            Console.WriteLine(otherPerson);
        }
    }
}
