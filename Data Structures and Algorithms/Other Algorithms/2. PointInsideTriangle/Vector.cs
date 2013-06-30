using System;

public class Vector
{
    private Point endPoint;

    public Vector(Point point)
    {
        this.endPoint = point;
    }

    public Vector(double x, double y, double z)
    {
        this.endPoint = new Point(x, y, z);
    }

    public double X
    {
        get
        {
            return this.endPoint.X;
        }
    }

    public double Y
    {
        get
        {
            return this.endPoint.Y;
        }
    }

    public double Z
    {
        get
        {
            return this.endPoint.Z;
        }
    }

    // Operations with vectors - scalar product (dot product) and vector product (cross product)
    public static double ScalarProduct(Vector first, Vector second)
    {
        // The scalar product of two vectors is the sum
        // of the products of the vector components
        return (first.X * second.X) + (first.Y * second.Y) + (first.Z * second.Z);
    }

    public static Vector VectorProduct(Vector first, Vector second)
    {
        // The cross product of two vectors is a vector whose coordinates can be found from the minors
        // of the determinant
        // |x1 y1 z1|
        // |x2 y2 z2|
        double firstCoordinate = (first.Y * second.Z) - (first.Z * second.Y); 
        double secondCoordinate = (first.X * second.Z) - (first.Z * second.X);
        double thirdCoordinate = (first.X * second.Y) - (first.Y * second.X); 

        return new Vector(firstCoordinate, -secondCoordinate, thirdCoordinate);
    }

    // Operators on vectors - addition, subtraction and commutative multiplication with a scalar (number)
    public static Vector operator +(Vector first, Vector second)
    {
        return new Vector(first.X + second.X, first.Y + second.Y, first.Z + second.Z);
    }

    public static Vector operator -(Vector first, Vector second)
    {
        return new Vector(first.X - first.X, first.Y - second.Y, first.Z - second.Z);
    }

    public static Vector operator *(Vector vector, double number)
    {
        return new Vector(vector.X * number, vector.Y * number, vector.Z * number);
    }

    public static Vector operator *(double number, Vector vector)
    {
        return new Vector(vector.X * number, vector.Y * number, vector.Z * number);
    }
}