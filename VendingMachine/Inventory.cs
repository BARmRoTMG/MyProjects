using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
