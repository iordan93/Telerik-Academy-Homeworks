using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Cyllinder : Figure, IAreaMeasurable, IVolumeMeasurable
    {
        public double Radius { get; set; }
        public double Height { get; set; }

        public Cyllinder(Vector3D bottomCenter, Vector3D topCenter, double radius)
            : base(bottomCenter, topCenter)
        {
            this.Radius = radius;
            this.Height = (topCenter - bottomCenter).Magnitude;
        }

        public double GetArea()
        {
            return 2 * Math.PI * this.Radius * (this.Radius + this.Height);
        }

        public double GetVolume()
        {
            return Math.PI * this.Radius * this.Radius * this.Height;
        }

        public override double GetPrimaryMeasure()
        {
            return this.GetVolume();
        }
    }
