using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    interface IMovable
    {
        void Move(Direction direction, Map map);
    }
}