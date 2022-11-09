using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace SelaPetShop.Data.Models
{
    public partial class Animal
    {
        public Animal()
        {
            Comments = new HashSet<Comment>();
        }

        [Key]
        public int AnimalId { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        public double? Age { get; set; }
        [Column(TypeName = "image")]
        public byte[]? PictureName { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Animals")]
        public virtual Category? Category { get; set; }
        [InverseProperty("Animal")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
