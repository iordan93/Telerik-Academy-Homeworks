using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
class Circle : Figure, IFlat, IAreaMeasurable
{
    public double Radius { get; set; }

    public Circle(Vector3D center, double radius)
        : base(center)
    {
        this.Radius = radius;
    }

    public double GetArea()
    {
        return Math.PI * this.Radius * this.Radius;
    }

    public Vector3D GetNormal()
    {
        // The normal of a circle laying in the Oxy plane is the normal of the Oxy plane - (0, 0, 1)
        Vector3D normal = new Vector3D(0, 0, 1);
        return normal;
    }

    public override double GetPrimaryMeasure()
    {
        return this.GetArea();
    }
}
