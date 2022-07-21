using System;

namespace VendingMachine.Beverages
{
    internal class Tea : Cup
    {
        Inventory inv = new Inventory();

        double _price = 3;
        public override string Name 
        {
            get { return "Tea"; }
        }
        public override double Price 
        {
            get { return _price; }
            set { _price = value; }
        }

        public Tea(Size size) : base(size)
        {
        }

        public override void Prepare()
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
    }
}
