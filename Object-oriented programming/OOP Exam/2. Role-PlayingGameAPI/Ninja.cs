using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyRPG
{
    class Ninja : Fighter, IFighter, IGatherer
    {
        public Ninja(string name, Point position, int owner)
            : base(name, position, owner)
        {
            this.HitPoints = 1;
        }
        private int attackPoints = 0;
        public new int AttackPoints
        {
            get
            {
                return this.attackPoints;
            }
            private set
            {
                this.attackPoints = value;
            }
        }

        public int DefensePoints
        {
            get { return int.MaxValue; }
        }

        public int GetTargetIndex(List<WorldObject> availableTargets)
        {
            for (int i = 0; i < availableTargets.Count; i++)
            {
                if (availableTargets[i].Owner != this.Owner && availableTargets[i].Owner != 0)
                {
                    int max = int.MinValue;
                    int index = 0;
                    for (int target = 0; target < availableTargets.Count; target++)
                    {
                        if (availableTargets[target].HitPoints>max)
                        {
                            max = availableTargets[target].HitPoints;
                            index = target;
                        }
                    }
                    return index;
                }
            }

            return -1;
        }

        public bool TryGather(IResource resource)
        {
            if (resource.Type == ResourceType.Stone)
            {
                this.AttackPoints += resource.Quantity * 2;
                return true;
            }

            if (resource.Type == ResourceType.Lumber)
            {
                this.AttackPoints += resource.Quantity;
                return true;
            }

            return false;
        }

        public override string Name
        {
            get { throw new NotImplementedException(); }
        }

        public override bool IsDestroyed
        {
            get { throw new NotImplementedException(); }
        }

        public override int HitPoints
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override Point Position
        {
            get { throw new NotImplementedException(); }
        }
    }
}
