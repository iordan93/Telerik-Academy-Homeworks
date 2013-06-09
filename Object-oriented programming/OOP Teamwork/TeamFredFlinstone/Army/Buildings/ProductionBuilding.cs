using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public abstract class ProductionBuilding : Building
    {
        const string identifier = "ProductionBuilding";

        public ProductionBuilding(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience,range, coordinates, speed)
        {
        }

        public override void Defend(ArmyObject enemy)
        {
            base.Defend(enemy);
        }
    }
}