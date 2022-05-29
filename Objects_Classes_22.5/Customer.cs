using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Classes_22._5
{
    class Customer
    {
        private string _name;
        private double _currentBill;

        public Customer(string name, double currentBill)
        {
            _name = name;
            _currentBill = currentBill;
        }

        public string Name { get { return _name; } }
        public double CurrentBill
        {
            get { return _currentBill; }
            set { _currentBill = value; }
        }
        public bool IsLimited { get { return _currentBill >= 10000; } }


        public string GetName()
        {
            return _name;
        }

        public double GetCurrentBill()
        {
            return _currentBill;
        }
    }
}
