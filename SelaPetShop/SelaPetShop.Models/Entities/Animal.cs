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
            AnimalCategories = new HashSet<AnimalCategory>();
            AnimalImages = new HashSet<AnimalImage>();
        }

        [Key]
        public int AnimalId { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        [Column(TypeName = "date")]
        public DateTime? Birthdate { get; set; }
        public string? Description { get; set; }

        [InverseProperty("Animal")]
        public virtual ICollection<Comment> Comments { get; set; }

        [InverseProperty("Animal")]
        public virtual ICollection<AnimalCategory> AnimalCategories { get; set; }

        [InverseProperty("Animal")]
        public virtual ICollection<AnimalImage> AnimalImages { get; set; }
    }
}
