using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FormattingAssignment
{
    internal class Product
    {
        private string _productName;
        private double _productPrice;
        private int _numOfDays;
        private DateTime _expirationDate = DateTime.Now;

        public string ProductName { get { return _productName; } set { _productName = value; } }
        public double ProductPrice { get { return _productPrice; } set { _productPrice = value;} }
        public DateTime Warranty { get { return _expirationDate; } set { _expirationDate = value;} }

        public Product(string name, double price, int numDays)
        {
            _productName = name;
            _productPrice = price;
            _numOfDays = numDays;
            _expirationDate = _expirationDate.AddDays(numDays);
            ToString();
        }

        public DateTime AddDays(int days)
        {
            days = _numOfDays;
            return _expirationDate = _expirationDate.AddDays(days);
        }

        public override string ToString()
        {
            return $"Product: {_productName}\nPrice: {_productPrice:C}\nWarranty in days: {_numOfDays}";
        }
    }
}
