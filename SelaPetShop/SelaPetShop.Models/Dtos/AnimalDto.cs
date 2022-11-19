using SelaPetShop.Models.Entities;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelaPetShop.Models.Dtos
{
    public class AnimalDto //Animal Data Transfer
    {
        public AnimalDto()
        {
            Comments = new List<string>();
            ImageUrls = new List<string>();
        }
        public int AnimalId { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Animal Name")]
        public string? Name { get; set; }

        [Required]
        [Display(Name = "Birthdate")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Display(Name = "Category")]
        public string Category { get; set; }

        [Display(Name = "Comments")]
        public List<string> Comments { get; set; }

        [Required]
        [StringLength(1000)]
        [Display(Name = "Photo")]
        public List<string> ImageUrls { get; set; }
    }
}
