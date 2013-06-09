using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public abstract class BattleBuilding : Building
    {
        const string identifier = "BattleBuilding";

        public BattleBuilding(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }

        public override void Attack(ArmyObject enemy)
        {
            Random rand = new Random();
            int number = rand.Next(1, 100);
            if (number > 10)
                enemy.Defend(this);
            else throw new ArgumentException();
        }
    }
}