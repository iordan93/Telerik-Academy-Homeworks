using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    public interface IFighter : IControllable
    {
        int AttackPoints
        {
            get;
        }

        int DefensePoints
        {
            get;
        }

        int GetTargetIndex(List<WorldObject> availableTargets);
    }
  
    public abstract class Fighter : Character, IFighter
    {
        public Fighter(string name, Point position, int owner):base(name, position, owner)
        {
        }

        public abstract string Name 
        {
            get;
        }

        public abstract bool IsDestroyed
        {
            get;
        }

        public abstract int HitPoints
        {
            get;
            set;
        }

        public abstract Point Position
        {
            get;
        }

        public abstract int AttackPoints
        {
            get;
        }

        public abstract int DefensePoints
        {
            get;
        }

        public virtual int GetTargetIndex(List<WorldObject> availableTargets)
        {
            return 0;
        }
    }
}
