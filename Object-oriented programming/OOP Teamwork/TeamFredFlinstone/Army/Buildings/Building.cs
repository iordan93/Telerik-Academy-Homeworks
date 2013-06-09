using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;
using CustomExceptions;

namespace Army
{
    public abstract class Building : ArmyObject, IDefendable
    {
        const string identifier = "Building";

        public Building(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }

        // Default reduction of health for buildings
        public override void Defend(ArmyObject enemy)
        {
            if (enemy.Vitals.DefencePoints <= this.Vitals.AttackPoints)
            {
                // Enemy is weaker
                enemy.ReduceHealth((int)(0.4 * (this.Vitals.AttackPoints - enemy.Vitals.AttackPoints) + 0.3 * (this.Health)));
                this.Experience += (int)(0.15 * (this.Health + 0.37 * this.Level) + 0.51 * this.Vitals.DefencePoints);
                SetLevel();
            }
            else
            {
                // Enemy is stronger - reflect a part of the attack
                this.ReduceHealth((int)(0.2 * (enemy.Vitals.AttackPoints - this.Vitals.AttackPoints) + 0.1 * (enemy.Health)));
                this.Experience += (int)(0.1 * (this.Health + 0.05 * this.Level) + 0.09 * this.Vitals.DefencePoints);
                SetLevel();
            }
        }

        public override void Attack(ArmyObject enemy)
        {
            throw new ImpossibleActionException("Attack", "non-battle buildings cannot attack");
        }
    }
}