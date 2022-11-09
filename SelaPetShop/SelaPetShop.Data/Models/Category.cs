using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SelaPetShop.Data.Models
{
    public partial class Category
    {
        public Category()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int CategoryId { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }

        [InverseProperty("Category")]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
