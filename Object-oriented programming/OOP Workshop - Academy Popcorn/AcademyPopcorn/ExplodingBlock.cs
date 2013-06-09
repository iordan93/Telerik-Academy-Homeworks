using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class ExplodingBlock : Block
    {
        // Constructor - the exploding block looks like &
        public ExplodingBlock(MatrixCoords topLeft) : base(topLeft) 
        {
            this.body = new char[,] { { '&' } };
        }

        public override IEnumerable<GameObject> ProduceObjects()
        {
            // If the block is destroyed, the blocks above, below, left, and right of it are also destroyed
            List<GameObject> explosionShrapnel = new List<GameObject>();
            if (this.IsDestroyed)
            {
                explosionShrapnel.Add(new ExplosionResult(this.topLeft, new MatrixCoords(0, 1)));
                explosionShrapnel.Add(new ExplosionResult(this.topLeft, new MatrixCoords(0, -1)));
                explosionShrapnel.Add(new ExplosionResult(this.topLeft, new MatrixCoords(1, 0)));
                explosionShrapnel.Add(new ExplosionResult(this.topLeft, new MatrixCoords(-1, 0)));
            }
            return explosionShrapnel;
        }
    }
}
