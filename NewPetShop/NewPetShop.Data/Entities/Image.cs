using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace NewPetShop.Data.Entities;

public partial class Image
{
    [Key]
    public int ImageId { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public string? Url { get; set; }

    public string? Description { get; set; }

    [InverseProperty("Image")]
    public virtual ICollection<Animal> Animals { get; } = new List<Animal>();
}
