using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    internal class CompareByBalance : IComparer
    {
        public int Compare(object x, object y) // Compare by balance
        {
            Customer customerX = x as Customer;
            Customer customerY = y as Customer;

            if (customerX == null && customerY == null)
                throw new ArgumentException();

            return customerX.CustomerBalance.CompareTo(customerY.CustomerBalance);
        }
    }
}
