using System;
using System.ComponentModel.DataAnnotations;

namespace SelaPetShop.Models.Dtos
{
    public class AnimalDto //Animal Data Transfer
    {
        public AnimalDto()
        {
            Comments = new List<string>();
            PictureUrls = new List<string>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Category")]
        public string Category { get; set; }

        [StringLength(50)]
        [Display(Name = "Age")]
        public double? Age { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Description")]
        public string Description { get; set; }

        public ICollection<string> Comments { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Photo")]
        public ICollection<string> PictureUrls { get; set; }
    }
}
