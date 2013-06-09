﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public class Cat : Animal
    {
        // Constructor with two optional parameters (somewhat better than overloading the constructor)
        public Cat(string name, int age = 0, Gender gender = Gender.Male)
            : base(name, age, gender)
        {
        }

        // Required by the ISound interface
        public override void ProduceSound()
        {
            Console.WriteLine("Meow, meow!");
        }
    }
}
