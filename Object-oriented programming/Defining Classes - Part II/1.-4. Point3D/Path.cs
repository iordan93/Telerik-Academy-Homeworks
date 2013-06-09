using System;
using System.Collections.Generic;

namespace _1._4.Point3D
{
    public class Path
    {
        // Private field - a list of points
        private List<Point3D> path = new List<Point3D>();

        // Public properties
        // Sequence of points in the path
        public List<Point3D> SequenceOfPoints
        {
            get 
            {
                return path;
            }
        }

        // Length of the current path
        public int Length
        {
            get
            {
                return path.Count;
            }
        }

        // Constructors
        public Path()
        {
            this.path = new List<Point3D>();
        }

        public Path(int length)
        {
            this.path = new List<Point3D>(length);
        }

        // Instance methods
        // Add a point to path
        public void Add(Point3D point)
        {
            this.path.Add(point);
        }

        // Remove a point from path
        public void Remove(Point3D point)
        {
            this.path.Remove(point);
        }

        // Clear current path
        public void Clear()
        {
            this.path.Clear();
        }
    }
}
