using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal abstract class Cup
    {
        double _price;
        Size _size;
        public double Price { get { return _price; } set { _price = value; } }
        public Size Size { get { return _size; } set { _size = value; } }

        public Cup(Size size, double price)
        {
            _size = size;
            _price = price;
        }

        public override string ToString()
        {
            return "You're drink was @#$@#$@#$";
        }
    }
}
