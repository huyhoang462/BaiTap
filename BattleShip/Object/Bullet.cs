using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Object
{
    internal class Bullet
    {
        public Point p;
        public int he, wi;
        public int speed;
        public Bullet(int px, int py, int wi, int he)
        {
            this.p.X = px;
            this.p.Y = py;
            this.he = he;
            this.wi = wi;
            speed = 20;
        }
        public void move()
        {
            this.p.Y += speed;
        }
    }
}
