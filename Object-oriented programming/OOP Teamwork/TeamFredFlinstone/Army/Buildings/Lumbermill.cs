using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Lumbermill : ProductionBuilding
    {
        const string identifier = "Lumbermill";

        public Lumbermill(int health, int attackPoints, int defencePoints, int experience,int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }

        public int ProduceTimber()
        {
            Random rand = new Random();
            int next = rand.Next(5, 31);
            this.Experience += (int)(0.31 * next);
            return next;
        }
    }
}