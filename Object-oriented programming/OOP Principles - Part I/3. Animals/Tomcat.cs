using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public class Tomcat : Cat
    {
        // Constructor with an optional parameter - gender is always male
        public Tomcat(string name, int age = 0)
            : base(name, age, Gender.Male)
        {
        }

        // We do not need to override ProduceSound(), because kittens produce the same sound as cats (the parent class)
    }
}
