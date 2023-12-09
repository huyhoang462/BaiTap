using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Object
{
    public class Bullet
    {
        public Image bImage;
        public Point p;
        public int he, wi;
        public int speed;
        public int dame;
        public int type;
        public Bullet(int px, int py)
        {
            this.p.X = px;
            this.p.Y = py;
           
            
        }
        public void move()
        {
            this.p.Y += speed;
        }
    }
    public class Bullet01 : Bullet
    {
        public Bullet01(int px,int py) : base(px, py)
        {
            type = 1;
            he = 20;
            wi = 20;
            dame = 20;
            speed = 20;
        }
    }
    public class Bullet02 : Bullet
    {
        public Bullet02(int px, int py) : base(px, py)
        {
            type = 2;
            he = 40;
            wi = 40;
            dame = 20;
            speed = 30;
        }
    }
    public class Bullet03 : Bullet
    {
        public Bullet03(int px, int py) : base(px, py)
        {
            type = 3;
            he = 50;
            wi = 20;
            dame = 100;
            speed = 10;
        }
    }
    public class Bullet04 : Bullet
    {
        public Bullet04(int px, int py) : base(px, py)
        {
            type = 4;
            he = 50;
            wi = 10;
            dame = 20;
            speed = 40;
        }
    }
}
