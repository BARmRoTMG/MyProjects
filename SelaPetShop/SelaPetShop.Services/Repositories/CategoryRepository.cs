using SelaPetShop.Data;
using SelaPetShop.Models.Entities;
using SelaPetShop.Models.Helpers;
using SelaPetShop.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaPetShop.Services.Repositories
{
    public class CategoryRepository : IRepository<Category>
    {
        private readonly PetShopDbContext _context;

        public CategoryRepository(PetShopDbContext context)
        {
            _context = context;
        }
        public Task<Category> Add(Category entity)
        {
            throw new NotImplementedException();
        }

        public Task<Category> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Get(int? id)
        {
            return  _context.Categories.SingleOrDefault(p => p.CategoryId == id);
        }

        public Task<FilterResponse<Category>> Get(Filter filter = null)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetLastId()
        {
            throw new NotImplementedException();
        }

        public Task<Category> Update(Category entity)
        {
            throw new NotImplementedException();
        }
    }
}
