using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryEngine
{
    public class DirectionCoords
    {
        private static readonly MatrixCoords left = new MatrixCoords(-1, 0);
        public static MatrixCoords Left { get { return left; } }

        private static readonly MatrixCoords right = new MatrixCoords(1, 0);
        public static MatrixCoords Right { get { return right; } }

        private static readonly MatrixCoords up = new MatrixCoords(0, 1);
        public static MatrixCoords Up { get { return up; } }

        private static readonly MatrixCoords down = new MatrixCoords(0, -1);
        public static MatrixCoords Down { get { return down; } }
    }
}
