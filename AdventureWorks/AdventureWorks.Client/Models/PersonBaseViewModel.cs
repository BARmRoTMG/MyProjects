﻿using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Client.Models
{
    public class PersonBaseViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(2)]
        [Display(Name = "Person Type")]
        public string PersonType { get; set; }
    }
}