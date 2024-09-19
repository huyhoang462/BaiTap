using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNET_Cattle.Object
{
    public abstract class Cattle{
       
        
        public Cattle()
        { }
        
        public virtual int born()
        {
            return 0;
        }
        public virtual int giveMilk()
        {
            return 0;
        }
        public virtual string bark() {
            return "";
        }
    }
}
