using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace IntervalQueue.Data.Entities;

public partial class Customer
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string? Name { get; set; }

    public TimeSpan? EntryTime { get; set; }

    public int? SerialNumber { get; set; }
}
