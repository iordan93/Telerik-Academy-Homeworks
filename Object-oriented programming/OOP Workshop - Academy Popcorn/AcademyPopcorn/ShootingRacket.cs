using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class ShootingRacket : Racket
    {
        // Initially, the racket should not shoot. After Shoot() is invoked, the racket gets the ability to shoot
        private bool isShooting = false;

        // Constructor
        public ShootingRacket(MatrixCoords topLeft, int width)
            : base(topLeft, width)
        {
        }

        // Change the mode into shooting
        public void Shoot()
        {
            isShooting = true;
        }

        // When shooting, the racket produces bullets
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> bullets = new List<GameObject>();
            if (isShooting)
            {
                isShooting = false;
                bullets.Add(new Bullet(this.topLeft));
            }
            return bullets;
        }
    }
}
