using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    internal class VIPCustomer : Customer
    {
        public VIPCustomer(string customerName, double customerBalance) : base(customerName, customerBalance)
        {

        }
        public override string ToString()
        {
            return String.Format("VIP Customer: {0}", base.ToString());
        }
    }
}
