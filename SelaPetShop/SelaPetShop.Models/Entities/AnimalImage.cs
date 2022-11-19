using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SelaPetShop.Models.Entities
{
    [Table("AnimalImage")]
    public partial class AnimalImage
    {
        [Key]
        public int AnimalId { get; set; }
        public int ImageId { get; set; }

        [ForeignKey("AnimalId")]
        public virtual Animal Animal { get; set; } = null!;
        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; } = null!;
    }
}
