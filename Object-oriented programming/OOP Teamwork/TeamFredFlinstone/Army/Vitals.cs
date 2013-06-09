using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public struct Vitals
    {
        private int health;

        public int Health
        {
            get
            {
                return this.health;
            }
            private set
            {
                this.health = value;
            }
        }

        private int attack;

        public int Attack
        {
            get
            {
                return this.attack;
            }
            set
            {
                this.attack = value;
            }
        }

        private int defense;

        public int Defense
        {
            get
            {
                return this.defense;
            }
            private set
            {
                this.defense = value;
            }
        }

        private int speed;

        public int Speed
        {
            get
            {
                return this.speed;
            }
            private set
            {
                this.speed = value;
            }
        }

        public Vitals(int health, int attack, int defense, int speed) : this()
        { 
            this.Attack = attack;
            this.Defense = defense;
            this.Health = health;
            this.Speed = speed;
        }
    }
}