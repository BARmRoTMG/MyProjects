using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace IntervalQueue.Client.Models
{
    public class CustomerDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A name must be stated.")]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string? Name { get; set; }

        [Display(Name = "Enqueued At")]
        [Column(TypeName = "date")]
        public TimeSpan? EntryTime { get; set; }

        [Display(Name = "Queue Num")]
        public int? SerialNumber { get; set; }
    }
}
