﻿using System;

public struct Point
{
    public Point(double x, double y, double z)
        : this()
    {
        this.X = x;
        this.Y = y;
        this.Z = z;
    }

    public double X { get; set; }

    public double Y { get; set; }

    public double Z { get; set; }
}