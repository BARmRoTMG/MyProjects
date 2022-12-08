using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewPetShop.Data.Entities;

public partial class User
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Username { get; set; }

    [StringLength(50)]
    public string? Password { get; set; }
}
