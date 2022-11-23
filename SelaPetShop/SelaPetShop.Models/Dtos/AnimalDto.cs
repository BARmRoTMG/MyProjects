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
            Comments = new List<Comment>();
            //ImageUrls = new List<string>();
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
        public Category Category { get; set; }

        [Display(Name = "Comments")]
        public ICollection<Comment> Comments { get; set; }
        [Display(Name = "Comment")]
        public string comment { get; set; }

        [Display(Name = "Image")]
        public Image Image { get; set; }

        //[Required]
        //[StringLength(1000)]
        //[Display(Name = "Photo")]
        //public string ImageUrl { get; set; }
        ////public List<string> ImageUrls { get; set; }
    }
}
