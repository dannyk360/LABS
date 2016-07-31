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

        //Very good!
        public Shape this[int index] { get {return  (Shape) shapesList[index]; } }

        //Very good!
        public int Count => shapesList.Count;

        /**
     
        What happens when you add more shapes?
        Do you add more cases to the switch?
         What happens if you want to use this method for any shape out there, even those which are not in your code?
         Polymorphism is the answer

         Consider this implementation:

         foreach (var persistable in Shapes.OfType<IPersist>())
         {
            persistable.Write(st);
         }

     OfType will select only members which are assignable to an IPersist reference and return such a collection
     https://msdn.microsoft.com/en-us/library/bb360913(v=vs.110).aspx

     */
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
