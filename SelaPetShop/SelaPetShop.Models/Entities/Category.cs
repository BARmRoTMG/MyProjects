using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelaPetShop.Models.Entities
{
    public partial class Category
    {
        public Category()
        {
            AnimalCategories = new HashSet<AnimalCategory>();
        }

        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [StringLength(50)]
        public string? Value { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<AnimalCategory> AnimalCategories { get; set; }
    }
}
