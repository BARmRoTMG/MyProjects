using Logic_Manager.Enums;
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
        protected Genre Gengre { get; set; }
        protected double LeasePrice { get; set; }
        protected double LeaseDiscount { get; set; }
        protected DateTime LeaseDate { get; set; }

        public override sealed string ToString()
        {
            return $"ID: {ID}\n" +
                   $"Name: {Name}\n" +
                   $"Genre: {Gengre}\n" +
                   $"Author: {Author}\n" +
                   $"Publishing Company: {PublishingCompany}\n" +
                   $"Publish Date: {PublishDate}\n" +
                   $"Lease Price: {LeasePrice}\n" +
                   $"Lease Discount: {LeaseDiscount}\n" +
                   $"Lease Date: {LeaseDate}\n\n";
        }

        public override bool Equals(object obj)
        {
            Items item = obj as Items;
            if (item != null)
            {
                if (this.Name == item.Name)
                    return true;
            }
            return false;
        }
    }
}
