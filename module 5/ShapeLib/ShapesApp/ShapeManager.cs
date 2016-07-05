using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShapeLib;

namespace ShapesApp
{
    class ShapeManager
    {
        private ArrayList shapesList;

        public ShapeManager()
        {
            shapesList = new ArrayList();
        }

        public void Add(Shape newShape)
        {
            shapesList.Add(newShape);
        }

        public  void DisplayAll()
        {
            foreach (Shape shape in shapesList)
            {
                var area = shape.Area;

                shape.Display();
                Console.WriteLine(area);
            }
        }

        public Shape this[int index] { get {return  (Shape) shapesList[index]; } }

        public int Count => shapesList.Count;

        public void Save(StringBuilder sb)
        {
            foreach (dynamic shape in shapesList)
            {
                if (shape.GetType() == typeof(Ellipse))
                    ((Ellipse) shape).Write(sb);
                if (shape.GetType() == typeof(Rectangle))
                    ((Rectangle)shape).Write(sb);
                if (shape.GetType() == typeof(Circle))
                    ((Circle)shape).Write(sb);
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
