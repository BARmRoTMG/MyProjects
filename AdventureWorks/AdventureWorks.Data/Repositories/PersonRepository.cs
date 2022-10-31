using AdventureWorks.Data.Contexts;
using AdventureWorks.Data.Exceptions;
using AdventureWorks.Data.Models.Person;
using Microsoft.EntityFrameworkCore;

namespace AdventureWorks.Data.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly AdventureWorksDbContext _context;

        public PersonRepository(AdventureWorksDbContext context)
        {
            _context = context;
        }

        public Person Add(Person entity)
        {
            try
            {
                if (entity.BusinessEntity == null)
                {
                    entity.BusinessEntity = new BusinessEntity { ModifiedDate = DateTime.Now, Rowguid = Guid.NewGuid() };
                }
                else if (_context.People.Any(p => p.BusinessEntityId == entity.BusinessEntityId))
                {
                    throw new DuplicateEntityException($"Person with Business entity id {entity.BusinessEntityId} already exists.");
                }
                _context.People.Add(entity);
                _context.SaveChanges();
                _context.Entry<Person>(entity).Reload();
                return entity;
            } catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Person Delete(int id)
        {
            var person = Get(id);
            person.PersonPhones.Clear();
            person.EmailAddresses.Clear();
            person.BusinessEntityContacts.Clear();
            person.BusinessEntity.BusinessEntityAddresses.Clear();
            person.BusinessEntity.BusinessEntityContacts.Clear();

            _context.BusinessEntities.Remove(person.BusinessEntity);
            _context.People.Remove(person);

            _context.SaveChanges();
            return person;
        }

        public Person Get(int id)
        {
            var person = _context.People
                .Include(p => p.BusinessEntity)
                .ThenInclude(businessEntity => businessEntity.BusinessEntityAddresses)
                .ThenInclude(businessEntityAddress => businessEntityAddress.Address)
                .ThenInclude(address => address.StateProvince)

                .Include(p => p.BusinessEntity)
                .ThenInclude(businessEntity => businessEntity.BusinessEntityAddresses)
                .ThenInclude(adress => adress.AddressType)

                .Include(p => p.EmailAddresses)

                .Include(p => p.PersonPhones)
                .ThenInclude(phone => phone.PhoneNumberType)

                .FirstOrDefault(p => p.BusinessEntityId == id);
            if (person == null)
                throw new EntityNotFoundException($"Person with id {id} was not found.");

            return person;
        }

        public IEnumerable<Person> Get()
        {
            return _context.People
                .Include(p => p.BusinessEntity)
                .ThenInclude(businessEntity => businessEntity.BusinessEntityAddresses)
                .ThenInclude(businessEntityAddress => businessEntityAddress.Address)
                .ThenInclude(address => address.StateProvince)
                .Include(p => p.EmailAddresses)
                .Include(p => p.PersonPhones)
                .Take(50);
        }

        public Person Update(Person entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
            _context.Entry(entity).Reload();
            return entity;
        }
    }
}
