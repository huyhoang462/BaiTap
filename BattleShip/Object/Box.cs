using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Object
{
    internal class Box
    {
        public int type;
        public int x;
        public int y;
        public Box(int x, int y)
        {
            type=new Random().Next(2,5);
            this.x = x;
            this.y = y;
        }
        public void setBox(int x, int y) {
        }
    }
}
