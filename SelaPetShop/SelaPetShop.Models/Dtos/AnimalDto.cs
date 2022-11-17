using System;
using System.ComponentModel.DataAnnotations;

namespace SelaPetShop.Models.Dtos
{
    public class AnimalDto //Animal Data Transfer
    {
        public AnimalDto()
        {
            Comments = new List<string>();
        }

        [Key]
        [Display(Name = "Animal Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category")]
        public string Category { get; set; }
        //public ICollection<CategoryDto> Category { get; set; }

        [Display(Name = "Age")]
        public double? Age { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }

        [Display(Name = "Comments")]
        public List<string>? Comments { get; set; }

        [Display(Name = "Picture URL")]
        public string? PictureUrls { get; set; }
    }
}
