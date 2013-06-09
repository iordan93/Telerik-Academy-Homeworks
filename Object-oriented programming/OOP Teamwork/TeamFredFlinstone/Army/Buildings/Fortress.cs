using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Fortress : BattleBuilding
    {
        const string identifier = "Fortress";

        public Fortress(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }

        public override void Defend(ArmyObject enemy)
        {
            base.Defend(enemy);
            // Additional experience when defending a fortress, regardess of the result of the battle
            this.Experience += (int)(0.65 * this.BonusDefence + 0.3 * this.Vitals.DefencePoints);
            SetLevel();
        }
    }
}