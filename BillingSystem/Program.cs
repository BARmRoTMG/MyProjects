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
            BillingSystem billingSystem = new BillingSystem();

            Customer c1 = new Customer("Bar", 5000);
            billingSystem.AddCustomer(c1);

            Customer c2 = new Customer("Shaked", 10000);
            billingSystem.AddCustomer(c2);

            Customer c3 = new Customer("Keren");
            billingSystem.AddCustomer(c3);

            Console.WriteLine(billingSystem.ToString());
            Console.ReadKey();
        }
    }
}
