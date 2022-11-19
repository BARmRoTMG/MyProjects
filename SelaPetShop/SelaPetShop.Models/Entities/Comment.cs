using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SelaPetShop.Models.Entities
{
    //[Index("AnimalId", Name = "IX_FK_Comments_Animals")]
    public partial class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int AnimalId { get; set; }
        [StringLength(50)]
        public string? Value { get; set; }

        [ForeignKey("AnimalId")]
        [InverseProperty("Comments")]
        public virtual Animal Animal { get; set; } = null!;
    }
}
