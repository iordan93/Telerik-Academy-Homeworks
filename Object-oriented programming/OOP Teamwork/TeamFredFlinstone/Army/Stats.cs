using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army
{
    public struct Stats
    {
        private int attackPoints;

        public int AttackPoints
        {
            get
            {
                return attackPoints;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Attack points must be a positive number or 0.");
                attackPoints = value;
            }
        }

        private int defencePoints;

        public int DefencePoints
        {
            get
            {
                return defencePoints;
            }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Defence points must be a positive number or 0.");
                defencePoints = value; 
            }
        }

        private int range;

        public int Range
        {
            get { return range; }
            private set { range = value; }
        }

        public Stats(int attack, int defence, int range) : this()
        {
            this.AttackPoints = attack;
            this.DefencePoints = defence;
            this.Range = range;
        }
    }
}