using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Tent : BattleBuilding
    {
        const string identifier = "Tent";

        public Tent(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }
    }
}