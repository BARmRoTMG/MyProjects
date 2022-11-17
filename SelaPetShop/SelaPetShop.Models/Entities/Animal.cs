using System;
using System.Collections.Generic;

namespace SelaPetShop.Models.Entities;

public partial class Animal
{
    public int AnimalId { get; set; }

    public string? Name { get; set; }

    public double? Age { get; set; }

    public byte[]? Photo { get; set; }

    public string? Description { get; set; }

    public int? CategoryId { get; set; }
    //public virtual ICollection<Category> Category { get; set; }
    public virtual Category? Category { get; set; }

    public virtual ICollection<Comment> Comments { get; } = new List<Comment>();
}
