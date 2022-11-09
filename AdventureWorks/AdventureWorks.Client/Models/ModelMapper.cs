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
                FirstName = entity.FirstName,
                MiddleName = entity.MiddleName,
                LastName = entity.LastName,
                PersonType = entity.PersonType,
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

        public static Person MapToEntity(PersonDetailsViewModel model)
        {
            return new Person
            {
                BusinessEntityId = model.Id,
                FirstName = model.FirstName,
                MiddleName = model.MiddleName,
                LastName = model.LastName,
                PersonType = model.PersonType,
                EmailAddresses = model.EmailAddresses.Select(eAddress =>
                new EmailAddress
                {
                    BusinessEntityId = model.Id,
                    EmailAddress1 = eAddress
                }).ToList(),
                EmailPromotionKey = model.EmailPromotion??,
                PersonPhones = model.PhoneNumbers.Select(phone => 
                new PersonPhone
                {
                    BusinessEntityId = model.Id,
                    PhoneNumber = phone.Item2,
                    PhoneNumberType = new PhoneNumberType { Name = phone.Item1 }
                }).ToList()
               
            };

        }
    }
}
