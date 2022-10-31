using AdventureWorks.Data.Models.Person;
using System.ComponentModel.DataAnnotations;

namespace AdventureWorks.Client.Models
{
    public class PersonDetailViewModel
    {
        public PersonDetailViewModel()
        {
            EmailAddresses = new List<string>();
            //PhoneNumbers = new List<string, string>();
            //Addresses = new List<string, string>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [Display(Name = "Person Type")]
        public EnumPersonType PersonType { get; set; }
        public string Title { get; set; }

        [Display(Name = "Last Modified")]
        public DateTime LastModified { get; set; }

        [Display(Name = "Email")]
        public List<string> EmailAddresses { get; set; }

        [Display(Name = "Phone")]
        public List<Tuple<string, string>> PhoneNumbers { get; set; }

        [Display(Name = "Address")]
        public List<Tuple<string, AddressViewModel>> Addresses { get; set; }

        [Display(Name = "Additional Contact Info")]
        public string AdditionalContactInfo { get; set; }
        public EnumEmailPromotion EmailPromotion { get; set; }
    }

    public class AddressViewModel
    {
        public int Id { get; set; }
        public string StateProvince { get; set; }
        public string City { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public string PostalCode { get; set; }
    }
}
