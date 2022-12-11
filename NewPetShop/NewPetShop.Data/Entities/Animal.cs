using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewPetShop.Data.Entities
{
    public partial class Animal
    {
        [Key]
        public int AnimalId { get; set; }

        [StringLength(50)]
        public string? Name { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        public string? Description { get; set; }

        public int CategoryId { get; set; }

        public int? ImageId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Animals")]
        public virtual Category Category { get; set; } = null!;

        [InverseProperty("Animal")]
        public virtual ICollection<Comment> Comments { get; set; }

        [ForeignKey("ImageId")]
        [InverseProperty("Animals")]
        public virtual Image? Image { get; set; }
    }
}
