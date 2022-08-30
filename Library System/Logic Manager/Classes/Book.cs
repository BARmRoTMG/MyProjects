using Logic_Manager.Enums;
using Logic_Manager.Exceptions;
using System;

namespace Logic_Manager
{
    public class Book : Items
    {
        public Book(string bookName, string author, Genre gengre, string publishingCompany, double leasePrice, double leaseDiscount)
        {
            ID = Guid.NewGuid();
            Name = bookName;
            Author = author;
            PublishingCompany = publishingCompany;
            PublishDate = DateTime.Now;
            Gengre = gengre;

            if (leasePrice > 0 && (leaseDiscount >= 0 || leaseDiscount > leasePrice))
            {
                LeasePrice = leasePrice;
                LeaseDiscount = leaseDiscount;
            }
            else
                throw new PriceMinOrMaxException("The price or discount received is not logically correct.");
        }
    }
}
