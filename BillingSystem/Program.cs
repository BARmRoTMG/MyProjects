using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BillingSystem billingSystem = new BillingSystem(10);

            VIPCustomer c1 = new VIPCustomer(); //VIPCustomer("Bar", 5000);
            billingSystem.AddCustomer(c1);

            RegularCustomer c2 = new RegularCustomer(); //("Shaked", 10000);
            billingSystem.AddCustomer(c2);

            RegularCustomer c3 = new RegularCustomer(); //("Keren");
            billingSystem.AddCustomer(c3);

            Console.WriteLine(billingSystem);
            Console.ReadKey();
        }
    }
}