﻿using NewPetShop.Data.Entities;
using System.ComponentModel.DataAnnotations;
using static NewPetShop.Data.Entities.Animal;

namespace NewPetShop.Client.Models
{
    public class AnimalDto
    {
        public AnimalDto()
        {
            Comments = new List<Comment>();
        }
        [Key]
        public int AnimalId { get; set; }

        [Required(ErrorMessage = "A name must be given to the new animal.")]
        [StringLength(50)]
        [Display(Name = "Animal Name")]
        public string? Name { get; set; }

        [Display(Name = "Birthdate")]
        public DateTime? Birthdate { get; set; }

        [Display(Name = "Description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please assign a category.")]
        [Display(Name = "Category")]
        public Category Category { get; set; }

        [Display(Name = "Comments")]
        public ICollection<Comment> Comments { get; set; }
        [Display(Name = "Comment")]
        public string comment { get; set; }

        [Display(Name = "Image")]
        public Image Image { get; set; }

        public CategoryEnum CategoryEnum { get; set; }
    }
}
