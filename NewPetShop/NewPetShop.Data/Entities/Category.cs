using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewPetShop.Data.Entities;

public partial class Category
{
    [Key]
    public int CategoryId { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    [StringLength(50)]
    public string? Value { get; set; }

    [InverseProperty("Category")]
    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();
}
