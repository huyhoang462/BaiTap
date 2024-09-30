using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tuan3_LinQ.Model
{
    internal class Product
    {
        string id;
        string name;
        int number;
        double price;
        string origin;
        DateTime overdue;

        public Product(string id, string name, int number, double price, string origin, DateTime overdue)
        {
            this.id = id;
            this.name = name;
            this.number = number;
            this.price = price;
            this.origin = origin;
            this.overdue = overdue.Date;
        }
        public string getId() { return id; }
        public string getName() { return name; }
        public int getNumber() { return number; }
        public double getPrice() { return price; }
        public string getOrigin() { return origin; }
        public DateTime getOverdue()
        {
            return overdue;
        }
        public void setOverdue(DateTime overdue)
        {
            this.overdue = overdue.Date;
        }
        public void setName(string name) { this.name = name; }
        public void setNumber(int number) { this.number = number; }
        public void setPrice(double price) { this.price = price; }
        public void setOrigin(string origin) { this.origin = origin; }

    }
}
