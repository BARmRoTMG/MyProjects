using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_Methods_9._5
{
    public class Item
    {
        public int _basePrice;
        public int _discountPrecentage;

        public Item(int basePrice, int discountPrecentage)
        {
            _basePrice = basePrice;
            _discountPrecentage = discountPrecentage; 
        }
        public double calculatePrice()
        {
            return (_basePrice * _discountPrecentage) / 100;
        }
    }
}
