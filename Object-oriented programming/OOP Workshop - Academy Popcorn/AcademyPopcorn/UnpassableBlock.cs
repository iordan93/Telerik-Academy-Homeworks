using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class UnpassableBlock : Block
    {
        public new const string CollisionGroupString = "unpassableBlock";

        // Constructor
        public UnpassableBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
            this.body = new char[,] { { '+' } };
        }

        // The block does not respond to any collision, unlike its base class
        public override void RespondToCollision(CollisionData collisionData)
        {
        }

        public override string GetCollisionGroupString()
        {
            return UnpassableBlock.CollisionGroupString;
        }
    }
}
