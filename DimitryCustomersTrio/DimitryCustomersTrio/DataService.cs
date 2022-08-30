using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DimitryCustomersTrio
{
    public class DataService
    {
        public List<Customer> Customers { get; set; }
        public DataService()
        {
            Customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "First", Age = 43 },
                new Customer { Id = 2, Name = "Second", Age = 16 },
                new Customer { Id = 3, Name = "Third", Age = 72 },
                new Customer { Id = 10, Name = "First", Age = 43 },
                new Customer { Id = 4, Name = "Fourth", Age = 25 },
                new Customer { Id = 5, Name = "Stam", Age = 43 },
                new Customer { Id = 6, Name = "OK", Age = 39 },
                new Customer { Id = 7, Name = "Good", Age = 43 },
                new Customer { Id = 8, Name = "Bad", Age = 25 },
                new Customer { Id = 11, Name = "First", Age = 43 },
                new Customer { Id = 12, Name = "Stam", Age = 71 }
            };
        }
    }
}
