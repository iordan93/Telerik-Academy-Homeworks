using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Griffin : FlyingCreature
    {
        const string identifier = "Griffin";

        public Griffin(int health, int attackPoints, int defencePoints, int experience, int magicPower, int range, MatrixCoords coordinates,MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, magicPower, range, coordinates,speed)
        {
        }

        public override void Fly(Direction direction, Map map)
        {
            // The griffin is able to fly if its magic power is currently more than 10 units
            if (MagicPower > 10)
            {
                base.Fly(direction, map);
            }
            else
            {
                Console.WriteLine("Unable to fly - too little magic power.");
            }
        }

    }
}