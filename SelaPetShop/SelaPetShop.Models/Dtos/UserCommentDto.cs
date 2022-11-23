using System;
using System.ComponentModel.DataAnnotations;

namespace SelaPetShop.Models.Dtos
{
    public class UserCommentDto
    {
        [Required]
        [Display(Name = "Comment ID")]
        public int CommentId { get; set; }

        [Required]
        [Display(Name = "Animal ID")]
        public int AnimalId { get; set; }

        [Display(Name = "Comment")]
        [StringLength(100)]
        public string? Value { get; set; }
    }
}
