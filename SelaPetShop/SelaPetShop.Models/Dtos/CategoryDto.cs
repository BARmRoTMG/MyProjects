using System;
using System.ComponentModel.DataAnnotations;

namespace SelaPetShop.Models.Dtos
{
    public class CategoryDto
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Category Name")]
        public string? Name { get; set; }
    }
}
