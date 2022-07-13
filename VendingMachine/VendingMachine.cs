using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine
{
    internal class VendingMachine
    {
        IBeverage[] _beverages;
        public IBeverage[] Beverages { get { return _beverages; } set { _beverages = value; } }

        public VendingMachine(params IBeverage[] beverages)
        {
            _beverages = beverages;
        }

        public void Prepare(string name)
        {
            for (int i = 0; i < _beverages.Length; i++)
            {
                if (_beverages[i].Name == name)
                {
                    _beverages[i].Prepare();
                    break;
                }
            }
        }
    }
}
