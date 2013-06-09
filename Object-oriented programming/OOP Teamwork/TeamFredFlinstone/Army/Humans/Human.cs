using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public abstract class Human : MovingObject, IMovable, IAttackable, IDefendable
    {
        private int stamina;
        const string identifier = "Human";

        
        public virtual int BonusDamage
        {
            get
            {
                return this.Vitals.AttackPoints * (this.Stamina / 10);
            }
        }

        public int Stamina
        {
            get
            {
                return this.stamina;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Stamina must be a positive number or zero!");
                }
                this.stamina = value;
            }
        }

        public Human(int health, int attackPoints, int defencePoints, int experience, int stamina, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
            this.Stamina = stamina;
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder(base.ToString());
            str.AppendLine(String.Format("With Stamina:{0}", this.Stamina));
            return str.ToString();
        }
                
    }
}