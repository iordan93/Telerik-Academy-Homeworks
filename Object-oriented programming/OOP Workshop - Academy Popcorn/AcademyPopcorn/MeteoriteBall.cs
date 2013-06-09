using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    // The newly created class - meteorite ball which leaves a trail
    class MeteoriteBall : Ball
    {
        // Constructor
        public MeteoriteBall(MatrixCoords topLeft, MatrixCoords speed) : base(topLeft, speed) 
        {
        }

        // To add a trail to the meteorite ball, it should be produced by the ball
        // Add a list of trail objects with a lifespan of 3 turns
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> trail = new List<GameObject>();
            trail.Add(new TrailObject(base.topLeft, 3));
            return trail;
        }
    }
}
