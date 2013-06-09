using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;
using CustomExceptions;

namespace Army
{
    public abstract class Machine : MovingObject, IMovable, IAttackable, IDefendable
    {
        const string identifier = "Machine";
        
        // Fields and properties for fuel and ammunition of machines
        private int fuel;


        public int Fuel
        {
            get { return fuel; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Fuel cannot become a negative number.");
                fuel = value;
            }
        }

        private int ammunition;

        public int Ammunition
        {
            get { return this.ammunition; }
            protected set
            {
                if (value < 0)
                    throw new ArgumentException("Ammunition cannot become a negative number.");
                ammunition = value;
            }
        }

        // Methods for loading fuel and ammunition
        public void FillFuel(int fuel)
        {
            if (fuel < 0)
                throw new ImpossibleActionException("FillFuel", "cannot load negative amount of fuel.");
            this.Fuel += fuel;
        }

        public void LoadAmmunition(int ammo)
        {
            if (ammo < 0)
                throw new ImpossibleActionException("LoadAmmunition", "cannot load negative amount of munition.");
            this.Ammunition += ammo;
        }

        public Machine(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed, int fuel, int ammo)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
            this.Fuel = fuel;
            this.Ammunition = ammo;
        }

        public override void Attack(ArmyObject enemy)
        {
            if (this.Ammunition > 0)
            {
                this.Ammunition -= 1;
                base.Attack(enemy);
            }
            else
                // here we should throw our own exception if we make one
                throw new ImpossibleActionException("Attack","this unit cannot attack without munnition.");
        }


    }
}
