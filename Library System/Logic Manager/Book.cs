using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Manager
{
    public class Book : Items
    {
        public Book(string bookName, string author, string gengre, string publishingCompany, double leasePrice, double leaseDiscount)
        {
            ID = Guid.NewGuid();
            Name = bookName;
            Author = author;
            PublishingCompany = publishingCompany;
            PublishDate = DateTime.Now;
            Gengre = gengre;
            LeasePrice = leasePrice;
            LeaseDiscount = leaseDiscount;
        }
    }
}
