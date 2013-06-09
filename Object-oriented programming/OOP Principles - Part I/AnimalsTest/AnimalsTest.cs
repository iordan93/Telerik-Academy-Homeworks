using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3.Animals;

namespace AnimalsTest
{
    class AnimalsTest
    {
        static void Main()
        {
            Dog[] dogs = 
            {
                new Dog("Sharo"), 
                new Dog("Lucky", 3, Gender.Male), 
                new Dog("Lassie", 15, Gender.Female) 
            };
            Cat[] cats = 
            {
                new Cat("Felix",5,Gender.Male),
                new Cat("Johnatan",8)
                // new Tomcat() and new Kitten() are also allowed but not consistent with the given task
            };
            Frog[] frogs = 
            {
                new Frog("My frog",2, Gender.Male),
                new Frog("Your frog",1, Gender.Female),
                new Frog("A frog", 5),
                new Frog("Another frog")
            };
            Kitten[] kittens = 
            {
                new Kitten("Kitty",5),
                new Kitten("Pussycat",6)
            };
            Tomcat[] tomcats = 
            {
                new Tomcat("Alex", 5),
                new Tomcat("Mephisto", 8),
                new Tomcat("Michael", 9)
            };

            // Calculate the average age of each group using a static method
            Console.WriteLine("Average age of dogs: {0}", Animal.AverageAge(dogs));
            Console.WriteLine("Average age of cats: {0}", Animal.AverageAge(cats));
            Console.WriteLine("Average age of frogs: {0}", Animal.AverageAge(frogs));
            Console.WriteLine("Average age of kittens: {0}", Animal.AverageAge(kittens));
            Console.WriteLine("Average age of tomcats: {0}", Animal.AverageAge(tomcats));

        }
    }
}
