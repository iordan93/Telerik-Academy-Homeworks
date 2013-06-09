using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;
using CustomExceptions;

namespace Army
{
    public class Ship : Machine
    {
        const string identifier = "Ship";

        public Ship(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed, int fuel, int ammo)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed, fuel, ammo)
        {
        }

        // Ships only attack other ships
        public override void Attack(ArmyObject enemy)
        {
            if (enemy is Ship)
                base.Attack(enemy);
            else
                // implement our own exception if we make one
                throw new ImpossibleActionException("Attack", "this unit can only attack other ships.");
        }

        
    }
}
