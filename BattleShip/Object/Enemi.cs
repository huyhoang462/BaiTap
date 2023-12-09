using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Object
{
    public class Enemi
    {
        public int type;
        public Image eImage;
        public Point p;
        public int wi, he;
        public int speed;
        public int HP;
        public  Enemi(int px, int py)
        {
            this.p.X = px;
            this.p.Y = py;
         
        }
      
      
    }
    public class Enemi01 : Enemi
    {
        public Enemi01(int px,int py):base(px,py) {
            wi = 40;
            he = 40;
            speed = 20 ;
            HP = 40;
            type = 2;
        }

       
    }
    public class Enemi02 : Enemi
    {
        public Enemi02(int px, int py) : base(px, py)
        {
            wi = 40;
            he = 20;
            speed = 5;
            HP = 20;
            type = 1;
        }


    }
    public class Enemi03 : Enemi
    {
        public Enemi03(int px, int py) : base(px, py)
        {
            wi = 50;
            he = 30;
            speed = 7;
            HP = 100;
            type = 3;
        }


    }
    public class Boss01 : Enemi
    {
        public Boss01(int px, int py) : base(px, py)
        {
            wi = 80;
            he = 2080;
            speed = 1;
            HP = 2000;
        }
    }

}
