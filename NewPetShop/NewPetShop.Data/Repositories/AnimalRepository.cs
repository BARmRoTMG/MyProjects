using Microsoft.EntityFrameworkCore;
using NewPetShop.Data.Context;
using NewPetShop.Data.Entities;
using NewPetShop.Data.Exceptions;
using NewPetShop.Data.Filters;
using NewPetShop.Data.Interfaces;
using System;
using System.Diagnostics;

namespace NewPetShop.Data.Repositories
{
    public class AnimalRepository : IRepository<Animal>
    {
        private readonly PetShopDbContext _context;

        public AnimalRepository(PetShopDbContext context)
        {
            _context = context;
        }

        public Animal Add(Animal entity)
        {
            if (_context.Animals.Any(a => a.AnimalId == entity.AnimalId))
                throw new DuplicateAnimalException($"An animal with the id {entity.AnimalId} already exists.");

            _context.Animals.Add(entity);
            var res = _context.SaveChanges();

            if (res > 0)
                _context.Entry(entity).Reload();

            return entity;
        }

        public Animal Delete(int id)
        {
            var animal = Get(id);

            _context.Animals.Remove(animal);
            _context.SaveChanges();

            return animal;
        }

        public Animal Get(int id)
        {
            var animal = _context.Animals
                .Include(c => c.Category)
                .Include(i => i.Image)
                .Include(c => c.Comments)
                .SingleOrDefault(a => a.AnimalId == id);

            if (animal == null)
                throw new AnimalNotFoundException($"Animal with id {id} was not found.");

            return animal;
        }

        public FilterResponse<Animal> Get(Filter filter = null)
        {
            if (filter == null)
                filter = new Filter
                {
                    PageNumber = 1,
                    PageSize = 5,
                };

            var all = _context.Animals.Where(a =>
                (filter.Category.HasValue
                    ? a.Category.Name == filter.Category.Value.ToString()
                    : true) &&
                (string.IsNullOrEmpty(filter.Name)
                    ? true
                    : a.Name.Contains(filter.Name)));

            return new FilterResponse<Animal>
            {
                PageNumber = filter.PageNumber,
                PageSize = filter.PageSize,
                Data = all
                .Include(i => i.Image)
                .Include(c => c.Category)
                .Include(c => c.Comments)
                .Skip((filter.PageNumber - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList(),
                Count = all.Count()
            };
        }

        public Animal Update(Animal entity)
        {
            _context.Animals.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }

        public MostCommentedResponse<Animal> GetMostCommented()
        {
            List<Animal> mostCommentedList = new List<Animal>();

            var all = _context.Animals
                .Include(c => c.Comments)
                .ToList();

            var query = all.GroupBy(a => a.Comments).OrderByDescending(g => g.Count()).Take(2).First().Key;
            var query2 = all.GroupBy(a => a.Comments).OrderByDescending(g => g.Count()).Take(2).Last().Key;

            var selected = query.First();
            var selected2 = query2.First();

            var animal = Get(selected.AnimalId);
            var animal2 = Get(selected2.AnimalId);

            mostCommentedList.Add(animal);
            mostCommentedList.Add(animal2);

            return new MostCommentedResponse<Animal>
            {
                Data = mostCommentedList,
            };
        }
    }
}
