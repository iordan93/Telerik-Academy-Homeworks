using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Army;
using GeometryEngine;

namespace FactoryLibrary
{
    public static class FactoryForUnits
    {
        public static BatteringRam GetBatteringRam(MatrixCoords coordinates)
        {
            Random rand = new Random();
            BatteringRam ram = new BatteringRam(rand.Next(400, 500), rand.Next(30, 40),
                rand.Next(40, 50), 0, 5, coordinates, new MatrixCoords(rand.Next(1, 2), rand.Next(1, 2)), 100, 100);
            return ram;
        }

        public static Catapult GetCatapult(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Catapult catapult = new Catapult(rand.Next(200, 250), rand.Next(25, 35), rand.Next(5, 10),
                0, 100, 100, rand.Next(8, 10), coordinates, new MatrixCoords(rand.Next(2, 3), rand.Next(2, 3)));
            return catapult;
        }

        public static FireBallThrower GetFireBallThrower(MatrixCoords coordinates)
        {
            Random rand = new Random();
            FireBallThrower fireball = new FireBallThrower(rand.Next(220, 240), rand.Next(50, 60),
                rand.Next(30, 40), 0, rand.Next(10, 12), coordinates, new MatrixCoords(rand.Next(2, 3), rand.Next(2, 3)), 100, 100);
            return fireball;
        }

        public static Fireship GetFireship(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Fireship fireship = new Fireship(rand.Next(400, 500), rand.Next(70, 80), rand.Next(40, 50), 0,
                rand.Next(10, 12), coordinates, new MatrixCoords(rand.Next(3, 4), rand.Next(3, 4)), 100, 100);
            return fireship;
        }

        public static Galleon GetGalleon(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Galleon galleon = new Galleon(rand.Next(700, 800), rand.Next(50, 60),
                rand.Next(80, 90), 0, rand.Next(8, 9), coordinates, new MatrixCoords(2, 2), 100, 100);
            return galleon;
        }

        public static Griffin GetGriffin(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Griffin griffin = new Griffin(rand.Next(180, 200), rand.Next(20, 30), rand.Next(15, 18), 0,
                rand.Next(10, 20), 5, coordinates, new MatrixCoords(rand.Next(6, 8), rand.Next(6, 8)));
            return griffin;
        }

        public static Knight GetKnight(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Knight knight = new Knight(rand.Next(120, 140), rand.Next(18, 22), rand.Next(30, 35), 0, rand.Next(100, 120),
                3, coordinates, new MatrixCoords(rand.Next(4, 6), rand.Next(4, 6)));
            return knight;
        }

        public static Nomad GetNomad(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Nomad nomad = new Nomad(rand.Next(50, 60), rand.Next(10, 12),
                rand.Next(7, 9), 0, rand.Next(80, 90), 2, coordinates, new MatrixCoords(2, 2));
            return nomad;
        }

        public static Paladin GetPaladin(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Paladin paladin = new Paladin(rand.Next(180, 200), rand.Next(20, 25), rand.Next(25, 28), 0,
                rand.Next(100, 105), 3, coordinates, new MatrixCoords(rand.Next(2, 4), rand.Next(2, 4)));
            return paladin;
        }

        public static Peasant GetPeasant(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Peasant peasant = new Peasant(rand.Next(20, 40), rand.Next(5, 7), rand.Next(5, 6), 0,
                rand.Next(60, 70), 2, coordinates, new MatrixCoords(1, 1));
            return peasant;
        }

        public static Pegasus GetPegasus(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Pegasus pegasus = new Pegasus(rand.Next(90, 110), rand.Next(30, 40), rand.Next(5, 10), 0, rand.Next(5, 8),
                rand.Next(2, 4), coordinates, new MatrixCoords(rand.Next(8, 10), rand.Next(8, 10)));
            return pegasus;
        }

        public static Phoenix GetPhoenix(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Phoenix phoenix = new Phoenix(rand.Next(60, 80), rand.Next(15, 20), rand.Next(10, 15), 0, 10, rand.Next(3, 5), coordinates, new MatrixCoords(6, 6));
            return phoenix;
        }

        public static Ship GetShip(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Ship ship = new Ship(rand.Next(250, 300), rand.Next(30, 40), rand.Next(40, 50), 0, 5,
                coordinates, new MatrixCoords(4, 4), 100, 100);
            return ship;
        }

        public static Werewolf GetWerewolf(MatrixCoords coordinates)
        {
            Random rand = new Random();
            Werewolf werewolf = new Werewolf(rand.Next(150, 200), rand.Next(30, 40), rand.Next(20, 30), 0, 10, 2,
                coordinates, new MatrixCoords(rand.Next(2, 3), rand.Next(2, 3)));
            return werewolf;
        }
    }
}
