using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaPetShop.Models.Dtos
{
    public class UserCommentDto
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        public int CommentId { get; set; }

        [StringLength(100)]
        public string? Comment1 { get; set; }
    }
}
