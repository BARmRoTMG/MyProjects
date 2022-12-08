using System.ComponentModel.DataAnnotations;
using NewPetShop.Data.Entities;

namespace NewPetShop.Client.Models
{
    public class PageControlViewModel
    {
        [Required]
        [Range(1, int.MaxValue)]
        public int PageNumber { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public string? Name { get; set; }
        public CategoryEnum? Category { get; set; }
    }
}
