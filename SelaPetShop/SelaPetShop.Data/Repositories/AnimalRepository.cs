using SelaPetShop.Data.Contexts;
using SelaPetShop.Data.Models;
using System;

namespace SelaPetShop.Data.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly PetShopDbContext _context;

        public AnimalRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public Task<Animal> Add(Animal entity)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<PageResponse<Animal>> Get(Filter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> Login(Animal user)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> Register(Animal user)
        {
            throw new NotImplementedException();
        }

        public Task<Animal> Update(Animal entity)
        {
            throw new NotImplementedException();
        }
    }
}
