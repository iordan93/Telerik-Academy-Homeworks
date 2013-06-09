using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Army
{
    public class HealingArgs : EventArgs
    {
        private int power;

        public int Power
        {
            get { return power; }
            private set { power = value; }
        }

        public HealingArgs(int power)
            : base()
        {
            this.Power = power;
        }
    }
}
