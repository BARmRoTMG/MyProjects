using ConsoleSerializer.Models;
using System;
using System.Collections.Generic;

namespace ConsoleSerializer.Services
{
    public class DataService
    {
        readonly List<Customer> customers = new List<Customer>();

        public DataService()
        {
            customers.Add(new Customer
            {
                Name = "First",
                Orders = new List<Order>
                {
                    new Order {
                        Status = StatusType.Silver,
                        CreationDate = DateTime.Now,
                        Products = new List<Product> { new Product { Price = 12.5, Valid = true } }
                    },
                    new Order {
                        Status = StatusType.Platinum,
                        CreationDate = DateTime.Now.AddYears(-5),
                        Products = new List<Product> { new Product { Price = 67.9, Valid = false } }
                    }
                }
            });
            customers.Add(new Customer
            {
                Name = "Second",
                Orders = new List<Order>
                {
                    new Order {
                        Status = StatusType.Gold,
                        CreationDate = DateTime.Now.AddDays(-7),
                        Products = new List<Product> { new Product { Price = 855 }, new Product { Price = 99.2 } }
                    }
                }
            });
            customers.Add(new Customer
            {
                Name = "Third",
                Orders = new List<Order>
                {
                    new Order {
                        Status = StatusType.Platinum,
                        CreationDate = DateTime.Now.AddHours(-56),
                        Products = new List<Product> { new Product { Price = 53.9, Valid = false } }
                    },
                    new Order {
                        Status = StatusType.Gold,
                        CreationDate = DateTime.Now.AddYears(-6),
                        Products = new List<Product> { new Product { Price = 67.9 }, new Product { Price = 898.9 } }
                    }
                }
            });
        }

        public List<Customer> GetCustomers() => customers;
    }
}