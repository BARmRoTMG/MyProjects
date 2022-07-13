using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Beverages
{
    internal class Coffee : Cup, IBeverage
    {
        public Coffee(Size size, double sugar) : base(size, sugar, 3)
        {
            Name = "Coffee";
            //Price = 3;
        }


        public string Name { get; set; }

        public void Prepare()
        {
        }
    }
}
