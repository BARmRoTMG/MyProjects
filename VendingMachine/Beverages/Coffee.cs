using System;

namespace VendingMachine.Beverages
{
    internal class Coffee : Cup
    {
        double _price = 5;
        Inventory inv = new Inventory();
        public Coffee(Size size) : base(size)
        {
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
    }
}
