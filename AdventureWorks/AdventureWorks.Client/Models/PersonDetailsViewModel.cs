using AdventureWorks.Data.Models.Person;

namespace AdventureWorks.Client.Models
{
    public class PersonDetailsViewModel : PersonBaseViewModel
    {
        public List<Tuple<string, AddressViewModel>> Addresses { get; set; }
        public List<string> EmailAddresses { get; set; }
        public List<Tuple<string, string>> PhoneNumbers { get; set; }
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
