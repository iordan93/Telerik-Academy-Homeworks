using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class UnstoppableBall : Ball
    {
        public new const string CollisionGroupString = "unstoppableBall";

        // Constructor - make the body of the unstoppable ball different
        public UnstoppableBall(MatrixCoords topLeft, MatrixCoords speed)
            : base(topLeft, speed)
        {
            this.body = new char[,] { { 'O' } };
        }

        // The things the ball can collide with (the same as in Ball, but the ball also collided with indestructable and unpassable blocks)
        public override bool CanCollideWith(string otherCollisionGroupString)
        {
            return otherCollisionGroupString == "racket" ||
                   otherCollisionGroupString == "block" ||
                   otherCollisionGroupString == "indestructableBlock" ||
                   otherCollisionGroupString == "unpassableBlock";
        }

        public override string GetCollisionGroupString()
        {
            return UnstoppableBall.CollisionGroupString;
        }

        // If the ball hits a racket or an unpassable block, it should reflect
        // Otherwise it will continue straight ahead
        // I am not really sure whether an unstoppable ball should destroy an indestructible block, so I am letting it pass through it as if through air
        public override void RespondToCollision(CollisionData collisionData)
        {
            for (int i = 0; i < collisionData.hitObjectsCollisionGroupStrings.Count; i++)
            {
                if (collisionData.hitObjectsCollisionGroupStrings[i] == "racket" ||
                    collisionData.hitObjectsCollisionGroupStrings[i] == "unpassableBlock")
                {
                    if (collisionData.CollisionForceDirection.Row * this.Speed.Row < 0)
                    {
                        this.Speed.Row *= -1;
                    }
                    if (collisionData.CollisionForceDirection.Col * this.Speed.Col < 0)
                    {
                        this.Speed.Col *= -1;
                    }
                }
            }
        }

    }
}
