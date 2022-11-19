using SelaPetShop.Models.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
