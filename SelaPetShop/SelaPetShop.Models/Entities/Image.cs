﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelaPetShop.Models.Entities
{
    public partial class Image
    {
        public Image()
        {
            Animals = new HashSet<Animal>();
        }

        [Key]
        public int ImageId { get; set; }
        [StringLength(50)]
        public string? Name { get; set; }
        public string? Url { get; set; }
        public string? Description { get; set; }

        [InverseProperty("Image")]
        public virtual ICollection<Animal> Animals { get; set; }
    }
}
