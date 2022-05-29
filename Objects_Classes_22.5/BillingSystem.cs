using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Objects_Classes_22._5
{
    class BillingSystem
    {
        Customer[] _customers;

        public BillingSystem()
        {
            _customers = new Customer[3];

            _customers[0] = new Customer("Bobby", 6000);
            _customers[1] = new Customer("Shmurda", 7000);
            _customers[2] = new Customer("DaBaby", 5500);
        }

        public void PrintCustomers()
        {
            Console.WriteLine("Custumer: \t Current Bill: \t Limited Account: ");
            Console.WriteLine("---------------------------------");
            for (int i = 0; i < _customers.Length; i++)
            {
                Console.WriteLine($"{_customers[i].GetName()}\t\t{_customers[i].GetCurrentBill()}");
            }
        }
    }
}
