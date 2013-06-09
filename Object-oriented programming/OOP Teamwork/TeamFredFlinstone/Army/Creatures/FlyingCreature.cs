using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;
using CustomExceptions;

namespace Army
{
    public abstract class FlyingCreature : Creature, IFlyable
    {
        private MatrixCoords flyingSpeed;
        public FlyingCreature(int health, int attackPoints, int defencePoints, int experience, int magicPower, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, magicPower, range, coordinates, speed)
        {
            flyingSpeed = new MatrixCoords((int)(2 * 0.01 * this.Experience) * this.Speed.Rows, (int)(2 * 0.01 * this.Experience)*this.Speed.Cols);
        }


        public MatrixCoords FlyingSpeed
        {
            get
            {
                return this.flyingSpeed;
            }
            protected set
            {
                this.flyingSpeed = value;
            }
        }

        public virtual void Fly(Direction direction, Map map)
        {
            MatrixCoords oldCoords = this.Coordinates;
            if ((this.Coordinates.Rows < 0) || (this.Coordinates.Rows < 0) ||
                (this.Coordinates.Rows > map.Size.Rows) || (this.Coordinates.Cols > map.Size.Cols))
            {
                this.Coordinates = oldCoords;
                throw new ImpossibleActionException("Move", "unit moves outside the limits of the map.");
            }
            switch (direction)
            {
                case Direction.Up: this.Coordinates += this.FlyingSpeed.Cols * DirectionCoords.Up;
                    break;
                case Direction.Down: this.Coordinates += this.FlyingSpeed.Cols * DirectionCoords.Down;
                    break;
                case Direction.Left: this.Coordinates += this.FlyingSpeed.Rows * DirectionCoords.Left;
                    break;
                case Direction.Right: this.Coordinates += this.FlyingSpeed.Rows * DirectionCoords.Right;
                    break;
                case Direction.UpLeft: this.Coordinates += this.FlyingSpeed.Rows * DirectionCoords.Left + this.FlyingSpeed.Cols * DirectionCoords.Up;
                    break;
                case Direction.DownLeft: this.Coordinates += this.FlyingSpeed.Rows * DirectionCoords.Left + this.FlyingSpeed.Cols * DirectionCoords.Down;
                    break;
                case Direction.UpRight: this.Coordinates += this.FlyingSpeed.Rows * DirectionCoords.Right + this.FlyingSpeed.Cols * DirectionCoords.Up;
                    break;
                case Direction.DownRight: this.Coordinates += this.FlyingSpeed.Rows * DirectionCoords.Right + this.FlyingSpeed.Cols * DirectionCoords.Down;
                    break;
                default:
                    break;
            }

            // After each turn of flying, reduce the flying power by one unit
            this.MagicPower--;
        }
    }
}
