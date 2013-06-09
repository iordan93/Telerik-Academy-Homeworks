using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class GoldMine : ProductionBuilding
    {
        const string identifier = "GoldMine";

        public GoldMine(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }

        public int ProduceGold()
        {
            Random rand = new Random();
            int next = rand.Next(5, 11);
            this.Experience += (int)(0.34 * next);
            SetLevel();
            return next;
        }
    }
}