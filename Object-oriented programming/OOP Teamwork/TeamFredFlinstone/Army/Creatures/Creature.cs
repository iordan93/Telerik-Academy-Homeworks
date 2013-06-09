using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public abstract class Creature : MovingObject, IAttackable, IDefendable
    {
        private int magicPower;

        public override int BonusAttack
        {
            get
            {
                return (this.Vitals.AttackPoints * (this.MagicPower / 100));
            }
        }

        public int MagicPower
        {
            get
            {
                return this.magicPower;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Magic power must be a positive number or zero!");
                }
                this.magicPower = value;
            }
        }

        const string identifier = "Creature";

        public Creature(int health, int attackPoints, int defencePoints, int experience, int magicPower, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
            this.MagicPower = magicPower;
        }
    }
}
