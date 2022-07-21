using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine.Beverages
{
    internal class Coffee : Cup//, IBeverage
    {
        double _price = 14;
        Inventory inv = new Inventory();
        public Coffee(Size size/*, double price*/) : base(size)//, price)
        {
           // Name = "Coffee";
        }
        public override string Name
        {
            get { return "Coffee"; }
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
            Console.WriteLine("Adding Coffee Beans...");
            inv.CoffeeBeans--;
            Console.WriteLine("Pouring Hot Water...");
            Console.WriteLine("Stirring...");
            Console.WriteLine("Adding milk...");
            inv.Milk--;
            Console.WriteLine("Adding sugar...");
            inv.Sugar--;
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
