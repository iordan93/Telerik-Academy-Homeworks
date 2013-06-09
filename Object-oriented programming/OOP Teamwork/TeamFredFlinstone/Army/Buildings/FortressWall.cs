using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class FortressWall : BattleBuilding
    {
        const string identifier = "FortressWall";

        public FortressWall(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }

        public override void Defend(ArmyObject enemy)
        {
            base.Defend(enemy);
            // Additional experience when defending a fortress wall, regardess of the result of the battle
            this.Experience += (int)(0.5 * this.BonusDefence);
            SetLevel();
        }
    }
}