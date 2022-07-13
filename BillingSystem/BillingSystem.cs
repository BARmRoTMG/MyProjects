using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{

    public class TooManyCustomerException : Exception
    {
        public TooManyCustomerException() { }
        public TooManyCustomerException(string message) : base(message) { }
        //public TooManyCustomerException(string message, Exception inner) : base(message, inner) { }

        public TooManyCustomerException(int max, int num)
        {
            MaxCustomersAllowed = max;
            NumOfExistingCustomers = num;
        }
        public TooManyCustomerException(string message, int max, int num) : base(message)
        {
            MaxCustomersAllowed = max;
            NumOfExistingCustomers = num;
        }

        public int MaxCustomersAllowed { get; private set; }
        public int NumOfExistingCustomers { get; private set; }
    }

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
            if (_index >= _customersArr.Length)
                throw new TooManyCustomerException(_customersArr.Length - 1, _index);
            _customersArr[_index++] = c;
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
                {
                    if (_customersArr[i].CustomerName.Equals(name))
                        return _customersArr[i];
                    else
                        throw new ArgumentException("No customer found.");
                }
                return null;
            }
        }

        public Customer this[string name, int id]
        {
            get
            {
                for (int i = 0; i < _index; i++)
                {
                    if (_customersArr[i].CustomerId.Equals(id))
                        if (_customersArr[i].CustomerName.Equals(name))
                            return _customersArr[i];
                        else
                            throw new ArgumentException("Found an ID with different name.", "name");
                }
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
                return null;
            }
        }

        public void Sort()
        {
            Array.Sort(_customersArr, 0, _index);
        }
    }
}