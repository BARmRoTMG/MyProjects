using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Manager
{
    public class Journal : Items
    {
        public Journal(string journalName, string gengre, string publishingCompany, double leasePrice, double leaseDiscount)
        {
            ID = Guid.NewGuid();
            Name = journalName;
            Gengre = gengre;
            PublishingCompany = publishingCompany;
            PublishDate = DateTime.Now;
            Gengre = gengre;
            LeasePrice = leasePrice;
            LeaseDiscount = leaseDiscount;
        }
    }
}
