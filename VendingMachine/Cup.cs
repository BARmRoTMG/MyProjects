using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal abstract class Cup
    {
        Size _size;
        double _sugar;
        double _price;

        public Size Size { get { return _size; } set { _size = value; } }
        public double Sugar { get { return _sugar; } set { _sugar = value; } }
        public double Price { get { return _price; } set { _price = value; } }

        public Cup(Size size, double sugar, double price)
        {
            _size = size;
            _sugar = sugar;
            _price = price;
        }
    }
}
