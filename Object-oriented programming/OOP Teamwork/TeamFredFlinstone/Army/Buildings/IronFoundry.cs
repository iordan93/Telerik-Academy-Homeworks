using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class IronFoundry : ProductionBuilding
    {
        const string identifier = "IronFoundry";

        public IronFoundry(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }

        public int ProduceIron()
        {
            Random rand = new Random();
            int next = rand.Next(5, 17);
            this.Experience += (int)(0.28 * next);
            return next;
        }
    }
}