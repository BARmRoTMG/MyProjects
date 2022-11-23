using System;
using System.ComponentModel.DataAnnotations;

namespace SelaPetShop.Models.Entities
{
    public partial class User
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string? Username { get; set; }
        [StringLength(50)]
        public string? Password { get; set; }
    }
}
