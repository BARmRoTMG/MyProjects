using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Client.Models
{
    public class PersonViewModel
    {
        public PersonViewModel()
        {
            EmailAddresses = new List<string>();
            PhoneNumbers = new List<string>();
            Addresses = new List<string>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [StringLength(50)]
        [Display(Name = "Middle Name")]
        public string? MiddleName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        public DateTime LastModified { get; set; }

        [Display(Name = "Email")]
        public List<string> EmailAddresses { get; set; }

        [Display(Name = "Phone")]
        public List<string> PhoneNumbers { get; set; }

        [Display(Name = "Address")]
        public List<string> Addresses { get; set; }
    }
}
