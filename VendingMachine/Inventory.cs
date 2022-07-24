using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace VendingMachine
{
    internal class Inventory
    {
        static double _coffeeBeans = 5;
        double _milk = 5;
        double _sugar = 5;
        double _cocoPoweder = 5;
        int _teaLeafes = 5;

        //Fields
        public double CoffeeBeans { get { return _coffeeBeans; } set { _coffeeBeans = value; } }
        public double Milk { get { return _milk; } set { _milk = value; } }
        public double Sugar { get { return _sugar; } set { _sugar = value; } }
        public double CocoPoweder { get { return _cocoPoweder; } set { _cocoPoweder = value; } }
        public int TeaLeafes { get { return _teaLeafes; } set { _teaLeafes = value; } }

        public Inventory()
        {
            if (_coffeeBeans <= 0 || _milk <= 0 || _sugar <= 0 || _cocoPoweder <= 0 || _teaLeafes <= 0)
            {
                MessageBox.Show("Sorry! An Ingredient is missing, Wait for restock.");
                RestockMachine();
            }
        }

        public void RestockMachine()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("RESTOCKING VENDING MACHINE!\nStand By...");
            Thread.Sleep(5000);
            Console.Clear();

            _coffeeBeans += 5;
            _milk = +5;
            _sugar = +5;
            _cocoPoweder += 5;
            _teaLeafes += 5;
        }
    }
}
