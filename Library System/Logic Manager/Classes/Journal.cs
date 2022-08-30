using Logic_Manager.Enums;
using Logic_Manager.Exceptions;
using System;

namespace Logic_Manager
{
    public class Journal : Items
    {
        public Journal(string journalName, Genre gengre, string publishingCompany, double leasePrice, double leaseDiscount)
        {
            ID = Guid.NewGuid();
            Name = journalName;
            Gengre = gengre;
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
