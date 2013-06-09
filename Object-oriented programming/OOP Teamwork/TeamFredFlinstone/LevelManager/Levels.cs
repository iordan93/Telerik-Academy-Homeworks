using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace LevelManager
{
    public class Levels
    {
        // Private fields
        private static int[] levelsXP;
        private static readonly int levelsCount = 1001;

        // Public property
        public static int[] LevelsXP
        {
            get
            {
                GetLevels();
                return levelsXP;
            }
            private set
            {
                levelsXP = value;
            }
        }

        public static void GetLevels()
        {
            // Does not need optimization, takes < 0.5 ms to load the array
            levelsXP = new int[levelsCount];
            for (int i = 1; i < levelsCount; i++)
            {
                levelsXP[i] = (int)(Math.Pow(i, 1.85) * Math.Pow(i, 0.1) + 100);
            }
        }

        public static int CalculateDistance(MatrixCoords first, MatrixCoords second)
        {
            return Convert.ToInt32(Math.Sqrt((first.Rows-second.Rows)*(first.Rows-second.Rows)+(first.Cols-second.Cols)*(first.Cols-second.Cols)));
        }
    }
}