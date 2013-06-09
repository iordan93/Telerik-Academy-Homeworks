using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;
using CustomExceptions;

namespace Army
{
    public class BatteringRam : Machine
    {
        const string identifier = "BatteringRam";

        public BatteringRam(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed, int fuel, int ammo)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed, fuel, ammo)
        {
        }

        // Ram only attacks buildings
        public override void Attack(ArmyObject enemy)
        {
            if (!(enemy is Building))
                // Here we should throw our exception after it is implemented.
                throw new ImpossibleActionException("attack", "ram only attacks buildings");
            base.Attack(enemy);
        }
    }
}
