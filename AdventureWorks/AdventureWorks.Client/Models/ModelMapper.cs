using AdventureWorks.Data.Models.Person;

namespace AdventureWorks.Client.Models
{
    public class ModelMapper
    {
        public static PersonViewModel MapToViewModel(Person entity)
        {
            return new PersonViewModel
            {
                Id = entity.BusinessEntityId,
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,
                LastModified = entity.ModifiedDate,
                Addresses = entity.BusinessEntity.BusinessEntityAddresses
                    .Select(entityAddress =>
                    $"{entityAddress.Address.AddressLine1}{Environment.NewLine}" +
                    $"{entityAddress.Address.AddressLine2}{Environment.NewLine}" +
                    $"{entityAddress.Address.City} {entityAddress.Address.PostalCode}{Environment.NewLine}" +
                    $"{entityAddress.Address.StateProvince.Name}").ToList(),
                EmailAddresses = entity.EmailAddresses
                    .Where(emailAddress => !string.IsNullOrEmpty(emailAddress.EmailAddress1))
                    .Select(emailAddress => emailAddress.EmailAddress1).ToList(),
                PhoneNumbers = entity.PersonPhones.Select(phone => phone.PhoneNumber).ToList()
            };
        }

        public static PersonDetailViewModel MapToDetailsViewModel(Person entity)
        {
            return new PersonDetailViewModel
            {
                Id = entity.BusinessEntityId,
                Name = (entity.NameStyle ? $"{entity.Title} {entity.LastName} {entity.FirstName} {entity.MiddleName} {entity.Suffix}" : $"{entity.Title} {entity.FirstName} {entity.MiddleName} {entity.LastName} {entity.Suffix}"),
                PersonType = entity.PersonTypeKey,
                EmailAddresses = entity.EmailAddresses
                    .Where(emailAddress => !string.IsNullOrEmpty(emailAddress.EmailAddress1))
                    .Select(emailAddress => emailAddress.EmailAddress1).ToList(),
                PhoneNumbers = entity.PersonPhones.Select(phone => new Tuple<string, string>(phone.PhoneNumberType.Name, phone.PhoneNumber)).ToList(),
                EmailPromotion = entity.EmailPromotionKey,
                Addresses = entity.BusinessEntity.BusinessEntityAddresses.Select(address => new Tuple<string, AddressViewModel>(address.AddressType.Name, new AddressViewModel
                {
                    Id = address.AddressId,
                    StateProvince = address.Address.StateProvince.Name,
                    City = address.Address.City,
                    Line1 = address.Address.AddressLine1,
                    Line2 = address.Address.AddressLine2,
                    PostalCode = address.Address.PostalCode,
                })).ToList(),
            };
        }
    }
}
