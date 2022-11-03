using AdventureWorks.Data.Models.Person;

namespace AdventureWorks.Client.Models
{
    public class ModelMapper
    {
        public static PersonBaseViewModel MapToBaseViewModel(Person entity)
        {
            return new PersonBaseViewModel
            {
                Id = entity.BusinessEntityId,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,
                PersonType = entity.PersonType,
            };
        }

        public static PersonDetailsViewModel MapToDetails(Person entity)
        {
            return new PersonDetailsViewModel
            {
                Id = entity.BusinessEntityId,
                Name = entity.NameStyle ?
                    $"{entity.Title} {entity.LastName} {entity.FirstName} {entity.MiddleName} {entity.Suffix}"
                    : $"{entity.Title} {entity.FirstName} {entity.MiddleName} {entity.LastName} {entity.Suffix}",
                PersonType = entity.PersonTypeKey,
                EmailAddresses = entity.EmailAddresses
                    .Where(emailAddress => !string.IsNullOrEmpty(emailAddress.EmailAddress1))
                    .Select(emailAddress => emailAddress.EmailAddress1).ToList(),
                PhoneNumbers = entity.PersonPhones.Select(phone =>
                   new Tuple<string, string>(phone.PhoneNumberType.Name, phone.PhoneNumber)).ToList(),
                EmailPromotion = entity.EmailPromotionKey,
                Addresses = entity.BusinessEntity.BusinessEntityAddresses.Select(address => new Tuple<string, AddressViewModel>(address.AddressType.Name, new AddressViewModel
                {
                    Id = address.AddressId, 
                    StateProvince = address.Address.StateProvince.Name, 
                    City = address.Address.City, 
                    Line1 = address.Address.AddressLine1,
                    Line2 = address.Address.AddressLine2,
                    PostalCode = address.Address.PostalCode
                })).ToList()
            };
        }
    }
}
