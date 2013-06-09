using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    public class GiftBlock : Block
    {
        // The gift block looks and behaves like any other block except when it is destroyed
        // Constructor
        public GiftBlock(MatrixCoords topLeft)
            : base(topLeft)
        {
        }

        // When destroyed, the GiftBlock produces a new Gift object
        public override IEnumerable<GameObject> ProduceObjects()
        {
            List<GameObject> gifts = new List<GameObject>();
            if (this.IsDestroyed)
            {
                gifts.Add(new Gift(this.topLeft));
            }
            return gifts;
        }
    }
}
