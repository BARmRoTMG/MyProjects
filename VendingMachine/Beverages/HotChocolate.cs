using System;

namespace VendingMachine.Beverages
{
    internal class HotChocolate : Cup
    {
        Inventory inv = new Inventory();
        public double _price = 5;

        public override string Name
        {
            get { return "Hot Chocolate"; }
        }
        public override double Price
        {
            get { return _price; }
            set { _price = value; }
        }

        public HotChocolate(Size size) : base(size)
        {
        }

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
    }
}
