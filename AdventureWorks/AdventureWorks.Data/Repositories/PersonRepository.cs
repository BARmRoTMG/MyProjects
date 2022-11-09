using AdventureWorks.Data.Exceptions;
using AdventureWorks.Data.Models.Person;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorks.Data.Repositories
{
    public class PersonRepository : IRepository<Person>
    {
        private readonly AdventureWorksDbContext _context;

        public PersonRepository(AdventureWorksDbContext context)
        {
            _context = context;
        }

        public async Task<Person> Add(Person entity)
        {
            if (entity.BusinessEntity == null)
            {
                entity.BusinessEntity = new BusinessEntity { ModifiedDate = DateTime.Now, Rowguid = Guid.NewGuid() };
            }
            else if (_context.People.Any(p => p.BusinessEntityId == entity.BusinessEntityId))
            {
                throw new DuplicateEntityException($"Person with Business entity id {entity.BusinessEntityId} already exists");
            }
            _context.People.Add(entity);
            var res = await _context.SaveChangesAsync();

            if (res > 0)
                _context.Entry(entity).Reload();

            return entity;
        }

        public async Task<Person> Delete(int id)
        {
            var person = await Get(id);

            _context.BusinessEntities.Remove(person.BusinessEntity);
            _context.People.Remove(person);

            var res = await _context.SaveChangesAsync();

            //if (res > 0)
            //    _context.Entry(person).Reload();

            return person;
        }

        public async Task<Person> Get(int id)
        {
            var person = await _context.People
                .Include(p => p.BusinessEntity)
                .ThenInclude(businessEntity => businessEntity.BusinessEntityAddresses)
                .ThenInclude(businessEntityAddress => businessEntityAddress.Address)
                .ThenInclude(address => address.StateProvince)
                .Include(p => p.BusinessEntity)
                .ThenInclude(businessEntity => businessEntity.BusinessEntityAddresses)
                .ThenInclude(address => address.AddressType)
                .Include(p => p.EmailAddresses)
                .Include(p => p.PersonPhones)
                .ThenInclude(phone => phone.PhoneNumberType)
                .SingleOrDefaultAsync(p => p.BusinessEntityId == id);
            if (person == null)
                throw new EntityNotFoundException($"person with id {id} was not found");

            return person;
        }

        public async Task<PageResponse<Person>> Get(Filter filter = null)
        {
            if (filter == null)
                filter = new Filter
                {
                    PageNumber = 1,
                    PageSize = 10
                };

            var all = _context.People.Where(p =>
                (filter.PersonType.HasValue
                    ? p.PersonType == filter.PersonType.Value.ToString()
                    : true) &&
                (string.IsNullOrEmpty(filter.FirstName)
                    ? true
                    : p.FirstName.Contains(filter.FirstName)) &&
                (string.IsNullOrEmpty(filter.MiddleName)
                    ? true
                    : p.LastName.Contains(filter.MiddleName)) &&
                (string.IsNullOrEmpty(filter.LastName)
                    ? true
                    : p.LastName.Contains(filter.LastName)));

            //Thread.Sleep(3000);
            return new PageResponse<Person>
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Data = await all
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToListAsync(),
                TotalCount = await all.CountAsync()
            };
        }

        public async Task<Person> Update(Person entity)
        {
            var existingEmails = _context.EmailAddresses.Where(a => a.BusinessEntityId == entity.BusinessEntityId);

            foreach (var newEmail in entity.EmailAddresses)
            {
                foreach (var email in existingEmails)
                {
                    //if (newEmail.EmailAddress1.Equals(email.EmailAddress1, StringComparison(newEmail.EmailAddress1, ))
                    //{
                    //    entity.EmailAddresses.Remove(newEmail);
                    //    //entity.EmailAddresses.Add(email);
                    //    break;
                    //}
                }
            }

            _context.Update(entity);
            var res = await _context.SaveChangesAsync();

            if (res > 0)
                _context.Entry(entity).Reload();

            return entity;
        }
    }
}
