using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Beverages
{
    internal class HotChocolate : Cup//, IBeverage
    {
        public double _price = 15;
        Inventory inv = new Inventory();
        public HotChocolate(Size size/*, double price*/) : base(size)//, price) //double cocoPowder, double hotWater, double milk, double sugar, Size size, double price
        {
            //Name = "Hot Chocolate";
            //Price = 5;
        }
        public override string Name
        {
            get { return "Chocolate"; }
        }
        public override double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        //public string Name { get; set; }

        public override void Prepare()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Adding coco powder...");
            inv.CocoPoweder--;
            Console.WriteLine("Pouring Hot Water...");
            Console.WriteLine("Stirring...");
            Console.WriteLine("Adding milk...");
            inv.Milk--;
            Console.WriteLine("Final stirr...");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Drink ready.");
        }

        //public override string ToString()
        //{
        //    Console.ForegroundColor = ConsoleColor.Green;
        //    return $"Here's your {Name}, your bill is {Price} USD.";
        //}
    }
}
