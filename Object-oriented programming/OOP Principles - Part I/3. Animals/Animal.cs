using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3.Animals
{
    public abstract class Animal : ISound
    {
        // Private fields
        private string name;
        private int age;
        private Gender gender;

        // Public properties to encapsulate the fields
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value >= 0)
                {
                    this.age = value;
                }
                else throw new ArgumentOutOfRangeException("The age of an animal must be nonnegative.");
            }
        }

        public Gender Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        // This constructor can be used from all deriving classes
        public Animal(string name, int age, Gender gender) 
        {
            this.Name = name;
            this.Age = age;
            this.Gender = gender;
        }

        // Method
        // Calculate the average age of each animal (a static method)
        public static double AverageAge(Animal[] animals) 
        {
            return animals.Average(x => x.Age);
        }

        // The sound is different for each animal, so the method will be applied differently
        public abstract void ProduceSound();
        
    }
}
