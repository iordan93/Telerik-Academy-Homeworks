using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // The newly created type of engine using the shooting racket
    public class ShootingRacketEngine : Engine
    {
        // Constructor for the new type of engine inheriting from the already created engine
        public ShootingRacketEngine(IRenderer renderer, IUserInterface userInterface)
            : base(renderer, userInterface)
        {
        }

        public void ShootPlayerRacket()
        {
            if (this.playerRacket is ShootingRacket)
            {
                (this.playerRacket as ShootingRacket).Shoot();
            }
        }
    }
}
