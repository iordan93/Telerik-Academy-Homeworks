using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Nomad : Human
    {
        const string identifier = "Nomad";

        public Nomad(int health, int attackPoints, int defencePoints, int experience, int stamina, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, stamina, range, coordinates, speed)
        {
        }

        public new void Attack(ArmyObject enemy)
        {
        }
    }
}