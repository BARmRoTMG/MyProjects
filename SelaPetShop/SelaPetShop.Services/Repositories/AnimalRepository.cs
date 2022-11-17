using Microsoft.EntityFrameworkCore;
using SelaPetShop.Data;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Helpers;
using SelaPetShop.Models.Interfaces;
using System;

namespace SelaPetShop.Services.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly PetShopDbContext _context;

        public AnimalRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public async Task<Animal> Add(Animal entity)
        {
            _context.Animals.Add(entity);
            var res = await _context.SaveChangesAsync();

            if (res > 0)
                await _context.Entry(entity).ReloadAsync();

            return entity;
        }

        public async Task<Animal> Delete(int id)
        {
            var animal = await Get(id);

            _context.Animals.Remove(animal);
            var res = await _context.SaveChangesAsync();

            return animal;
        }

        public async Task<Animal> Get(int id)
        {
            var animal = await _context.Animals
                .Include(a => a.Category)
                .Include(a => a.Comments)
                .SingleOrDefaultAsync(a => a.AnimalId == id);

            if (animal == null)
                throw new Exception($"Animal with id {id} was not found.");

            return animal;
        }

        public async Task<FilterResponse<Animal>> Get(Filter filter = null)
        {
            if (filter == null)
                filter = new Filter
                {
                    PageNumber = 1,
                    PageSize = 5
                };

            return new FilterResponse<Animal>
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Data = _context.Animals
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList(),
                Count = _context.Animals.Count()
            };
        }

        public async Task<Animal> Update(Animal entity)
        {
            throw new NotImplementedException();
        }
    }
}
