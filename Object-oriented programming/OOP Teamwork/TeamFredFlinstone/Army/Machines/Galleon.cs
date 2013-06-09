using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Galleon : Ship
    {
        const string identifier = "Galleon";

        public Galleon(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed, int fuel, int ammo)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed, fuel, ammo)
        {
        }

        public override void Attack(ArmyObject enemy)
        {
            base.Attack(enemy);
            base.Attack(enemy);
        }
    }
}
