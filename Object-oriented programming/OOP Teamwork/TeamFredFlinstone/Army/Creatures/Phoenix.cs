using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Phoenix : FlyingCreature
    {
        const string identifier = "Phoenix";

        public Phoenix(int health, int attackPoints, int defencePoints, int experience, int magicPower, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, magicPower, range, coordinates, speed)
        {
        }

        public override void Fly(Direction direction, Map map)
        {
            // The pegasus is able to fly if its magic power is currently more than 20 units and it is reduced by two units in each turn
            if (MagicPower > 20)
            {
                base.Fly(direction, map);
                this.MagicPower--;
            }
            else
            {
                Console.WriteLine("Unable to fly - too little magic power.");
            }
        }
    }
}