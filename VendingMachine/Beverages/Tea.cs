using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Beverages
{
    internal class Tea : Cup, IBeverage
    {
        Inventory inv = new Inventory();
        public string Name { get; set; }

        public Tea(Size size, double price) : base(size, price)
        {
            Name = "Tea";
            Price = 3;
        }

        public void Prepare()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Adding tea leafes...");
            inv.TeaLeafes--;
            Console.WriteLine("Pouring Hot Water...");
            Console.WriteLine("Stirring...");
            Console.WriteLine("Adding sugar...");
            inv.Sugar--;
            Console.WriteLine("Final stirr...");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Drink ready.");
        }

        public override string ToString()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            return $"Here's your {Name}, your bill is {Price} USD.";
        }
    }
}
