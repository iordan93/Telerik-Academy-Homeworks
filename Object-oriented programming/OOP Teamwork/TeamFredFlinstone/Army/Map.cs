using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeometryEngine;

namespace Army
{
    public class Map
    {
        private MatrixCoords size;

        public MatrixCoords Size
        {
            get { return size; }
            private set { size = value; }
        }

        private List<ArmyObject> list;

        public List<ArmyObject> List
        {
            get { return list; }
            private set { list = value; }
        }

        public Map(MatrixCoords coords)
        {
            this.Size = coords;
            this.List = new List<ArmyObject>();
        }

        public void AddObject(ArmyObject obj)
        {
            this.List.Add(obj);
        }

        public void RemoveObject(ArmyObject obj)
        {
            this.List.Remove(obj);
        }

        public void AddObjects(List<ArmyObject> list)
        {
            this.List.AddRange(list);
        }

        public List<ArmyObject> ArrangeByHealth(MatrixCoords angle, MatrixCoords dimensions)
        {
            var healthArranged =
                from obj in this.List
                where (obj.Coordinates.Rows >= angle.Rows) && (obj.Coordinates.Rows <= angle.Rows + dimensions.Rows) &&
                (obj.Coordinates.Cols >= angle.Cols) && (obj.Coordinates.Cols <= angle.Cols + dimensions.Cols)
                orderby obj.Health
                select obj;
            return healthArranged.ToList();
        }

        public List<ArmyObject> ArrangeByTypeAndHealth(MatrixCoords angle, MatrixCoords dimensions)
        {
            var healthArranged =
                from obj in this.List
                where (obj.Coordinates.Rows >= angle.Rows) && (obj.Coordinates.Rows <= angle.Rows + dimensions.Rows) &&
                (obj.Coordinates.Cols >= angle.Cols) && (obj.Coordinates.Cols <= angle.Cols + dimensions.Cols)
                orderby obj.Health, obj.Vitals.AttackPoints
                select obj;
            return healthArranged.ToList();
        }
    }
}
