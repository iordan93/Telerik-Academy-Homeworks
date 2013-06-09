using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Catapult : Machine
    {
        const string identifier = "Catapult";

        public Catapult(int health, int attackPoints, int defencePoints, int experience, int fuel, int ammo, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience,range, coordinates, speed, fuel, ammo)
        {
        }
    }
}
