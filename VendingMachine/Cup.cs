using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    abstract class Cup
    {
        public abstract string Name { get; }
        public abstract double Price { get; set; }
        //double _price;
        Size _size;
        //public double Price { get { return _price; } set { _price = value; } }
        public Size Size { get { return _size; } set { _size = value; } }

        public Cup(Size size)//, double price)
        {
            _size = size;
            //_price = price;
        }
        public abstract void Prepare();
        public override sealed string ToString()
        {
            return "the name: " + Name + ", the price: " + Price;
        }
    }
}
