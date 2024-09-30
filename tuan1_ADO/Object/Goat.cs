using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cattle.Object
{
    public class Goat : Cattle
    {
        static int numb = 0;
        static int milk = 0;
        public Goat() { numb++; }
        public int getNumber()
        {
            return numb;
        }
        public int getMilk()
        {
            return milk;
        }
        public override int born()
        {
            Random random = new Random();
            return random.Next(1, 10);

        }
        public override int giveMilk()
        {
            Random random = new Random();
            int gMilk = random.Next(10);
            milk += gMilk;
            return gMilk;

        }
        public override string bark()
        {
            return "dee dee";
        }
    }
}
