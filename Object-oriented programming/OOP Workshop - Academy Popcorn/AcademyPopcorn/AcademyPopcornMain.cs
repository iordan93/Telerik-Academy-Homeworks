using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcademyPopcorn
{
    class AcademyPopcornMain
    {
        const int WorldRows = 23;
        const int WorldCols = 40;
        const int RacketLength = 6;

        static void Initialize(Engine engine)
        {
            int startRow = 3;
            int startCol = 2;
            int endCol = WorldCols - 2;

            for (int i = startCol; i < endCol; i++)
            {
                Block currBlock = new Block(new MatrixCoords(startRow, i));
                engine.AddObject(currBlock);
            }

            // Left and right wall
            for (int index = 0; index < WorldRows; index++)
            {
                IndestructibleBlock leftWallPart = new IndestructibleBlock(new MatrixCoords(index, 0));
                IndestructibleBlock rightWallPart = new IndestructibleBlock(new MatrixCoords(index, WorldCols - 1));
                engine.AddObject(leftWallPart);
                engine.AddObject(rightWallPart);
            }

            // Top wall
            for (int index = 0; index < WorldCols; index++)
            {
                IndestructibleBlock topWallPart = new IndestructibleBlock(new MatrixCoords(0, index));
                engine.AddObject(topWallPart);
            }

            Ball theBall = new Ball(new MatrixCoords(WorldRows / 2, 0), new MatrixCoords(-1, 1));

            engine.AddObject(theBall);

            // MeteoriteBall test
            //MeteoriteBall meteoriteBall = new MeteoriteBall(new MatrixCoords(WorldRows / 2, WorldCols / 2), new MatrixCoords(-1, 1));
            //engine.AddObject(meteoriteBall);
            
            // UnpassableBlock test
            //for (int i = 0; i < WorldCols - 1; i++)
            //{
            //    UnpassableBlock unpassableBlock = new UnpassableBlock(new MatrixCoords(5, i));

            //    engine.AddObject(unpassableBlock);
            //}

            // Exploding block test
            ExplodingBlock explodingBlock = new ExplodingBlock(new MatrixCoords(8, 8));
            engine.AddObject(explodingBlock);

            // UnstoppableBall test
            //UnstoppableBall unstoppableBall = new UnstoppableBall(new MatrixCoords(WorldRows/2,WorldCols/2),new MatrixCoords(-1,1));
            //engine.AddObject(unstoppableBall);

            Racket theRacket = new Racket(new MatrixCoords(WorldRows - 1, WorldCols / 2), RacketLength);

            engine.AddObject(theRacket);

            //// TrailObject test
            //TrailObject trailObj = new TrailObject(new MatrixCoords(5, 5), 5);
            //engine.AddObject(trailObj);

            // Gift and GiftBlock test
            GiftBlock giftBlock = new GiftBlock(new MatrixCoords(5, 5));
            engine.AddObject(giftBlock);
        }

        static void Main(string[] args)
        {
            IRenderer renderer = new ConsoleRenderer(WorldRows, WorldCols);
            IUserInterface keyboard = new KeyboardInterface();

            ShootingRacketEngine gameEngine = new ShootingRacketEngine(renderer, keyboard);

            keyboard.OnLeftPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketLeft();
            };

            keyboard.OnRightPressed += (sender, eventInfo) =>
            {
                gameEngine.MovePlayerRacketRight();
            };
            
            // Adding the ability to shoot when a gift is received using a lambda expression
            keyboard.OnActionPressed += (sender, eventInfo) =>
                                        {
                                            gameEngine.ShootPlayerRacket();
                                        };

            Initialize(gameEngine);

            gameEngine.Run();
        }
    }
}
