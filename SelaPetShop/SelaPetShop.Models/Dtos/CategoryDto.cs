using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelaPetShop.Models.Dtos
{
    public class CategoryDto
    {
        [Required]
        [Display(Name = "Animal ID")]
        public int AnimalId { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
    }
}
