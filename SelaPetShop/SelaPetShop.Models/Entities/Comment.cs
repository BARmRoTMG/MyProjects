using System;
using System.Collections.Generic;

namespace SelaPetShop.Models.Entities;

public partial class Comment
{
    public int CommentId { get; set; }

    public int? AnimalId { get; set; }

    public string? Comment1 { get; set; }

    public virtual Animal? Animal { get; set; }
}
