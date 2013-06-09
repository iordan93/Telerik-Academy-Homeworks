using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    interface IAttackable
    {
        void Attack(ArmyObject enemy);
    }
}