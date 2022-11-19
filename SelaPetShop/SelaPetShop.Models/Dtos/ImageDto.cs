using System;
using System.ComponentModel.DataAnnotations;

namespace SelaPetShop.Models.Dtos
{
    public class ImageDto
    {
        [Required]
        [Display(Name = "Image ID")]
        public int ImageId { get; set; }
        [StringLength(50)]

        [Display(Name = "Image Name")]
        public string? Name { get; set; }

        [Display(Name = "Image URL")]
        public string? Url { get; set; }

        [Display(Name = "Image Description")]
        public string? Description { get; set; }
    }
}
