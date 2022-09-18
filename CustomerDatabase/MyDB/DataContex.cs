using System;
using System.Data.Entity;

namespace MyDB
{
    public class DataContex : DbContext //Data access layer
    {
        public virtual DbSet<Customer> Customers { get; set; }

        public DataContex() : base("CustomersManagment") { }
    }
}
