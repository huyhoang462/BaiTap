using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip.Object
{
    internal class Explosion
    {
        public int x, y;
        public int r;
        public bool isShip=false;
        public int indexE = 0;
        public Explosion(int x, int y, int r)
        {
            this.x = x;
            this.y = y;
            this.r = r;
        }
    }
}
