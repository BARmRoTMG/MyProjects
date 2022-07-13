using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VendingMachine.Beverages;

namespace VendingMachine
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Coffee coffee = new Coffee(Size.Medium, 2);
        }
    }
}
