using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan3_LinQ.Model
{
    internal class Product
    {
        int id;
        string name;
        int number;
        double price;
        string origin;
        DateTime overdue;

        public Product(int id, string name, int number, double price, string origin, DateTime overdue)
        {
            this.id = id;
            this.name = name;
            this.number = number;
            this.price = price;
            this.origin = origin;
            this.overdue = overdue;
        }
        public int getId() { return id; }
        public string getName() { return name; }
        public int getNumber() { return number; }
        public double getPrice() { return price; }
        public string getOrigin() { return origin; }
        public DateTime getOverdue()
        {
            return overdue;
        }
    }
}
