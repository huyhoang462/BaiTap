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
        public Point p;
        public int wi, he;
        public int speed;
        public Enemi(int px, int py, int wi,int he)
        {
            Random rd = new Random();
            this.p.X = px;
            this.p.Y = py;
            this.he=he;
            this.wi = wi;
            this.speed = rd.Next(2, 9);
           
        }
      
      
    }
   
}
