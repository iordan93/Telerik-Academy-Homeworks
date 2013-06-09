using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplosionResult : MovingObject
    {
        // Constructor - the explosion should look like %
        public ExplosionResult(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, new char[,] { { '%' } }, speed)
        {
            this.IsDestroyed = true;
        }

        // The explosion products can collide with blocks, destroying them
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block";
        }

        public override void Update()
        {
            this.IsDestroyed = true;
        }
    }
}
