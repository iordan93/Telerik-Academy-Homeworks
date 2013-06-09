using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Fireship : Ship
    {
        const string identifier = "Fireship";

        public Fireship(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed, int fuel, int ammo)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed, fuel, ammo)
        {
        }

        // Fireships can also autoignite with 5% probability
        public override void Attack(ArmyObject enemy)
        {
            if (!(this.Autoignite()))
                base.Attack(enemy);
            else
                base.Attack(this);
        }

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
