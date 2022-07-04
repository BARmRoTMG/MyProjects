using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    class BillingSystem
    {
        private int _index;
        private Customer[] _customersArr;
        const int defaultSize = 100;

        public BillingSystem(int size = defaultSize)
        {
            _customersArr = new Customer[size];
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
            StringBuilder stringBuilder = new StringBuilder("Billing System Data:\n");

            for (int i = 0; i < _index; i++)
            {
                stringBuilder.AppendLine(_customersArr[i].ToString());
            }

            return stringBuilder.ToString();
        }


        //Indexers
        public Customer this[string name]
        {
            get
            {
                for (int i = 0; i < _index; i++)
                    if (_customersArr[i].CustomerName.Equals(name))
                        return _customersArr[i];
                    else
                        return null;
            }
        }

        public Customer this[string name, int id]
        {
            get
            {
                for (int i = 0; i < _index; i++)
                    if (_customersArr[i].CustomerName.Equals(name))
                        return _customersArr[i];
                    else
                        return null;
            }
        }

        public Customer this[int position]
        {
            get
            {
                if (position >= 0 && position < _index)
                {

                }
            }
        }

        public void Sort()
        {
            Array.Sort(_customersArr, 0, _index);
        }
    }
}