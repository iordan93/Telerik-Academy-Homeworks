using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class FireBallThrower : Machine
    {
        const string identifier = "FireBallThrower";
        
        public FireBallThrower(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed, int fuel, int ammo)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed, fuel, ammo)
        {
        }

        // Overriding Attack method
        public override void Attack(ArmyObject enemy)
        {
            if (!(this.Autoignite()))
                base.Attack(enemy);
            else
                // not sure if this will work, must test later
                base.Attack(this);
        }

        // The fireball thrower can set itself on fire with 5% chance
        protected bool Autoignite()
        {
            Random rand = new Random();
            int number = rand.Next(1, 100);
            if (number > 5)
                return false;
            else
                return true;
        }
    }
}
