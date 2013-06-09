using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Tower : BattleBuilding
    {
        const string identifier = "Tower";

        public Tower(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }
    }
}