using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;
using CustomExceptions;

namespace Army
{
    public abstract class MovingObject : ArmyObject, IMovable
    {
        public MovingObject(int health, int attackPoints, int defencePoints, int experience, int range, MatrixCoords coordinates, MatrixCoords speed)
            : base(health, attackPoints, defencePoints, experience, range, coordinates, speed)
        {
        }

        public void Move(Direction direction, Map map)
        {
            MatrixCoords oldCoords = this.Coordinates;
            switch (direction)
            {
                case Direction.Up: this.Coordinates += this.Speed.Cols * DirectionCoords.Up;
                    break;
                case Direction.Down: this.Coordinates += this.Speed.Cols * DirectionCoords.Down;
                    break;
                case Direction.Left: this.Coordinates += this.Speed.Rows * DirectionCoords.Left;
                    break;
                case Direction.Right: this.Coordinates += this.Speed.Rows * DirectionCoords.Right;
                    break;
                case Direction.UpLeft: this.Coordinates += this.Speed.Rows * DirectionCoords.Left + this.Speed.Cols * DirectionCoords.Up;
                    break;
                case Direction.DownLeft: this.Coordinates += this.Speed.Rows * DirectionCoords.Left + this.Speed.Cols * DirectionCoords.Down;
                    break;
                case Direction.UpRight: this.Coordinates += this.Speed.Rows * DirectionCoords.Right + this.Speed.Cols * DirectionCoords.Up;
                    break;
                case Direction.DownRight: this.Coordinates += this.Speed.Rows * DirectionCoords.Right + this.Speed.Cols * DirectionCoords.Down;
                    break;
                default:
                    break;
            }
            if ((this.Coordinates.Rows < 0) || (this.Coordinates.Rows < 0) ||
                (this.Coordinates.Rows > map.Size.Rows) || (this.Coordinates.Cols > map.Size.Cols))
            {
                this.Coordinates = oldCoords;
                throw new ImpossibleActionException("Move", "Unit moves outside the limits of the map.");
            }
        }
    }
}
