using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Knight : Human
    {
        const string identifier = "Knight";

        public Knight(int health, int attackPoints, int defencePoints, int experience, int stamina, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, stamina, range, coordinates, speed)
        {
        }
    }
}