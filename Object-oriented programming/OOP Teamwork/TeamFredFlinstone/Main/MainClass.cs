using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Army;
using GeometryEngine;
using FactoryLibrary;
using CustomExceptions;

namespace Main
{
    class MainClass
    {
        static void Main(string[] args)
        {
            /*Map map = new Map(new MatrixCoords(100, 100));
            Griffin grif = FactoryForUnits.GetGriffin(new MatrixCoords(5, 5));
            Peasant peasant = FactoryForUnits.GetPeasant(new MatrixCoords(6, 6));
            HealingBuilding healingBuilding = FactoryForBuildings.GetHealingBuilding(new MatrixCoords(10, 10));
            grif.SubscribeToHealing(healingBuilding);
            peasant.SubscribeToHealing(healingBuilding);
            healingBuilding.HealUnits();
            Console.WriteLine(peasant.Health);
            grif.Attack(peasant);
            Console.WriteLine(peasant.Health);
            Fireship first = FactoryForUnits.GetFireship(new MatrixCoords(4, 4));
            Ship second = FactoryForUnits.GetShip(new MatrixCoords(5, 5));
            Console.WriteLine(first.Health);
            Console.WriteLine(second.Health);
            first.Attack(second);
            Console.WriteLine(first.Health);
            Console.WriteLine(second.Health);
            Console.WriteLine("{0} {1}", first.Coordinates.Rows, first.Coordinates.Cols);
            first.Move(Direction.UpLeft,map);
            //first.Move(Direction.UpLeft,map);
            Console.WriteLine("{0} {1}", first.Coordinates.Rows, first.Coordinates.Cols);
            map.AddObject(first);
            map.AddObject(second);
            foreach (var c in map.List)
                Console.WriteLine(c);
            map.RemoveObject(first);
            foreach (var c in map.List) 
                Console.WriteLine(c);
            Console.WriteLine(first.Equals(first));
            Formation form = new Formation("Spartan formation");
            grif.EnterFormation(form);
            peasant.EnterFormation(form);
            form.CheckUnits();*/
            Map map = new Map(new MatrixCoords(100, 100));
            List<ArmyObject> listOfUnits = new List<ArmyObject>();
            listOfUnits.Add(FactoryForUnits.GetPeasant(new MatrixCoords(5, 5)));
            listOfUnits.Add(FactoryForUnits.GetPaladin(new MatrixCoords(6, 6)));
            listOfUnits.Add(FactoryForUnits.GetBatteringRam(new MatrixCoords(90, 90)));
            listOfUnits.Add(FactoryForUnits.GetShip(new MatrixCoords(90, 91)));
            listOfUnits.Add(FactoryForUnits.GetGalleon(new MatrixCoords(92, 92)));
            listOfUnits.Add(FactoryForBuildings.GetClayMine(new MatrixCoords(89, 89)));
            HealingBuilding building = FactoryForBuildings.GetHealingBuilding(new MatrixCoords(4, 4));
            listOfUnits.Add(building);
            Catapult catapult = FactoryForUnits.GetCatapult(new MatrixCoords(99, 99));
            listOfUnits.Add(catapult);
            Formation formation = new Formation("Spartan formation");
            map.AddObjects(listOfUnits);

            listOfUnits[0].Attack(listOfUnits[1]);
            Console.WriteLine();

            try
            {
                listOfUnits[0].Attack(listOfUnits[2]);
            }
            catch (ImpossibleActionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            Console.WriteLine(listOfUnits[0].Equals(listOfUnits[1]));
            Console.WriteLine();

            Console.WriteLine(listOfUnits[0].Equals(listOfUnits[0]));
            Console.WriteLine();

            try
            {
                listOfUnits[3].Attack(listOfUnits[5]);
            }
            catch (ImpossibleActionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            listOfUnits[4].Attack(listOfUnits[3]);
            Console.WriteLine();

            try
            {
                catapult.Move(Direction.DownRight, map);
            }
            catch (ImpossibleActionException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine();

            for (int i = 1; i < 4; i++)
            {
                listOfUnits[i].EnterFormation(formation);
            }
            formation.CheckUnits();
            Console.WriteLine();

            for (int i = 5; i < 7; i++)
            {
                listOfUnits[i].SubscribeToHealing(building);
            }
            building.HealUnits();
            Console.WriteLine();

            foreach (ArmyObject c in map.List)
            {
                Console.WriteLine(c);
            }

            List<ArmyObject> newList = map.ArrangeByHealth(new MatrixCoords(88, 88), new MatrixCoords(3, 3));
            Console.WriteLine("Units in the rectangle {0} arranged by health", string.Format("(88,88) - (91,91)"));
            foreach (var c in newList)
                Console.WriteLine(c);
        }
    }
}