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
            Customer c1 = new Customer("Bar", 5000);
            Customer c2 = new Customer("Shaked", 10000);
            Customer c3 = new Customer("Keren");
            Console.WriteLine(c1.ToString());
            Console.WriteLine(c2.ToString());
            Console.WriteLine(c3.ToString());
        }
    }
}
