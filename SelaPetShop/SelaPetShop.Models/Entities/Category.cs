using System;
using System.Collections.Generic;

namespace SelaPetShop.Models.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string? CategoryName { get; set; }

    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();
}
