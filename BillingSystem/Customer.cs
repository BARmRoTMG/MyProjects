﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BillingSystem
{
    internal class Customer
    {
        //Fields
        private string _customerName;
        private double _customerBalance;
        private readonly int _customerId;
        private static int STARTER_ID = 100;

        //Properties
        public string CustomerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public double CustomerBalance
        {
            get { return _customerBalance; }
            set { _customerBalance = value; }
        }

        public int CustomerId
        {
            get { return _customerId; }
        }

        public Customer(string customerName)
        {
            CustomerName = customerName;
            _customerId = STARTER_ID++;
        }

        public Customer(string customerName, double customerBalance) : this(customerName)
        {
            CustomerBalance = customerBalance;
        }

        public override string ToString()
        {
            return $"Name: {_customerName}, Balance: {_customerBalance}, ID: {_customerId}";
        }
    }
}
