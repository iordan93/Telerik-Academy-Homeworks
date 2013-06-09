using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class ClayMine : ProductionBuilding
    {
        const string identifier = "ClayMine";

        public ClayMine(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }

        public int ProduceClay()
        {
            Random rand = new Random();
            int next = rand.Next(5, 37);
            this.Experience += (int)(0.23 * next);
            SetLevel();
            return next;
        }
    }
}