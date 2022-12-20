using IntervalQueue.Data.Context;
using IntervalQueue.Data.Entities;
using IntervalQueue.Data.Exceptions;
using IntervalQueue.Data.Interfaces;
using System;

namespace IntervalQueue.Data.Repositories
{
    public class QueueRepository : IRepository<Customer>
    {
        private readonly QueueDbContext _context;

        public QueueRepository(QueueDbContext context)
        {
            _context= context;
        }

        public Customer Add(Customer customer)
        {
            if (_context.Customers.Any(c => c.Id == customer.Id))
                throw new DuplicateCustomerException($"A customer with the id {customer.Id} already exists.");

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer Delete(int id)
        {
            var customer = Get(id);

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return customer;
        }

        public Customer Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                throw new CustomerNotFoundException($"Customer with id: {id}, was not found.");

            return customer;
        }

        public List<Customer> GetAll()
        {
            var customers = _context.Customers.ToList();
            return customers;
        }
    }
}
