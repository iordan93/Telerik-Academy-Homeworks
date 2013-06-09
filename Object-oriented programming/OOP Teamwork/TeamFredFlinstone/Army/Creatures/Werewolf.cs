using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Werewolf : Creature
    {
        const string identifier = "Werewolf";

        public Werewolf(int health, int attackPoints, int defencePoints, int experience, int magicPower, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, magicPower, range, coordinates, speed)
        {
        }
    }
}