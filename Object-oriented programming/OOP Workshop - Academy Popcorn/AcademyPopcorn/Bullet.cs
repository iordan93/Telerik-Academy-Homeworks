using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class Bullet : MovingObject
    {
        // The bulet is what a shooting racket produces when it is able to shoot

        // Constructor
        public Bullet(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '.' } }, new MatrixCoords(-1, 0))
        {
        }

        // A bullet can collide with blocks (normal or gift blocks) and is destroyed upon collision
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "block" || otherCollisionGroupString == "giftBlock";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }
    }
}
