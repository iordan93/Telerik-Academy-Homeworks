using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // The newly created class whose instances disappear after a certain amount of time
    class TrailObject : GameObject
    {
        private int lifetime;
        
        public int Lifetime
        {
            get
            {
                return this.lifetime;
            }
            set
            {
                this.lifetime = value;

            }
        }

        public TrailObject(MatrixCoords topLeft, int lifetime)
            : base(topLeft, new char[,] { { '*' } })
        {
            this.Lifetime = lifetime;
        }
        public override void Update()
        {
            this.Lifetime -= 1;
            if (this.Lifetime <= 0)
            {
                this.IsDestroyed = true;
            }
        }
    }
}
