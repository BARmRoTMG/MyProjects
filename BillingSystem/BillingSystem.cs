using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    internal class BillingSystem
    {
        private int _index;
        private Customer[] _customersArr;
        public BillingSystem(int CustomerArr = 100)
        {
            _customersArr = new Customer[CustomerArr];
        }

        public void AddCustomer(Customer c)
        {
            if (_index < _customersArr.Length)
            {
                _customersArr[_index] = c;
                _index++;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < _index; i++)
            {
                stringBuilder.AppendLine(_customersArr.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
