namespace Labyrinth
{
    using System;
    using System.Collections.Generic;

    public static class Labyrinth
    {
        private static readonly Coordinates[] Directions = new Coordinates[]
        {
            new Coordinates(1, 0),
            new Coordinates(0, 1),
            new Coordinates(-1, 0),
            new Coordinates(0, -1)
        };

        public static void Main()
        {
            ////Console.Write("Enter the dimension of the square labyrinth:");
            ////int size = int.Parse(Console.ReadLine());
            ////Console.WriteLine("Enter the labyrinth row by row. Enter {0} rows with {0} characters per row.", size);
            ////char[,] labyrinth = new char[size, size];
            ////for (int row = 0; row < size; row++)
            ////{
            ////    string input = Console.ReadLine();
            ////    for (int col = 0; col < size; col++)
            ////    {
            ////        labyrinth[row, col] = input[col];
            ////    }
            ////}
            string[,] labyrinth = new string[,] 
            {                              
                { "0", "0", "0", "x", "0", "x" },
                { "0", "x", "0", "x", "0", "x" },
                { "0", "*", "x", "0", "x", "0" },
                { "0", "x", "0", "0", "0", "0" },
                { "0", "0", "0", "x", "x", "0" },
                { "0", "0", "0", "x", "0", "x" }
            };

            Queue<Coordinates> wavefront = new Queue<Coordinates>();
            Coordinates start = FindStartingPoint(labyrinth);
            wavefront.Enqueue(start);
            
            TraverseBfs(labyrinth, wavefront);
            
            SetUnreachablePoints(labyrinth);
            
            PrintLabyrinth(labyrinth);
        }
  
        public static void TraverseBfs(string[,] labyrinth, Queue<Coordinates> wavefront)
        {
            // Update the wavefront each time new possibilities to move are discovered
            // and print how many steps it took to get to the specified cell
            int pathLength = 0;
            while (wavefront.Count != 0)
            {
                pathLength++;
                Queue<Coordinates> newWavefront = new Queue<Coordinates>();

                while (wavefront.Count != 0)
                {
                    Coordinates currentPosition = wavefront.Dequeue();

                    foreach (Coordinates direction in Directions)
                    {
                        int newRow = currentPosition.Row + direction.Row;
                        int newColumn = currentPosition.Column + direction.Column;
                        Coordinates nextPosition = new Coordinates(newRow, newColumn);

                        if (!IsInRange(labyrinth, nextPosition) ||
                            labyrinth[nextPosition.Row, nextPosition.Column] != "0")
                        {
                            continue;
                        }

                        labyrinth[nextPosition.Row, nextPosition.Column] = pathLength.ToString();
                        newWavefront.Enqueue(nextPosition);
                    }
                }

                wavefront = newWavefront;
            }
        }
  
        public static void SetUnreachablePoints(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "0")
                    {
                        labyrinth[row, col] = "u";
                    }
                }
            }
        }

        public static Coordinates FindStartingPoint(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        return new Coordinates(row, col);
                    }
                }
            }

            throw new ArgumentException("The labyrinth has no defined starting point.");
        }

        public static void PrintLabyrinth(string[,] labyrinth)
        {
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    Console.Write("{0, -2}", labyrinth[row, col]);
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        private static bool IsInRange(string[,] labyrinth, Coordinates nextPosition)
        {
            bool isRowInRange = nextPosition.Row >= 0 &&
                nextPosition.Row < labyrinth.GetLength(0);

            bool isColumnInRange = nextPosition.Column >= 0 &&
                nextPosition.Column < labyrinth.GetLength(1);

            return isRowInRange && isColumnInRange;
        }
    }
}