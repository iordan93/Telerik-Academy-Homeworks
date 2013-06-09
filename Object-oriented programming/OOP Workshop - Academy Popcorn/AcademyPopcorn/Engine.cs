using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class Engine
    {
        IRenderer renderer;
        IUserInterface userInterface;
        List<GameObject> allObjects;
        List<MovingObject> movingObjects;
        List<GameObject> staticObjects;
        public Racket playerRacket;
        int sleepTime = 500;

        int SleepTime
        {
            get 
            {
                return this.sleepTime;
            }
            set 
            {
                if (value > 0)
                {
                    this.sleepTime = value;
                }
                else throw new ArgumentOutOfRangeException("The sleeping time must be greater than 0.");
            }
        }

        public Engine(IRenderer renderer, IUserInterface userInterface)
        {
            this.renderer = renderer;
            this.userInterface = userInterface;
            this.allObjects = new List<GameObject>();
            this.movingObjects = new List<MovingObject>();
            this.staticObjects = new List<GameObject>();
        }

        // Constructor using the newly defined sleeping time (defaulting to 500 ms)
        public Engine(IRenderer renderer, IUserInterface userInterface, int sleepTime)
            : this(renderer, userInterface)
        {
            this.sleepTime = sleepTime;
        }

        private void AddStaticObject(GameObject obj)
        {
            this.staticObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        private void AddMovingObject(MovingObject obj)
        {
            this.movingObjects.Add(obj);
            this.allObjects.Add(obj);
        }

        public virtual void AddObject(GameObject obj)
        {
            if (obj is MovingObject)
            {
                this.AddMovingObject(obj as MovingObject);
            }
            else
            {
                if (obj is Racket)
                {
                    AddRacket(obj);

                }
                else
                {
                    this.AddStaticObject(obj);
                }
            }
        }

        private void AddRacket(GameObject obj)
        {
            // Remove the existing racket from allObjects and staticObjects
            // Since the next item goes in the place of the deleted one, we need to turn back the index i
            for (int i = 0; i < allObjects.Count; i++)
            {
                if (allObjects[i] is Racket)
                {
                    this.allObjects.RemoveAt(i);
                    i--;
                }
            }

            for (int i = 0; i < staticObjects.Count; i++)
            {
                if (staticObjects[i] is Racket)
                {
                    this.staticObjects.RemoveAt(i);
                    i--;
                }
            }

            this.playerRacket = obj as Racket;
            this.AddStaticObject(obj);
        }

        public virtual void MovePlayerRacketLeft()
        {
            this.playerRacket.MoveLeft();
        }

        public virtual void MovePlayerRacketRight()
        {
            this.playerRacket.MoveRight();
        }

        public virtual void Run()
        {
            while (true)
            {
                this.renderer.RenderAll();

                System.Threading.Thread.Sleep(sleepTime);

                this.userInterface.ProcessInput();

                this.renderer.ClearQueue();

                foreach (var obj in this.allObjects)
                {
                    obj.Update();
                    this.renderer.EnqueueForRendering(obj);
                }

                CollisionDispatcher.HandleCollisions(this.movingObjects, this.staticObjects);

                List<GameObject> producedObjects = new List<GameObject>();

                foreach (var obj in this.allObjects)
                {
                    producedObjects.AddRange(obj.ProduceObjects());
                }

                this.allObjects.RemoveAll(obj => obj.IsDestroyed);
                this.movingObjects.RemoveAll(obj => obj.IsDestroyed);
                this.staticObjects.RemoveAll(obj => obj.IsDestroyed);

                foreach (var obj in producedObjects)
                {
                    this.AddObject(obj);
                }
            }
        }
    }
}
