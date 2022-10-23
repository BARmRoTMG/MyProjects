using AdventureWorks.Data.Contexts;
using AdventureWorks.Data.Exceptions;
using AdventureWorks.Data.Models.Person;

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
            if (entity.BusinessEntity == null)
                entity.BusinessEntity = new BusinessEntity { ModifiedDate = DateTime.Now, Rowguid = Guid.NewGuid() };
            else if (_context.People.Any(p => p.BusinessEntityId == entity.BusinessEntityId))
                throw new DuplicateEntityException($"Person with business entity id {entity.BusinessEntityId} already exists.");

            _context.People.Add(entity);
            _context.SaveChanges();
            _context.Entry<Person>(entity).Reload();

            return entity;
        }

        public Person Delete(int id)
        {
            var person = Get(id);

            if (person == null)
                throw new EntityNotFoundException($"Person with ID: {id} was not found");

            _context.People.Remove(person);
            _context.SaveChanges();

            return person;
        }

        public Person Get(int id)
        {
            var person = _context.People.FirstOrDefault(p => p.BusinessEntityId == id);

            if (person == null)
                throw new EntityNotFoundException($"Person with ID: {id} was not found");

            return person;
        }

        public IEnumerable<Person> Get()
        {
            return _context.People;
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
