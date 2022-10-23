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
                Addresses = entity.BusinessEntity.BusinessEntityAddresses.Select(entityAddress => $"{entityAddress.Address.AddressLine1}{Environment.NewLine}{entityAddress.Address.AddressLine2}").ToList(),
                EmailAddresses = entity.EmailAddresses.Where(emailAddress => !string.IsNullOrEmpty(emailAddress.EmailAddress1)).Select(emailAddress => emailAddress.EmailAddress1).ToList(),
                PhoneNumbers = entity.PersonPhones.Select(phone => phone.PhoneNumber).ToList()
            };
        }
    }
}
