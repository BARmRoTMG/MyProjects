using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic_Manager
{
    public abstract class Items
    {
        protected Guid ID { get; set; }
        protected string Name { get; set; }
        protected string Author { get; set; }
        protected string PublishingCompany { get; set; }
        protected DateTime PublishDate { get; set; }
        protected string Gengre { get; set; }
        protected double LeasePrice { get; set; }
        protected double LeaseDiscount { get; set; }
        protected DateTime LeaseDate { get; set; }
    }
}
