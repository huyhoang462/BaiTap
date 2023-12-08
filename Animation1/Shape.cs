using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Animation1
{
    public struct Point
    {
        public double X, Y;
    }
    public struct Vect
    {
        public int speed;
        public int radious;
    }
    public class Shape
    {
        public Point p;
        public double r;
        public Color cl;
        public Vect v;
        public int nav = 1;
        public Shape(double px,double py, double r, Color cl) { 
            Random rd=new Random();
            this.p.X = px;
            this.p.Y = py;
            this.r = r;
            this.cl = cl;
            v.speed = rd.Next(1, 10);
            v.radious = rd.Next(1,4);
        }
        public void ShapeInfor(Point p,double r,Color cl)
        {
            this.p = p;
            this.r = r;
            this.cl = cl;
        }
    }
}
