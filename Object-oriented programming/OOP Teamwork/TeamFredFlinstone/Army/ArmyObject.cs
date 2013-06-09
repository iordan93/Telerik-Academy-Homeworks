using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;
using LevelManager;
using CustomExceptions;

namespace Army
{
    public abstract class ArmyObject
    {
        private int health;
        private int experience;
        private Stats vitals;
        private MatrixCoords coordinates;
        private MatrixCoords speed;
        const string identifier = "ArmyObject";
        private int level;
        private bool isDead;

        public virtual int BonusAttack
        {
            get
            {
                return 0;
            }
        }

        public virtual int BonusDefence
        {
            get
            {
                return 0;
            }
        }

        public int Health
        {
            get
            {
                return this.health;
            }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Health points must be a positive number!");
                }
                this.health = value;
            }
        }

        public int Experience
        {
            get
            {
                return this.experience;
            }
            protected set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Experience points must be a positive number or zero!");
                }
                this.experience = value;
            }
        }

        public Stats Vitals
        {
            get
            {
                return vitals;
            }
            set
            {
                vitals = value;
            }
        }

        public MatrixCoords Coordinates
        {
            get
            {
                return this.coordinates;
            }
            protected set
            {
                this.coordinates = value;
            }
        }

        public MatrixCoords Speed
        {
            get
            {
                return this.speed;
            }
            protected set
            {
                this.speed = value;
            }
        }

        public int Level
        {
            get
            {
                return this.level;
            }
            internal set
            {
                this.level = value;
            }
        }

        protected ArmyObject(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
        {
            this.Health = health;
            this.Experience = experience;
            this.Vitals = new Stats(attackPoints, defencePoints, range);
            this.Coordinates = coordinates;
            this.Speed = speed;
            this.isDead = false;
        }

        public void ReduceHealth(int reduction)
        {
            if (reduction > 0)
            {
                try
                {
                    this.Health -= reduction;
                    Console.WriteLine("Health of {0} reduced by {1}", this.GetType().Name, reduction);
                    SetLevel();
                }
                catch (ArgumentException e)
                {

                }
            }
        }

        // Attack method that has a 90% chance of working and, if successful, calls the defend method of the
        // attacked unit to calculate the damage, if any. After levelling is implemented, the chance of 
        // successful attack may depend on the level, but not too heavily otherwise the game will be unbalanced.
        public virtual void Attack(ArmyObject enemy)
        {
            Console.WriteLine("{0} is attacking {1}.", this.GetType().Name, enemy.GetType().Name);
            if (Levels.CalculateDistance(this.Coordinates, enemy.Coordinates) > this.Vitals.Range)
                throw new ImpossibleActionException("Attack", "enemy is out of range");
            Random rand = new Random();
            int number = rand.Next(1, 100);
            if (number > 10)
            {
                enemy.Defend(this);
                this.Experience += (int)(0.18 * this.Health + 0.05 * this.Level + 0.81 * this.Vitals.AttackPoints + 
                                   0.23 * this.Vitals.DefencePoints + 0.27 * this.Vitals.Range);
            }
            else
            {
                Console.WriteLine("Attack was unsuccessful.");
                this.Experience += (int)(0.2 * this.Health + 0.02 * this.Level + 0.01 * this.Vitals.DefencePoints);
            }
            SetLevel();
        }

        public virtual void Defend(ArmyObject enemy)
        {

            if (enemy.Vitals.AttackPoints + enemy.BonusAttack - this.BonusDefence - this.Vitals.DefencePoints <=0)
            {
                this.ReduceHealth(1);
            }
            else
            {
                this.ReduceHealth(enemy.Vitals.AttackPoints + enemy.BonusAttack - this.BonusDefence - this.Vitals.DefencePoints);
            }
            SetLevel();
        }

        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.AppendLine(String.Format("{0}:", this.GetType().Name));
            str.AppendLine(String.Format("Health: {0} | Attack: {1} | Defence: {2} | Range: {3}", this.Health, this.Vitals.AttackPoints, this.Vitals.DefencePoints, this.Vitals.Range));
            str.AppendLine(String.Format("At coordinates:({0}, {1})", this.Coordinates.Rows, this.Coordinates.Cols));
            return str.ToString();
        }

        public override bool Equals(object obj)
        {
            ArmyObject secondObject = obj as ArmyObject;
            if (secondObject == null)
                return false;
            else
                return (this.Health == secondObject.Health) && (this.Vitals.AttackPoints == secondObject.Vitals.AttackPoints)
                    && (this.Vitals.DefencePoints == secondObject.Vitals.DefencePoints) && (this.Vitals.Range == secondObject.Vitals.Range);
        }

        public override int GetHashCode()
        {
            return this.Health.GetHashCode() ^ this.Vitals.Range.GetHashCode();
        }

        private void Battlecry<T>(T sender, EventArgs e) where T : INameable
        {
            Console.WriteLine("{0}: Is in formation {1}", this.GetType().Name, sender.GetName());
        }

        public void EnterFormation(Formation form)
        {
            form.FormationConfirmation += this.Battlecry<Formation>;
        }

        // Set the level of a unit - the level should be set each time when there is change of experience
        public void SetLevel()
        {
            //Levels.GetLevels();
            for (int i = 1; i < Levels.LevelsXP.Length - 1; i++)
            {
                if (this.Experience >= Levels.LevelsXP[i] && this.Experience < Levels.LevelsXP[i + 1])
                {
                    this.Level = i;
                    return;
                }
            }
        }

        public void SubscribeToHealing(HealingBuilding building)
        {
            building.HealingInitiation += this.Heal;
        }

        private void Heal(object sender, HealingArgs e)
        {
            this.Health += e.Power;
            Console.WriteLine("{0} healed by {1}", this.GetType().Name, e.Power);
        }
    }
}