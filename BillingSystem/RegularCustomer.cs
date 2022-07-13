using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    internal class RegularCustomer : Customer
    {
        public RegularCustomer(string customerName, double customerBalance) : base(customerName, customerBalance) 
        {

        }

        public override string ToString()
        {
            return String.Format("Regular Customer: {0}", base.ToString());
        }
    }
}
