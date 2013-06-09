using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class Gift:MovingObject
    {
        // Constructor
        public Gift(MatrixCoords topLeft)
            : base(topLeft, new char[,] { { '@' } }, new MatrixCoords(1, 0))
        {
        }

        // The gift can only collide with the racket and when it collides, it is destroyed
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket";
        }

        public override void RespondToCollision(CollisionData collisionData)
        {
            this.IsDestroyed = true;
        }

        // The gift produces a new shooting racket after it has collided with the old, normal one
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> newRacket = new List<GameObject>();
            if (this.IsDestroyed)
            {
                newRacket.Add(new ShootingRacket(new MatrixCoords(this.topLeft.Row + 1, this.topLeft.Col), 6));
            }
            return newRacket;
        }
    }
}
