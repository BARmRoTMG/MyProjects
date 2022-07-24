using System;

namespace BillingSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BillingSystem billingSystem = new BillingSystem(10);

            VIPCustomer c1 = new VIPCustomer("Bar", 5000);
            VIPCustomer c4 = new VIPCustomer("Bar", -100);
            RegularCustomer c2 = new RegularCustomer("Shaked", 10000);
            RegularCustomer c3 = new RegularCustomer("Keren", 0);

            try
            {;
                billingSystem.AddCustomer(c1);
                billingSystem.AddCustomer(c2);
                billingSystem.AddCustomer(c3);
                billingSystem.AddCustomer(c4);


                Console.WriteLine("Before sort -->\n" + billingSystem);
                billingSystem.Sort();
                Console.WriteLine("After sort -->\n" + billingSystem);


                CustCond cond1 = new CustCond(Program.BalanceTooHigh);
                Customer owsTooMuch = billingSystem.First(cond1);
            } catch
            {
                throw new ArgumentException("There was a problem with adding one or more of the customers.");
            }

            CompareByBalance compareByBalance = new CompareByBalance();
            billingSystem.Sort(compareByBalance);
            Console.WriteLine("Compared by Balance -->\n" + billingSystem);

            Console.ReadKey();
        }

        public static bool BalanceTooHigh(Customer c)
        {
            return false;
        }
    }
}