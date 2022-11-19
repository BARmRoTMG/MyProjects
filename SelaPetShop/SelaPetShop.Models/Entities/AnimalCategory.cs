using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SelaPetShop.Models.Entities
{
    [Table("AnimalCategory")]
    public partial class AnimalCategory
    {
        [Key]
        public int AnimalId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("AnimalId")]
        public virtual Animal Animal { get; set; } = null!;
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;
    }
}
