using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
    public class Shape
    {
        
        public virtual void drawShape(Point[] p,Color cl)
        {

        }
    }
    public class Triangle : Shape
    {
        public override void drawShape(Point[] p, Color cl)
        {

        }
    }
    public class Rectangle: Shape
    {
        public override void  drawShape(Point[] p, Color cl)
        {

        }
    }
    public class Ellipse : Shape
    {
        public override void drawShape(Point[] p, Color cl)
        {

        }
    }
}
