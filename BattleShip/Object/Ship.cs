using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Object
{
    internal class Ship
    {
        public Point p;
        public int he, wi;
        public Ship(int x,int y, int he, int wi)
        {
            p.X = x; p.Y = y;
            this.he = he;
            this.wi = wi;
        }
        public void setShip(int x, int y, int he, int wi)
        {
            p.X = x; p.Y = y;
            this.he = he;
            this.wi = wi;
        }

        public void move(int x,int y)
        {
            this.p.X += x;
            this.p.Y += y;
        }

    }
}
