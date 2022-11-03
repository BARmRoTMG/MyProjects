using AdventureWorks.Data.Models.Person;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Client.Models
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

        public EnumPersonType? PersonType { get; set; }

        public string? FirstName { get; set; }
        public string? MiddleName { get; set; }
        public string? LastName { get; set; }
    }
}
