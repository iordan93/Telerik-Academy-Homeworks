using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Army;
using GeometryEngine;

namespace FactoryLibrary
{
    public static class FactoryForBuildings
    {
        public static ClayMine GetClayMine(MatrixCoords coordinates)
        {
            Random rand = new Random();
            ClayMine mine = new ClayMine(rand.Next(600, 800), 0, rand.Next(25, 30), 0, 0, coordinates, new MatrixCoords(0, 0));
            return mine;
        }

        public static Fortress GetFortress(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Fortress fort = new Fortress(rand.Next(1200, 1400), rand.Next(20, 30), rand.Next(20, 40),
                0, 3, coordinates, new MatrixCoords(0, 0));
            return fort;
        }

        public static FortressWall GetFortressWall(MatrixCoords coordinates)
        {
            Random rand = new Random();
            FortressWall fort = new FortressWall(rand.Next(800, 1000), rand.Next(5, 10), rand.Next(40, 45),
                0, 2, coordinates, new MatrixCoords(0, 0));
            return fort;
        }

        public static GoldMine GetGoldMine(MatrixCoords coordinates)
        {
            Random rand = new Random();
            GoldMine mine = new GoldMine(rand.Next(200, 250), 0, rand.Next(10, 15), 0, 0, coordinates, new MatrixCoords(0, 0));
            return mine;
        }

        public static IronFoundry GetIronFoundry(MatrixCoords coordinates)
        {
            Random rand = new Random();
            IronFoundry foundry = new IronFoundry(rand.Next(150, 200), 0, rand.Next(20, 25), 0, 0, coordinates, new MatrixCoords(0, 0));
            return foundry;
        }

        public static Lumbermill GetLumbermill(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Lumbermill mill = new Lumbermill(rand.Next(100, 120), 0, rand.Next(10, 12), 0, 0, coordinates, new MatrixCoords(0, 0));
            return mill;
        }

        public static Tent GetTent(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Tent tent = new Tent(rand.Next(50, 60), rand.Next(20, 30), rand.Next(10, 15), 0, 3, coordinates, new MatrixCoords(0, 0));
            return tent;
        }

        public static Tower GetTower(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Tower tower = new Tower(rand.Next(400, 500), rand.Next(40, 50), rand.Next(30, 35), 0, 5, coordinates, new MatrixCoords(0, 0));
            return tower;
        }

        public static HealingBuilding GetHealingBuilding(MatrixCoords coordinates)
        {
            Random rand = new Random();
            HealingBuilding heal = new HealingBuilding(rand.Next(400, 500), rand.Next(40, 50), rand.Next(30, 35), 0, 5, coordinates, new MatrixCoords(0, 0), rand.Next(10,20));
            return heal;
        }
    }
}
