using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cattle.Object
{
    public abstract class Cattle{
        public int numb;
        public int milk=0;
        public Cattle()
        { }
        public virtual void born()
        {
            
        }
        public virtual void giveMilk()
        {
            
        }
        public virtual string bark() {
            return "";
        }
    }
    public class Cow: Cattle
    {
        public Cow() { }
        public Cow(int x)
        {
            numb = x;
        }
        public override void born()
        {
            numb++;
        }
        public override void giveMilk()
        {
           milk++;
        }
        public override string bark()
        {
            return "boo boo";
        }
    }
    public class Sheep : Cattle
    {
        public Sheep() { }
        public Sheep(int x) { numb = x; }
        public override void born()
        {
            numb++;
        }
        public override void giveMilk()
        {
            milk++;
        }
        public override string bark()
        {
            return "bee bee";
        }
    }
    public class Goat : Cattle
    {
        public Goat() { }
        public Goat(int x)
        {
            numb = x;
        }
        public override void born()
        {
            numb++;

        }
        public override void giveMilk()
        {
            milk++;
        }
        public override string bark()
        {
            return "dee dee";
        }
    }
}
