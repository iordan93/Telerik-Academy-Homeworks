using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public delegate void HealingHandler(object sender, HealingArgs e);

    public class HealingBuilding : Building
    {
        public event HealingHandler HealingInitiation;

        private int healthPower;

        public int HealthPower
        {
            get { return healthPower; }
            private set { healthPower = value; }
        }

        public HealingBuilding(int health, int attack, int defence, int experience, int range, MatrixCoords coord,
            MatrixCoords speed, int healthPower)
            : base(health, attack, defence, experience, range, coord, speed)
        {
            this.HealthPower = healthPower;
        }

        public void HealUnits()
        {
            HealingHandler handler = this.HealingInitiation;
            Random rand = new Random();
            if (handler != null)
                handler(this, new HealingArgs(rand.Next(1, 3) * this.HealthPower));
        }
    }
}
