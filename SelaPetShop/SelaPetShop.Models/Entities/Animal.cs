using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelaPetShop.Models.Entities
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
        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }
        public string? Description { get; set; }
        public int CategoryId { get; set; }
        public int? ImageId { get; set; }

        [ForeignKey("CategoryId")]
        [InverseProperty("Animals")]
        public virtual Category Category { get; set; } = null!;

        [ForeignKey("ImageId")]
        [InverseProperty("Animals")]
        public virtual Image? Image { get; set; }

        [InverseProperty("Animal")]
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
